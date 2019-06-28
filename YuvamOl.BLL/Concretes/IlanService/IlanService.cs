using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.IlanService;
using YuvamOl.DAL.Repositories.Concretes.IlanRepository;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.IlanService
{
    public class IlanService : IlanRepository, IIlanService
    {
        IlanRepository _ilanRepository;
        public IlanService()
        {
            _ilanRepository = new IlanRepository();
        }
        public void AddIlan(Ilan item)
        {
            _ilanRepository.Add(item);
        }

        public void DeleteIlan(Ilan item)
        {
            _ilanRepository.Delete(item.Id);
        }

        public Ilan FindById(Ilan item)
        {
            return _ilanRepository.FindById(item.Id);
        }

        public void UpdateIlan(Ilan item)
        {
            _ilanRepository.Update(item);
        }
        public void Sayfalama(int i)
        {
            _ilanRepository.IlanGetir().Skip(i).Take(10).ToList();
        }

        public ICollection<Ilan> TureGoreIlan(int id)
        {
            return _ilanRepository.TureGoreIlanGetir(id);
        }
    }
}
