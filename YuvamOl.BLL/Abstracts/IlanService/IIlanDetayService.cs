using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.IlanService
{
    interface IIlanDetayService
    {
        void AddIlanDetay(IlanDetay item);
        void DeleteIlanDetay(IlanDetay item);
        void UpdateIlanDetay(IlanDetay item);
        IlanDetay FindByIdIlanDetay(int id);
       

    }
}
