using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebArrdessbookTests
{
    class AccounData
    {
        private string username;
        private string password;

        public AccounData (string username, string password)
        {
            this.username = username;
            this.password = password;
        }


        public string Username
        {
            get
            {
                return username;
                    }

            set
            {
                username = value; 
                    }

        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
         }
      
    }
}
