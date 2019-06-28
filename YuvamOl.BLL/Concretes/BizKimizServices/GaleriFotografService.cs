using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.BizKimizServices;
using YuvamOl.DAL.Repositories.Concretes.BizeUlasinRepositories;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.BizKimizServices
{
    public class GaleriFotografService : GaleriFotografRepository, IGaleriForografService
    {
        GaleriFotografRepository _galeriFotografRepository;

        public GaleriFotografService()
        {
            _galeriFotografRepository = new GaleriFotografRepository();

        }

        public void AddGaleriFotograf(GaleriFotograf item)
        {
            
            _galeriFotografRepository.Add(item);
        }

        public void DeleteGaleriFotograf(GaleriFotograf item)
        {
            _galeriFotografRepository.Delete(item.Id);
        }
        
        public void UpdateGaleriFotograf(GaleriFotograf item)
        {
            _galeriFotografRepository.Update(item);
        }
    }
}
