using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task1
    {
        public static List<int> GetIntegersFromList(List<object> innputList)
        {
            List<int> Result = new List<int>();
            for (int i = 0; i < innputList.Count; i++)
            {
                if (innputList[i] is int && (int)innputList[i] > 0)
                {
                    Result.Add((int)innputList[i]);
                }
            }
            return Result;
        }
    }
}
