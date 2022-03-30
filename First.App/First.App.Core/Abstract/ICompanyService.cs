using First.App.Business.DTOs;
using First.App.Domain.Entities;
using System.Collections.Generic;

namespace First.App.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAllCompany();//niye liste yaptım?Çünkü birden fazla katmana gelebilir.
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
         
    }
}
