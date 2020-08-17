using ErgCentral.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository.Interfaces
{
    public interface IAccountRepository
    {
        List<ApplicationUser> GetUsers();
        ApplicationUser GetById(ApplicationUser applicationUser);
        void CreateAccount(ApplicationUser applicationUser);
        void UpdateAccount(ApplicationUser applicationUser);
        void DeleteAccount(ApplicationUser applicationUser);

    }
}
