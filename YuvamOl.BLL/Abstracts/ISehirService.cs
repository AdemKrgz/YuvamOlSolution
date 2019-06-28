using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts
{
    interface ISehirService
    {
        ICollection<Sehir> SehirAra(string ad);
        ICollection<Sehir> SehirGetir();
    }
}
