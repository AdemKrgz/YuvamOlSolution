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
    public class IlanDetayRepository : BaseRepository<IlanDetay, int>, IIlanDetayRepository
    {
        YuvamOlDbContext _context;
        public IlanDetayRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<IlanDetay> SehireGoreIlanGetir(int id)
        {
            return _context.IlanDetay.Where(x => x.Ilce.SehirId == id).ToList();
        }
    }
}
