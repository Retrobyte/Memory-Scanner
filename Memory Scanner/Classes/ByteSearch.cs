using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Scanner.Classes
{
    public static class ByteSearch
    {
        private static int[] createTable(byte[] pattern)
        {
            int[] table = new int[256];

            for (int i = 0; i < table.Length; i++)
                table[i] = pattern.Length;

            for (int i = 0; i < pattern.Length - 1; i++)
                table[Convert.ToInt32(pattern[i])] = pattern.Length - i - 1;
            
            return table;
        }

        public static bool matchAtOffset(byte[] toSearch, byte[] pattern, int index)
        {
            if (index + pattern.Length > toSearch.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (toSearch[i + index] != pattern[i])
                    return false;
            }

            return true;
        }

        public static bool contains(byte[] toSearch, byte[] pattern)
        {
            return firstIndexOf(toSearch, pattern) != -1;
        }

        public static int firstIndexOf(byte[] toSearch, byte[] pattern)
        {
            int[] table = createTable(pattern);
            int position = pattern.Length - 1;

            while (position < toSearch.Length)
            {
                int i;

                for (i = 0; i < pattern.Length; i++)
                {
                    if (pattern[pattern.Length - 1 - i] != toSearch[position - i])
                        break;

                    if (i == pattern.Length - 1)
                        return position - i;
                }

                position += table[Convert.ToInt32(toSearch[position - i])];
            }

            return -1;
        }

        public static int lastIndexOf(byte[] toSearch, byte[] pattern)
        {
            int ret = -1;
            int[] table = createTable(pattern);
            int position = pattern.Length - 1;

            while (position < toSearch.Length)
            {
                int i;
                bool found = false;

                for (i = 0; i < pattern.Length; i++)
                {
                    if (pattern[pattern.Length - 1 - i] != toSearch[position - i])
                        break;

                    if (i == pattern.Length - 1)
                    {
                        ret = position - i;
                        found = true;
                    }
                }

                if (found)
                    position++;
                else
                    position += table[Convert.ToInt32(toSearch[position - i])];
            }

            return ret;
        }

        public static int[] allIndexOf(byte[] toSearch, byte[] pattern)
        {
            List<int> indices = new List<int>();
            int[] table = createTable(pattern);
            int position = pattern.Length - 1;

            while (position < toSearch.Length)
            {
                int i;
                bool found = false;

                for (i = 0; i < pattern.Length; i++)
                {
                    if (pattern[pattern.Length - 1 - i] != toSearch[position - i])
                        break;

                    if (i == pattern.Length - 1)
                    {
                        indices.Add(position - i);
                        found = true;
                    }
                }

                if (found)
                    position++;
                else
                    position += table[Convert.ToInt32(toSearch[position - i])];
            }

            return indices.ToArray();
        }
    }
}
