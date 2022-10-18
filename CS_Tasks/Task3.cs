using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task3
    {
        public static int DigitalRoot(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result += number % 10;
                number /= 10;
            }
            if (result > 10)
                return DigitalRoot(result);
            else
                return result;
        }
    }
}