using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.BizKimizServices
{
    public interface IGaleriForografService
    {
        void AddGaleriFotograf(GaleriFotograf item);
        void DeleteGaleriFotograf(GaleriFotograf item);

        void UpdateGaleriFotograf(GaleriFotograf item);

    }
}
