using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Scanner.Classes
{
    public enum ProcessorArchitecture
    {
        X86 = 0,
        X64 = 9,
        Arm = -1,
        Itanium = 6,
        Unknown = 0xFFFF
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemInfo
    {
        public ProcessorArchitecture ProcessorArchitecture;
        public uint PageSize;
        public IntPtr MinimumApplicationAddress;
        public IntPtr MaximumApplicationAddress;
        public IntPtr ActiveProcessorMask;
        public uint NumberOfProcessors;
        public uint ProcessorType;
        public uint AllocationGranularity;
        public ushort ProcessorLevel;
        public ushort ProcessorRevision;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }

    public class SearchResult
    {
        public SearchResult(IntPtr add, byte[] value)
        {
            Address = add;
            Buffer = value;
        }

        public IntPtr Address { get; set; }

        public Byte[] Buffer { get; set; }
    }

    public class MemorySearch
    {
        private IntPtr _handle;
        private int _processId;
        private uint _maxAddress;

        private Dictionary<IntPtr, byte[]> _regions;
        private List<SearchResult> _results;

        public event ProgressChanged ProgressChangedEvent;
        public delegate void ProgressChanged(int value);

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SystemInfo Info);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint access, bool inherit, int process);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        public static extern int VirtualQueryEx(IntPtr handle, IntPtr baseAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, uint size, out int length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out int length);

        public MemorySearch()
        {
            SystemInfo info;
            GetSystemInfo(out info);

            _maxAddress = (uint)info.MaximumApplicationAddress;

            resetFields();
        }

        private void resetFields()
        {
            _handle = IntPtr.Zero;
            _regions = new Dictionary<IntPtr, byte[]>();
            _results = new List<SearchResult>();
        }

        public void setProgressEvent(ProgressChanged p)
        {
            ProgressChangedEvent = p;
        }

        public void openProcess(int processId)
        {
            if (_handle != IntPtr.Zero)
            {
                closeProcess();
                resetFields();
            }

            _processId = processId;
            _handle = OpenProcess(1080, false, processId);

            if (_handle == IntPtr.Zero)
                throw new Exception("Failed to open process " + processId.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
        }

        public void closeProcess()
        {
            CloseHandle(_handle);
        }

        private void dumpRegions()
        {
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Cannot dump process memory regions. No process loaded.");

            _regions.Clear();

            IntPtr current = IntPtr.Zero;
            MEMORY_BASIC_INFORMATION memInfo = new MEMORY_BASIC_INFORMATION();

            while ((uint)current < _maxAddress && VirtualQueryEx(_handle, current, out memInfo, Marshal.SizeOf(memInfo)) != 0)
            {
                if (memInfo.State == 4096 && memInfo.Protect == 4 && (uint)memInfo.RegionSize != 0)
                {
                    byte[] regionData = new byte[(int)memInfo.RegionSize];
                    int bytesRead = 0;

                    if (!ReadProcessMemory(_handle, memInfo.BaseAddress, regionData, (uint)memInfo.RegionSize, out bytesRead))
                        throw new Exception("Failed to read process memory at " + memInfo.BaseAddress.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());

                    _regions.Add(memInfo.BaseAddress, regionData);
                }

                current = IntPtr.Add(memInfo.BaseAddress, memInfo.RegionSize.ToInt32());
            }
        }

        private void updateProgress(int amount)
        {
            if (ProgressChangedEvent != null)
                ProgressChangedEvent(amount);
        }

        public void firstScan(byte[] buffer, Action callback = null)
        {
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Cannot scan process memory regions. No process loaded.");

            if (buffer.Length == 0)
                throw new ArgumentOutOfRangeException("Buffer cannot be of length 0.");

            _results.Clear();

            dumpRegions();
            updateProgress(0);

            int count = 0;

            foreach (IntPtr address in _regions.Keys)
            {
                foreach (int i in ByteSearch.allIndexOf(_regions[address], buffer))
                    _results.Add(new SearchResult(IntPtr.Add(address, i), buffer));

                count++;
                updateProgress((int)(count / _regions.Count * 100));
            }

            updateProgress(100);

            if (callback != null)
                callback();
        }

        public void nextScan(byte[] buffer, Action callback = null)
        {
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Cannot scan process memory regions. No process loaded.");

            if (buffer.Length == 0)
                throw new ArgumentOutOfRangeException("Buffer cannot be of length 0.");

            dumpRegions();
            updateProgress(0);

            int count = 0;

            foreach (SearchResult sr in _results.ToArray())
            {
                if (_regions.ContainsKey(sr.Address))
                {
                    if (!ByteSearch.matchAtOffset(_regions[sr.Address], buffer, 0))
                        _results.Remove(sr);
                    else
                        sr.Buffer = buffer;
                }
                else
                {
                    foreach (IntPtr regionAddress in _regions.Keys)
                    {
                        int lowerBound = (int)regionAddress;
                        int upperBound = lowerBound + _regions[regionAddress].Length;
                        int cAddress = (int)sr.Address;

                        if (cAddress >= lowerBound && cAddress <= upperBound)
                        {
                            if (!ByteSearch.matchAtOffset(_regions[regionAddress], buffer, cAddress - lowerBound))
                                _results.Remove(sr);
                            else
                                sr.Buffer = buffer;

                            break;
                        }
                    }
                }

                count++;
                updateProgress((int)(count / _regions.Count * 100));
            }

            updateProgress(100);

            if (callback != null)
                callback();
        }

        public byte[] readMemory(IntPtr address, int length)
        {
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Cannot read process memory at " + address.ToString() + ". No process loaded.");

            if (address == IntPtr.Zero)
                throw new ArgumentOutOfRangeException("Cannot read process memory. Invalid memory address.");

            if (length < 1)
                throw new ArgumentOutOfRangeException("Cannot read process memory of size " + length + ".");

            int bytesRead;
            byte[] data = new byte[length];

            if (!ReadProcessMemory(_handle, address, data, (uint)data.Length, out bytesRead))
                throw new Exception("Failed to read process memory at " + address.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());

            return data;
        }

        public void writeMemory(IntPtr address, byte[] data)
        {
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Cannot write process memory at " + address.ToString() + ". No process loaded.");

            if (address == IntPtr.Zero)
                throw new ArgumentOutOfRangeException("Cannot write process memory. Invalid memory address.");

            if (data.Length < 1)
                throw new ArgumentOutOfRangeException("Cannot write process memory of size " + data.Length + ".");

            int bytesWritten;

            if (!WriteProcessMemory(_handle, address, data, data.Length, out bytesWritten))
                throw new Exception("Failed to write process memory at " + address.ToString() + ". Error code: " + Marshal.GetLastWin32Error().ToString());
        }

        public IntPtr Handle { get { return _handle; } }

        public SearchResult[] Results { get { return _results.ToArray(); } }
    }
}
