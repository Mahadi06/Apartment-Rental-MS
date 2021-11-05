using Entity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService
    {
        AdminRepository apRepo;
        public AdminService()
        {
            apRepo = new AdminRepository();
        }
        public int AdminRegistration(string name, string email, string phone, string username, string password, int userType)
        {
            return apRepo.Insert(name, email, phone, username, password, userType);
        }

       

    }
}
