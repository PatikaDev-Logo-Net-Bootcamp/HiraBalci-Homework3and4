using First.App.Business.Abstract;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//


namespace First.App.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<Users> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void AddUsers(Users users)
        {
            repository.Add(users);
            unitOfWork.Commit();
        }

        public void DeleteUsers(Users users)
        {
            repository.Delete(users);
            unitOfWork.Commit();
        }

        public List<Users> GetAllCompany()
        {
            return repository.Get().ToList();
        }

        public void UpdateUsers(Users users)
        {
            repository.Update(users);
            unitOfWork.Commit();
        }
    }

}
