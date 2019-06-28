using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.BLL.Abstracts.PetTurleriService;
using YuvamOl.DAL.Repositories.Concretes.PetTurleriRepository;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Concretes.PetTurleriService
{
    public class PetTurleriService : PetTurleriRepository, IPetTurleriService
    {
        PetTurleriRepository _petTurleriRepository;
        public PetTurleriService()
        {
            _petTurleriRepository = new PetTurleriRepository();
        }
        public void AddPetTurleri(Tur item)
        {
            _petTurleriRepository.Add(item);
        }

        public void DeletePetTurleri(Tur item)
        {
            _petTurleriRepository.Delete(item.Id);
        }

        public ICollection<Tur> IlanaGoreHayvanlariGetir(string ad)
        {
            return _petTurleriRepository.IlanaGoreHayvanGetir(ad);
        }

        public ICollection<Tur> PetTurHarfeGoreGetir(string ad)
        {
            return _petTurleriRepository.HarfeGoreHayvanGetir(ad).ToList();
        }

        public ICollection<Tur> PetTurleriniGetir()
        {
            return _petTurleriRepository.PetTurleriGetir().ToList();
        }

        public void UpdatePetTurleri(Tur item)
        {
            _petTurleriRepository.Update(item);
        }

    }
}
