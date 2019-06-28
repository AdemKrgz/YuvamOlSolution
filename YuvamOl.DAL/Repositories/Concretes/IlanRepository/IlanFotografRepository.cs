using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.Repositories.Abstracts.IlanRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.IlanRepository
{
    public class IlanFotografRepository:BaseRepository<IlanFotograf,int>,IIlanFotografRepository
    {
    }
}
