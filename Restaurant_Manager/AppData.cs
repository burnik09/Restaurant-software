using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager
{
    public static class AppData
    {
        public static List<User> allServers { get; } = new List<User>
        {
            (new User("Andrej", "An123", true)),
            (new User("Dimitar", "Di123", true)),
            (new User("Test", "Te123", false))
        };
    }
}
