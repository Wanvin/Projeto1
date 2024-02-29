using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01_Completo.DAL
{
    internal class ExceptionBook
    {

        public static string ExceptionConsultar(int i) 
        {
            switch (i) 
            
            {
                case 1:
                    return "O usuário não foi preeenchido!";                    
                case 2:
                    return "A senha não foi preenchida!";
                case 3:
                    return "Confirmação de senha não foi preenchido";
                default:
                    return "Erro ao efetuar operação!";                  
            
            
            }
            
          
        
        }

    }
}
