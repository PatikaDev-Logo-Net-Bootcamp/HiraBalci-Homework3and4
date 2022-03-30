using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace First.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity); //unitofwork ekleme işlemi yapıcak.Add kullanılıyor verilen entity 'i kullanmam için gereken metot
        }

        public void Delete(T entity)
        {
            T exist = unitOfWork.Context.Set<T>().Find(entity.Id);//önce var mı diye sorucaksın.Önce git entitydeki id yi bul
            //id çıkıyor base entity den ötürü
            if (exist != null)//null değilse
            {
                exist.IsDeleted = true;//verinin state ini değiştirdik.Veriyi silmedik.Silindi olarak gösterdik.
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;//entity nin durumunu modied yaptık yani değiştirildi dedik.
            }
        }

        public IQueryable<T> Get()
        {
            return unitOfWork.Context.Set<T>().Where(x=> !x.IsDeleted).AsQueryable();//isdeleted false olanları getir dedik.Sürekli trueis deme sürekli veri tabanına gider ve performans kalitesini azaltmış olursunuz.
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
