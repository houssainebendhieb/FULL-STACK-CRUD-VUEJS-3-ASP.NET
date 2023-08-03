using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonneController : ControllerBase
    {
        public IPersonneServices Context { get; }
        public PersonneController(IPersonneServices context)
        {
            this.Context = context;
            
        }
        [HttpPost("adduser")]
        public async Task<personne> Adduser(PersonneDto newPers){
            return await Context.AddPersonne(newPers);
    
        }

        [HttpPut("{id}")]
        public async Task<personne>UpdatePersonne(int id,PersonneDto newpers){
            return await Context.UpdatePersonne(id,newpers);
        }

        [HttpGet]
        public async Task<personne>GetUser(string name){

            return await Context.GetPersonne(name);

        }

        [HttpDelete("{id}")]
        public async Task<personne>DeletePersonne(int id){
            return await Context.DeletePersonne(id);
        }

    }
}