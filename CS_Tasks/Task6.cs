using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task6
    {
        public static int CountDigits(int number)
        {
            number = Math.Abs(number);

            if (number >= 10)
                return CountDigits(number / 10) + 1;
            return 1;
        }

        public static int NextPermutation(int number)
        {
            int n = CountDigits(number);
            int[] arr = new int[n];

            for (int j = 0; j < n; j++)
            {
                arr[n - 1 - j] = number % 10;
                number /= 10;
            }

            if (n == 1)
                return -1;

            int i = 0;
            for (i = n - 1; i > 0; i--)
            {
                if (arr[i] > arr[i - 1])
                    break;
            }

            if (i != 0)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    if (arr[i - 1] < arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i - 1];
                        arr[i - 1] = temp;
                        break;
                    }
                }
            }
            else if (i == 0)
                return -1;


            int[] res = new int[arr.Length];
            int ind = arr.Length - 1;


            for (int j = 0; j < i; j++)
                res[j] = arr[j];

            for (int j = i; j < res.Length; j++)
                res[j] = arr[ind--];

            string str = string.Join("", res);
            return Convert.ToInt32(str);
        }
    }
}