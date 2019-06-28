using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.TanimService
{
    interface ITurService
    {
        void AddTur(Tur item);
        void DeleteTur(Tur item);
        void UpdateTur(Tur item);
    }
}
