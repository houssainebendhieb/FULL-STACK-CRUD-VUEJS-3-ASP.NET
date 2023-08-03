using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.PersonneServices
{
    public interface IPersonneServices
    {
        public Task<personne> AddPersonne(PersonneDto newPers);
        public Task<personne> DeletePersonne(int id);

        public Task<personne> UpdatePersonne(int id,PersonneDto newpers);
        public Task<personne> GetPersonne(string name);
        

    }
}