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
            if(pers is null)
                throw new Exception("user not found with this id :{"+id+"}");
            context.Personnes.Remove(pers);
            await context.SaveChangesAsync();
            return pers!;
        }

        public async Task<personne> GetPersonne(string name)
        {
            var pers=await context.Personnes.FirstOrDefaultAsync(c=>c.Name==name);
            if( pers is null)
                throw new Exception("user not found with this name :{"+name+"}");
            return pers;
        }

        public async Task<personne> UpdatePersonne(int  id,PersonneDto newpers)
        {
            var pers=await context.Personnes.FirstOrDefaultAsync(c=>c.id==id);
            if(pers ==null )
                throw new Exception("user not found with this id : {"+id+"}");
            pers.age=newpers.age;
            pers.Name=newpers.Name;
            await context.SaveChangesAsync();
            return pers;

        }
    }
}