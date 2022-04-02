using System;
using System.Collections.Concurrent;


namespace BackgroundQueue.API.Background
{
    public interface IBackgroundQueue<T> //interface oluşturdum
    //sadece book almasın generic repository de göstermiştim generic interface  vereceğim hangi clası veririsem o classın bana kuyruk yapısı oluşturmasını istiyorum 
    {
        void Enqueue(T item);// bana burda verdiğim para metreden gelen item .işlemi kuyruğa koyulacak olan metot
        T Dequeue();//parametre almayacak.buda kuyruktan çıkaracak
    }
    public class BackgroundQueue<T> : IBackgroundQueue<T> where T : class //kısıtlamalarını yazdım
    {
        private readonly ConcurrentQueue<T> _items = new ConcurrentQueue<T>();//kuyruklama işlemi yapan bir sınıf fifo bana ordaki kuyruk yapısını sağlayacak. 
        public T Dequeue()//implement ettim
        {
            var success = _items.TryDequeue(out var workItem);//işlemin sonucunda yukarıda ki items dan try queqe yaptığım işlemi queue dan elemanı mı çıkaracağım 
            return success ? workItem : null;//bana dön eğer true ise work item değilse null
        }

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));// itemı kontrol ett null mı diye null ise throw ile beraber exception fırlat.
            _items.Enqueue(item);// item a gidip enququ ya ekleyecek
        }
    }
}
