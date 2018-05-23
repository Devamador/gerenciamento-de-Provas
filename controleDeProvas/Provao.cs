using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Provao
    {
        private string _data;
        private string _hora;
        //private Aluno _nomeAluno;
        private Provas _dadosProva;
        //private Disciplina _disciplina;
        
        private double _nota;

        public List<Aluno> aluno { get; } 
       
        public Provao(string data,string hora/*,Aluno nomeAluno*/,Provas dadosProva)
        {
            
            this._data = data;
            this._hora = hora;
            //this._nomeAluno = nomeAluno;
            this._dadosProva = dadosProva;
            aluno = new List<Aluno>();
        }

        public string data
        {
         
            get { return this._data; }
            set { this._data = value; }
        }

        public string hora
        {
            get { return this._hora; }
            set { this._hora = value; }
        }

        /*public Aluno nomeAluno
        {
            get { return this._nomeAluno; }
            set { this._nomeAluno = value; }

        }*/

        public Provas dadosProva
        {
            get { return this._dadosProva; }
            set { this._dadosProva = value; }
        }

        public double nota
        {
            get { return this._nota; }
            set { this._nota = value; }
        }

        /*public override string ToString()
        {
            return "";
        }*/

    }
}
