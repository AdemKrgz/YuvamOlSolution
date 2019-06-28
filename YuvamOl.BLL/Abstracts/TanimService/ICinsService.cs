using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.TanimService
{
    interface ICinsService
    {
        void AddCins(Cins item);
        void DeleteCins(Cins item);
        void UpdateCins(Cins item);
    }
}
