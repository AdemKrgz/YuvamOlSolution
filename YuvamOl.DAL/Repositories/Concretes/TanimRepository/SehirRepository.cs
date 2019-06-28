using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.TanimRepository
{
    public class SehirRepository:BaseRepository<Sehir,int>,ISehirRepository
    {
        YuvamOlDbContext _context;
        public SehirRepository()
        {
            _context = new YuvamOlDbContext();
        }

        public ICollection<Sehir> SehirGetir()
        {
            return _context.Sehir.ToList();
        }

        public ICollection<Sehir>SehirAra(string ad)
        {
            ad = ad.ToUpper();
            
            return _context.Sehir.Where(x => x.Ad.StartsWith(ad)).ToList();
        }
    }
}
