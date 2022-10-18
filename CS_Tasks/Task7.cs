using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task7
    {
        public static string GetIPFromInt(uint number)
        {
            string[] segments = new string[4];
            for (int i = 0; i < 4; i++)
            {
                int segmentNumber = (int)(number / Math.Pow(256, i) % 256);
                segments[3 - i] = segmentNumber.ToString();
            }
            return string.Join('.', segments);
        }
    }
}