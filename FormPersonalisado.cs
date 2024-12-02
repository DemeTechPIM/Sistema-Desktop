using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class FormPersonalisado : Form
    {
        static String connstring = "";
        private Funcionario? funcionario;
        public FormPersonalisado() { }
        public FormPersonalisado(String connstring)
        {
            //this.connstring = connstring;
        }
        public FormPersonalisado(Funcionario funcionario)
        {
            this.funcionario = funcionario;
        }
        public FormPersonalisado(Funcionario funcionario, String connstring)
        {
            this.funcionario = funcionario;
            //this.connstring = connstring;
        }
    }
}
