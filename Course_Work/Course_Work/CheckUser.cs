using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Course_Work
{
    public class CheckUser
    {
        DataBase _dataBase;
        public string Login { get; set; }

        public bool IsAdmin { get; }


        public string Status => IsAdmin ? "Admin" : "Croupier";

        public CheckUser(string login, bool is_admin) 
        { 
            Login = login.Trim();
            IsAdmin = is_admin;
        }
    }

}
