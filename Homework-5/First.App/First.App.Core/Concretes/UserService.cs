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
        private readonly IRepository<Posts> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<Posts> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void AddUsers(Posts users)
        {
            repository.Add(users);
            unitOfWork.Commit();
        }

        public void DeleteUsers(Posts users)
        {
            repository.Delete(users);
            unitOfWork.Commit();
        }

        public List<Posts> GetAllCompany()
        {
            return repository.Get().ToList();
        }

        public void UpdateUsers(Posts users)
        {
            repository.Update(users);
            unitOfWork.Commit();
        }
    }

}
