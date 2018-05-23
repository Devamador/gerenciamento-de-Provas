using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Disciplina
    {
        private string _nomeDisciplina;

        public Disciplina(string disciplina)
        {
            this._nomeDisciplina = disciplina; 
        }

        public string nomeDisciplina
        {
            get { return this._nomeDisciplina; }
            
        }
    }
}
