using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.PersonneServices
{
    public class PersonneServices : IPersonneServices
    {
        private readonly DataContext context;
        public PersonneServices(DataContext context)
        {
            this.context = context;
            
        }
        public async Task<personne> AddPersonne(PersonneDto newPers)
        {
            personne pers=new personne();
            pers.age=newPers.age;
            pers.Name=newPers.Name;
            context.Add(pers);
            await context.SaveChangesAsync();
            return pers;
        }

        public async Task<personne> DeletePersonne(int id)
        {
            var pers=await  context.Personnes.FirstOrDefaultAsync(c=>c.id==id);
              context.Personnes.Remove(pers!);
            return pers;
        }

        public async Task<personne> GetPersonne(string name)
        {
            var pers=await context.Personnes.FirstOrDefaultAsync(c=>c.Name==name);
            return pers!;
        }

        public async Task<personne> UpdatePersonne(int id)
        {
            throw new NotImplementedException();
        }
    }
}