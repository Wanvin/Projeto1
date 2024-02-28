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
                    return "Campo Usuário Vázio";                    
                case 2:
                    return " ";
                default:
                    return " Default";                  
            
            
            }
            
          
        
        }

    }
}
