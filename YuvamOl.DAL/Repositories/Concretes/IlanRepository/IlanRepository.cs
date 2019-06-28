using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.IlanRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.IlanRepository
{
    public class IlanRepository : BaseRepository<Ilan, int>, IIlanRepository
    {
        YuvamOlDbContext _context;
        public IlanRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<Ilan> IlanGetir(string ad)
        {
            return _context.Ilan.Where(x=>x.Tur.Ad==ad).ToList();
        }

        public ICollection<Ilan> IlanGetir()
        {
            throw new NotImplementedException();
        }

        public ICollection<Ilan> SehireGoreIlanGetir(int id)
        {
            return _context.Ilan.Where(x => x.Ilce.SehirId == id).ToList();
        }

        public ICollection<Ilan> TureGoreIlanGetir(int id)
        {
            return _context.Ilan.Where(x => x.TurId == id).ToList();
        }
    }
}
