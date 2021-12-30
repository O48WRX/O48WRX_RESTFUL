using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int isadmin;

        public int IsAdmin
        {
            get { return isadmin; }
            set { isadmin = value; }
        }

        public User()
        {

        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.IsAdmin = 0;
        }

        public User(string username, string password, int isAdmin)
        {
            this.Username = username;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
        public User(int id, string username, string password, int isAdmin)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.IsAdmin = IsAdmin;
        }
    }
}
