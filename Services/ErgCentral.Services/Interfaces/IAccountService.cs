using ErgCentral.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Services.Interfaces
{
   public interface IAccountService
    {
        List<ApplicationUser> GetUsers();
        ApplicationUser GetById(ApplicationUser applicationUser);
        void CreateAccount(ApplicationUser applicationUser);
        void UpdateAccount(ApplicationUser applicationUser);
        void DeleteAccount(ApplicationUser applicationUser);
    }
}
