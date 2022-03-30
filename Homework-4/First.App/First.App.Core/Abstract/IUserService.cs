using First.App.Business.DTOs;
using First.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IUserService
    {
        List<Users> GetAllCompany();//niye liste yaptım?Çünkü birden fazla katmana gelebilir.
        void AddUsers(Users users);
        void UpdateUsers(Users users);
        void DeleteUsers(Users users);

    }
}
