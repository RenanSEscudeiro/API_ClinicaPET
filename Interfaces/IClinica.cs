using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIClinica.Domains;

namespace APIClinica.Interfaces
{
    interface IPet
    {
        Pet Cadastrar(Pet a);
        List<Pet> LerTodos();
        Pet BuscarPorId(int id);
        Pet Alterar(int id, Pet a);
        void Excluir(int id);
   
    }
}
