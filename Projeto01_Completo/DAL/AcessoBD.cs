using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01_Completo.DAL
{
    class AcessoBD
    {
                
        private static SqlConnection? conn;
       
        public static SqlConnection Conectar()
        {
            conn = new("Server = localhost\\SQLEXPRESS; Database = ProjetoCompleto; Trusted_Connection = True; Encrypt=False;");
            conn.Open();
            return conn;
        }
        public static SqlConnection Desconectar()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close();
            return conn;
        }

        // Testes de novos modos de uso do bd 

        internal static void ExecutarCommand(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        internal static SqlDataReader Read(SqlCommand command)
        {
            return command.ExecuteReader();
        }

        /* Teste Add Values via método, visto no projeto do Lucas.
        Armazena os nomes dos campos e o valores em arrays
        Verifica se Names tem pelo menos 1 elemento, se sim, verifica se values também tem pelo menos 1 elemento, se sim, verifica se names e values tem mesmo tamanho.
        Se alguma expressão anterior estiver incorreta, lança a exception. Se estiver tudo correto, pula o loop e executa o for.
        */
        internal static void FillParameters(SqlCommand command, string[] names, object[] values)
        {
            if (names.Length <= 0 || values.Length <= 0 || names.Length != values.Length)
            {
                throw new Exception();
               
            }

            for (int i = 0; i < names.Length; i++)
            {
                command.Parameters.AddWithValue(names[i], values[i]);
            }
        }
    }
}
