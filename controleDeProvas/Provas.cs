using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Provas
    {
        public Disciplina _disciplina { get; set; }
        private string _assunto;
        private Questoes _nQuestoes;
        private double _valor;

        public Provas(string assunto, double valor)
        {
            this._assunto = assunto;
            this._valor = valor;
        }

        

        public Provas(Disciplina _disciplina,string _assunto,Questoes _nQuestoes, double _valor)
        {
            this._disciplina = _disciplina;
            this._disciplina = _disciplina;
            this._assunto = _assunto;
            this._nQuestoes = _nQuestoes;
           
            this._valor = _valor;
           
        }

        public Disciplina disciplina
        {
            get { return this._disciplina; }
        }

        public string assunto
        {
            get { return this._assunto; }
            set { this._assunto = value; }

        }

        public double valor
        {
            get { return this._valor; }
            set { this._valor = value; }
        }

        public Questoes questoes
        {
            get
            {
                return this._nQuestoes;
            }
            set
            {
                this._nQuestoes = value;
            }
        }

        public override string ToString()
        {
            return "Assunto: "+assunto+"\nvalor: "+valor;
        }
    }
}
