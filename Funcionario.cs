using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public partial class Funcionario
    {
        [DisplayName("Cod_Funcionario")]
        public string CodFuncionario { get; set; } = null!;

        public string Salario { get; set; } = null!;

        public string Cargo { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public DateOnly DataEntrada { get; set; }

        public string Senha { get; set; } = null!;

        public string Email { get; set; } = null!;

        //public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

        //public virtual ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
