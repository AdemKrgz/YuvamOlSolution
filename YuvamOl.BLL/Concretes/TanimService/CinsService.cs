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
    public class CinsService : CinsRepository, ICinsService
    {
        CinsRepository _cinsRepository;
        public CinsService()
        {
            _cinsRepository = new CinsRepository();
        }
        public void AddCins(Cins item)
        {
            _cinsRepository.Add(item);
        }

        public void DeleteCins(Cins item)
        {
            _cinsRepository.Delete(item.Id);
        }

        public void UpdateCins(Cins item)
        {
            _cinsRepository.Update(item);
        }
        public List<Cins> CinsleriGetir()
        {
            return _cinsRepository.WhereSelect().ToList();
        }
    }
}
