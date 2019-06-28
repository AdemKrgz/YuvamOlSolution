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
    public class IlanFotografService : IlanRepository, IIlanFotografService
    {
        IlanFotografRepository _ilanFotografRepository;
        public IlanFotografService()
        {
            _ilanFotografRepository = new IlanFotografRepository();
        }
        public void AddIlanFotograf(IlanFotograf item)
        {
            _ilanFotografRepository.Add(item);
        }

        public void DeleteIlanFotograf(IlanFotograf item)
        {
            _ilanFotografRepository.Delete(item.Id);
        }

        public void UpdateIlanFotograf(IlanFotograf item)
        {
            _ilanFotografRepository.Update(item);
        }
    }
}
