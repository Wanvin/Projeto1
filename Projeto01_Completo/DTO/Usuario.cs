using Microsoft.Data.SqlClient;
using Projeto01_Completo.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projeto01_Completo.DTO
{
    class Usuarios
    {
        public Guid Ide { get; set; }
        public int Codigo { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmeSenha { get; set; } = string.Empty;
        public int Acesso { get; set; }
        public bool Status {  get; set; }

        public bool ValidarUsuario()
        {

            string query = "Select Count(*) from Usuarios Where Usuario = @Usuario";

            using var conn = AcessoBD.Conectar();
            using var reader = new SqlCommand(query, conn);

            string[] names = new string[] { "@Usuario" };
            object[] values = new object[] { this.Usuario };
            
            AcessoBD.FillParameters(reader, names, values);
            
            int count = (int)reader.ExecuteScalar();
            AcessoBD.Desconectar();
           
            return count > 0;        
                       
        }  
    }
}
