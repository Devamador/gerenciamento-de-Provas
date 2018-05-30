using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Prova
    {
        private string _data;
        private string _hora;
        public Aluno _aluno { get; set; }
        public Disciplina _disciplina { get; set; }
        private string _assunto;
        private Questoes _nQuestoes;
        private double _valor;

        private double _nota;

       // public List<Aluno> alunos { get; }

        public Prova(string _data,string _hora,Aluno _aluno, Disciplina _disciplina, string _assunto, Questoes _nQuestoes, double _valor)
        {
            this._data = _data;
            this._hora = _hora;
            this._aluno = _aluno;
            this._disciplina = _disciplina;
            this._assunto = _assunto;
            this._nQuestoes = _nQuestoes;
            this._valor = _valor;

            //alunos = new List<Aluno>();
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


        public double nota
        {
            get { return this._nota; }
            set { this._nota = value; }
        }
    }
}
