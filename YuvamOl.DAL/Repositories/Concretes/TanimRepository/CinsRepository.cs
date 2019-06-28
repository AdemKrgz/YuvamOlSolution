using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.TanimRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.TanimRepository
{
    public class CinsRepository:BaseRepository<Cins,int>,ICinsRepository
    {
        YuvamOlDbContext _context;
        public CinsRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<Cins> CinsGetir()
        {
            return _context.Cins.ToList();
        }
        public ICollection<Cins> CinsGetir(string ad)
        {
            return _context.Cins.Where(x => x.Ad.StartsWith(ad)).ToList();
        }

        public ICollection<Cins> HarfeGoreCinsGetir(string ad,int turId)
        {
            return _context.Cins.Where(x => x.Ad.StartsWith(ad)&& x.Tur.Id==turId ).ToList();
        }

        public ICollection<Cins> HarfeGoreCinsGetir(string ad)
        {
            return _context.Cins.Where(x => x.Ad.StartsWith(ad)).ToList();
        }
    }
}
