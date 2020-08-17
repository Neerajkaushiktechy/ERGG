using ErgCentral.Repository.Entity;
using ErgCentral.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgCentral.Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        
        private readonly IBaseRepository<ApplicationUser> _applicationUserRepository;
        private readonly ErgCentralContext _ergCentralContext;

        public AccountRepository(IBaseRepository<ApplicationUser> applicationUserRepository, ErgCentralContext ergCentralContext) {

            _applicationUserRepository = applicationUserRepository;
            _ergCentralContext = ergCentralContext;
        }

        public List<ApplicationUser> GetUsers() {
            List<ApplicationUser> users = _applicationUserRepository.GetAll().ToList();
            return users;

        }

        public ApplicationUser GetById(ApplicationUser applicationUser) {

            ApplicationUser User = _applicationUserRepository.Get().FirstOrDefault(x => x.Id == applicationUser.Id);
            return User;
        }

        public void CreateAccount(ApplicationUser applicationUser) {
            _applicationUserRepository.Insert(applicationUser);
        }

        public void UpdateAccount(ApplicationUser applicationUser) {
            _applicationUserRepository.Update(applicationUser);
        }
        public void DeleteAccount(ApplicationUser applicationUser) {
            _applicationUserRepository.Delete(applicationUser);
        }

    }
}
