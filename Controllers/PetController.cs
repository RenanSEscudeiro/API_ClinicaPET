using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIClinica.Domains;
using APIClinica.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        //Chamar o repositório pet
        PetRepository repo = new PetRepository();

        // GET: api/Pet
        [HttpGet]
        public List<Pet> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/Pet
        [HttpPost]
        public Pet Post([FromBody] Pet novoPet)
        {
            return repo.Cadastrar(novoPet);
        }

        // PUT: api/Pet/5
        [HttpPut("{id}")]
        public Pet Put(int id, [FromBody] Pet p)
        {
            return repo.Alterar(id, p);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
