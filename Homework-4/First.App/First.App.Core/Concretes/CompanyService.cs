﻿using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;//IRepository hata verirse companye implement etmen lazım.Repository ekleyeceksin yani
        private readonly IUnitOfWork unitOfWork;//commit eklemiştim kaydetme ve transaction işlemini bu yapıyor.
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
          this.repository = repository;
          this.unitOfWork = unitOfWork;
        }

        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();//Ben işlemlerimi yaptım veri tabanına gönder demektir.
        }
        public void UpdateCompany(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }
        public void DeleteCompany(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList(); //iquearyble old için toList metotunu kullanmam lazımdı.
        }//to list iquerayable olan koşulu veri tabanından bana getirmeye yarayan işlem
    }
}
