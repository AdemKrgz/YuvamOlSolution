using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.IlanService
{
    interface IIlanService
    {
        void AddIlan(Ilan item);
        void DeleteIlan(Ilan item);
        void UpdateIlan(Ilan item);

        ICollection<Ilan> TureGoreIlan(int id);
        Ilan FindById(int id);
        ICollection<Ilan> IlanGetir();
        
    }
}
