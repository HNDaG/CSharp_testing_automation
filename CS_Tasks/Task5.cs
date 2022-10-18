using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task5
    {
        internal class Friend
        {
            private string _firstName = "";
            private string _lastName = "";
            public string FirstName { get => _firstName; set => _firstName = value.ToUpper(); }
            public string LastName { get => _lastName; set => _lastName = value.ToUpper(); }
            public override string ToString()
            {
                return $"({LastName}, {FirstName})";
            }
        }

        public static string ChangeFriendList(string friendList)
        {
            string[] friendsNames = friendList.Split(';');
            List<Friend> friends = new List<Friend>();

            foreach (string friendName in friendsNames)
            {
                string[] name = friendName.Split(':');
                try
                {
                    friends.Add(new Friend()
                    {
                        FirstName = name[0],
                        LastName = name[1]
                    });
                }
                catch (Exception)
                {
                    throw new Exception("Format failure...");
                }

            }
            var resultList = friends.OrderBy(friend => friend.LastName)
                                    .ThenBy(friend => friend.FirstName)
                                    .Select(friend => friend.ToString());
            return string.Join("", resultList);
        }
    }
}