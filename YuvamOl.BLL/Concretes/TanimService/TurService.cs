using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.TanimService;
using YuvamOl.DAL.Repositories.Concretes.TanimRepository;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.TanimService
{
    public class TurService : TurRepository, ITurService
    {
        TurRepository _turRepository;
        public TurService()
        {
            _turRepository = new TurRepository();
        }
        public void AddTur(Tur item)
        {
            _turRepository.Add(item);
        }

        public void DeleteTur(Tur item)
        {
            _turRepository.Delete(item.Id);
        }

        public void UpdateTur(Tur item)
        {
            _turRepository.Update(item);
        }
    }
}
