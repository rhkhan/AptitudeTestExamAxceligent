using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClass
{
    class User
    {
        public static List<string> users = new List<string>();

        static void Add(string username)
        {
            users.Add(username);
        }

        static int GetUsersCount()
        {
            return users.Count();
        }
    }

}
