using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class KullaniciRepository : EfRepositoryBase<Kullanici>, IKullaniciRepository
    {
        
        public List<ListKullaniciDto> GetAllKullanicilar()
        {
            using var context = new AppDbContext();
            var kullanicilar = from k in context.Kullanicilar
                               join d in context.Daireler on k.DaireId equals d.ID
                               where (k.AktifMi)
                               select new ListKullaniciDto
                               {
                                   ID =k.ID ,
                                   Ad = k.Ad,
                                   Soyad = k.Soyad,
                                   Fotograf = k.Fotograf,
                                   DaireNo = d.DaireNo,
                               
                               };
            return kullanicilar.ToList();

        }


        
        public DetailKullaniciDto GetDetailKullanici(int kullaniciId)
        {
            using var context = new AppDbContext();
            var kullanici = (from k in context.Kullanicilar
                             join d in context.Daireler on k.DaireId equals d.ID
                             where(k.ID==kullaniciId)
                             select new DetailKullaniciDto
                             {
                                 ID = k.ID,
                                 Ad = k.Ad,
                                 Soyad = k.Soyad,
                                 TCNo = k.TCNo,
                                 Fotograf = k.Fotograf,
                                 Email = k.Email,
                                 Telefon = k.Telefon,
                                 Arac = k.Arac == true ? "Var" : "Yok",
                                 Plaka = k.Plaka,
                                 DaireNo = d.DaireNo,
                                 Kat = d.Kat,
                                 DaireTipi = d.Tipi,
                                 SahibiMi = d.SahibiMi == true ? "Sahibi" : "Kiracı",

                             });
            return kullanici.SingleOrDefault();
            

        }

        
    }
}
