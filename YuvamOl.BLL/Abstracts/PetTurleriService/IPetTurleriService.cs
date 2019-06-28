using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.BLL.Abstracts.PetTurleriService
{
    interface IPetTurleriService
    {
        void AddPetTurleri(Tur item);
        void DeletePetTurleri(Tur item);
        void UpdatePetTurleri(Tur item);
        ICollection<Tur> PetTurHarfeGoreGetir(string ad);
        ICollection<Tur> IlanaGoreHayvanGetir(string ad);
        ICollection<Tur> PetTurleriGetir();
    }
}
