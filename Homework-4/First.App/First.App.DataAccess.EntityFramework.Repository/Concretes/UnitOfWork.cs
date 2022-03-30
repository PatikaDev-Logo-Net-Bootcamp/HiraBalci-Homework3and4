using First.App.DataAccess.EntityFramework.Repository.Abstracts;

namespace First.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; } //abstract interface'te sadece get dediğimiz için get
        public UnitOfWork(AppDbContext context)
        {
           Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges(); //kaydedecek yaptığınız değişiklikleri.
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
