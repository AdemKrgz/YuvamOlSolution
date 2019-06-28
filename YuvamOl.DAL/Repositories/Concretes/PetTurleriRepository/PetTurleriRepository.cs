using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.PetTurleriRepositories;
using YuvamOl.DAL.Repositories.Concretes.Core;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.Repositories.Concretes.PetTurleriRepository
{
    public class PetTurleriRepository:BaseRepository<Tur,int >,IPetTurleriRepository
    {
        YuvamOlDbContext _context;
        public PetTurleriRepository()
        {
            _context = new YuvamOlDbContext();
        }
        public ICollection<Tur> HarfeGoreHayvanGetir( string ad)
        {
            return _context.Tur.Where(x => x.Ad.StartsWith(ad)).ToList();
           
        }
        public ICollection<Tur> IlanaGoreHayvanGetir(string ad)
        {
            return _context.Tur.Where(x => x.Ad == ad).ToList();
        }

        public ICollection<Tur> PetTurleriGetir()
        {
            return _context.Tur.ToList();
        }
    }
}
