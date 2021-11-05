using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Repositories
{
   public class CredentialRepository
    {
        DataAccess dataAccess;
        public CredentialRepository()
        {
            dataAccess = new DataAccess();
        }

        public int Validation(string username, string password)
        {
            string sql = "SELECT * FROM Credentials WHERE Username='" + username + "' AND Password='" + password + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            int userType = (int)reader["UserType"];
            if (userType == 1)
            {
                return 1;
            }
            else if (userType == 2)
            {
                return 2;
            }
            else if (userType == 3)
            {
                return 3;
            }

            else
            {
                return 0;
            }
        }
    }
}
