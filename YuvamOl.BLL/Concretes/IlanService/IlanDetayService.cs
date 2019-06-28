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
    public class IlanDetayService : IlanDetayRepository, IIlanDetayService
    {
        IlanDetayRepository _ilanDetayRepository;
        public IlanDetayService()
        {
            _ilanDetayRepository = new IlanDetayRepository();
        }
        public void AddIlanDetay(IlanDetay item)
        {
            _ilanDetayRepository.Add(item);
        }

        public void DeleteIlanDetay(IlanDetay item)
        {
            _ilanDetayRepository.Delete(item.Id);
        }

        public IlanDetay FindByIdIlanDetay(int id)
        {
            return _ilanDetayRepository.FindById(id);
        }
        public void UpdateIlanDetay(IlanDetay item)
        {
            _ilanDetayRepository.Update(item);
        }
    }
}
