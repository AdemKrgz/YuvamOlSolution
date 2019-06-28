using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.GonulluOlService;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Concretes.GonullOlRepositories;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.GonulluOlService
{
    public class GonulluOlService : IGonulluOlService
    {
        GonulluOlRepository _gonulluOlRepository;
        public GonulluOlService()
        {
            _gonulluOlRepository = new GonulluOlRepository();
        }
        public void AddGonulluOlService(GonulluOl item)
        {
            _gonulluOlRepository.Add(item);
        }
        public ICollection<GonulluOl> gonulluGetir()
        {
            return _gonulluOlRepository.GonulluOlGetir();
        }
    }
}
