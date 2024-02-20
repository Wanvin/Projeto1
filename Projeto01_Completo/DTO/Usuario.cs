using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01_Completo.DTO
{
    class Usuarios
    {
        public Guid Ide { get; set; }
        public int Codigo { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public int Acesso { get; set; }
        public bool Status {  get; set; }
    }
}
