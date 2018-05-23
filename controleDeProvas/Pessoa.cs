using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    abstract class  Pessoa
    {
        protected string _nome;
        protected int _matricula;
        protected int _idade;

        public Pessoa(string _nome,int _matricula,int _idade)
        {
            this._nome = _nome;
            this._matricula = _matricula;
            this._idade = _idade;
        }
        public string nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        public int matricula
        {
            get { return this._matricula; }
            set { this._matricula = value; }

        }

        public int idade
        {
            get { return this._idade; }
            set { this._matricula = value; }
        }
        public override string ToString()
        {
            return "\nNome: " + nome + "\nidade: " + idade + "\nmatricula: " + matricula;
        }
    }
}
