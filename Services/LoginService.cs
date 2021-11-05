
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService
    {
        CredentialRepository credRepo;
        public LoginService()
        {
            credRepo = new CredentialRepository();
        }

        public int LoginValidation(string username, string password)
        {
            return credRepo.Validation(username, password);
        }
    }
}
