using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.GonulluOlRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.GonullOlRepositories
{
    public class GonulluOlRepository : BaseRepository<GonulluOl, int>, IGonulluOlRepository
    {
        YuvamOlDbContext _context;
        public GonulluOlRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<GonulluOl> GonulluOlGetir()
        {
            return _context.GonulluOl.ToList();
        }
    }
}
