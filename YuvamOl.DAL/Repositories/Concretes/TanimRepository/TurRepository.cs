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
    public class TurRepository:BaseRepository<Tur,int>,ITurRepository
    {
        YuvamOlDbContext _context;
        public TurRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<Tur> TurGetir()
        {
            return _context.Tur.ToList();
        }
    }
}
