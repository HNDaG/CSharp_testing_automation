using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task4
    {
        public static int CountPairsToSum(int[] arr, int sum)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] + arr[j] == sum)
                        count++;

            return count;
        }
    }
}