using APIClinica.Context;
using APIClinica.Domains;
using APIClinica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIClinica.Repositories
{
    public class PetRepository : IPet
    {
        
        //chamando a classe de conexão do banco
        ClinicaContext conexao = new ClinicaContext();

        //chamando o objeto que poderá receber e executar os comandos do banco
        SqlCommand cmd = new SqlCommand();
        public Pet Alterar(int id, Pet p)
        {
            cmd.Connection = conexao.Conectar();


            cmd.CommandText = "UPDATE Pet SET " +
               "Nome = @nome" +
               "IdPet = @idpet" +
               "Idade = @idade WHERE IdAluno = @id";

            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@idpet", p.IdPet);
            cmd.Parameters.AddWithValue("@idade", p.Idade);

            cmd.Parameters.AddWithValue("@id", id);

       
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            return p;

        }

        public Pet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Pet WHERE IdPet = @id ";

            //Atribuindo as variáveis que vem como argumento
            cmd.Parameters.AddWithValue("@id", id);

            //Start
            SqlDataReader dados = cmd.ExecuteReader();

            Pet p = new Pet();

            while (dados.Read())
            {
                p.IdPet = Convert.ToInt32(dados.GetValue(0));
                p.Nome = dados.GetValue(1).ToString();
                p.Idade   = Convert.ToInt32(dados.GetValue(3));
            }

            conexao.Desconectar();

            return p;

        }

        public Pet Cadastrar(Pet p)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Pet (Nome, IdPet, Idade) " +
                "VALUES" +
                "(@nome, @Idpet, @idade)";
            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@idpet", p.IdPet);
            cmd.Parameters.AddWithValue("@idade", p.Idade);

            // Adicionando os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return p;
            }
        

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Pet WHERE IdPet = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

        }
    

        public List<Pet> LerTodos()
        {
            //Abrindo conexão
            cmd.Connection = conexao.Conectar();

            //Preparar a Query (consulta)
            cmd.CommandText = "SELECT * FROM PET";

            //Start
            SqlDataReader dados = cmd.ExecuteReader();

            //Criando Lista para guardar os alunos

            List<Pet> pets = new List<Pet>();
            while (dados.Read())
            {
                pets.Add(
                    new Pet()
                    {
                        IdPet = Convert.ToInt32(dados.GetValue(0)),
                        Nome    = dados.GetValue(1).ToString(),
                        Idade   = Convert.ToInt32(dados.GetValue(3))
                    }
                    ) ; 
            }


            //Fechando conexão
            conexao.Desconectar();

            return pets;
        }
    }
}
