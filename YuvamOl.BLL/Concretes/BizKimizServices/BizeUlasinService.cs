using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.BizKimizServices;
using YuvamOl.DAL.Repositories.Abstracts.BizKimizRepositories;
using YuvamOl.DAL.Repositories.Concretes.BizeUlasinRepositories;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.BizKimizServices
{
    public class BizeUlasinService : BizeUlasinRepository, IBizeUlasinService
    {
        BizeUlasinRepository _bizeUlasinRepository;
        public BizeUlasinService()
        {
            _bizeUlasinRepository = new BizeUlasinRepository();
        }
        public void AddBizeUlasin(BizeUlasin item)
        {
            _bizeUlasinRepository.Add(item);
        }
    }
}
