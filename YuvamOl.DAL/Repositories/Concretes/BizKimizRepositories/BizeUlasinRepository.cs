using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.BizKimizRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.BizeUlasinRepositories
{
    public class BizeUlasinRepository:BaseRepository<BizeUlasin,int>,IBizeUlasinRepository
    {
        YuvamOlDbContext _context;
        public BizeUlasinRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<BizeUlasin> BizeUlasinGetir()
        {
            return _context.BizeUlasin.ToList();
        }
    }
}
