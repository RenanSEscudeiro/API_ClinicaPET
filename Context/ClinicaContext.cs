using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIClinica.Context
{
    public class ClinicaContext
    {
        SqlConnection con = new SqlConnection();
        public ClinicaContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-UTGRE9J\SQLEXPRESS;Initial Catalog=clinicadoguinhofeliz;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
          
        }
    }
}
