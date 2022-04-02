using System;

namespace First.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable //benim için transaction yapacak.Yanlış yapıldığı zaman rollback yapıcak ,ok gönderildinde commit edecek
    {
        //IUnitofWork doğrudan veri tabanına erişimi engeller.
        AppDbContext Context { get; }// setlemeyeyim sadece alabileyim diye get yazdık.
        void Commit();      
        
    }
}
