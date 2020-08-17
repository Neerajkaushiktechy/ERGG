using ErgCentral.Repository.Entity;
using ErgCentral.Repository.Interfaces;
using ErgCentral.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgCentral.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) {
            _accountRepository = accountRepository;
        }
        public void CreateAccount(ApplicationUser applicationUser)
        {
            _accountRepository.CreateAccount(applicationUser);
        }

        public void DeleteAccount(ApplicationUser applicationUser)
        {
            _accountRepository.DeleteAccount(applicationUser);
        }

        public ApplicationUser GetById(ApplicationUser applicationUser)
        {
            return _accountRepository.GetById(applicationUser);
        }

        public List<ApplicationUser> GetUsers()
        {
            return _accountRepository.GetUsers().ToList();
        }

        public void UpdateAccount(ApplicationUser applicationUser)
        {
            _accountRepository.UpdateAccount(applicationUser);
        }
    }
}
