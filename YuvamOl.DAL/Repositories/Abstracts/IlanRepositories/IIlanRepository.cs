using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.Repositories.Abstracts.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Abstracts.IlanRepositories
{
    public interface IIlanRepository : IBaseRepository<Ilan, int>
    {
        ICollection<Ilan> IlanGetir(string ad);
        ICollection<Ilan> SehireGoreIlanGetir(int id);
        ICollection<Ilan> TureGoreIlanGetir(int id);
    }
}
