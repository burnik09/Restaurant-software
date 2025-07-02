using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager
{
    public class User
    {
        public String Name { get; set; }
        private String Pass { get; set; }
        public bool IsAdmin { get; set; }

        public User(String name, String pass, bool isAdmin)
        {
            this.Name = name;
            this.Pass = pass;
            IsAdmin = isAdmin;
        }

        public bool checkUser(String user, String pass)
        {
            return this.Name.Equals(user) && this.Pass.Equals(pass);
        }

    }
}
