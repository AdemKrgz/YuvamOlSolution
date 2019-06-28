using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.IlanService
{
    interface IIlanFotografService
    {
        void AddIlanFotograf(IlanFotograf item);
        void DeleteIlanFotograf(IlanFotograf item);
        void UpdateIlanFotograf(IlanFotograf item);
    }
}
