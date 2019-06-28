using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts;
using YuvamOl.DAL.Repositories.Concretes.TanimRepository;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.TanimService
{
    public class SehirService : SehirRepository, ISehirService
    {
        SehirRepository _sehirRepository;
        public SehirService()
        {
            _sehirRepository = new SehirRepository();
        }

        public ICollection<Sehir> SehirGetirService()
        {
            return _sehirRepository.SehirGetir().ToList();
        }

        public ICollection<Sehir> SehirleriAra(string ad)
        {
            return _sehirRepository.SehirAra(ad).ToList();
        }
    }
}
