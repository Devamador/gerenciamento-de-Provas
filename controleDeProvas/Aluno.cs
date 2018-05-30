using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Aluno:Pessoa
    {
        private string _curso;
        // private int _turma;
        private bool _feito;
        //private double _nota;

        
        public List<Prova> minhasProvas { get; }
         

        //public List<Turma> minhaTurma { get; }

        /**
         * Construtor da Classe
         * */
        public Aluno(string _nome, int _matricula, int _idade, string _curso):base(_nome,_matricula,_idade)
        {
        
            this._curso = _curso;
            this._feito = false;

            minhasProvas = new List<Prova>();
        }

        /**
         * Propriedades dos atributos da classe
         * */
        public string curso
        {
            get { return this._curso; }
            set { this._curso = value; }
        }

        public bool feito
        {
            get { return this._feito; }
            set { this._feito = value; }
        }
        
        /**
         * Metodos da classe
         * */
        public void fazerProva(Professor _aplicada)
        {
            if (_aplicada.aplicada == true)
            {
               // Console.WriteLine("Pode fazer prova!!");
                feito = true;
            }  
            else
            {
                Console.WriteLine("Professor ainda nao aplicou a prova!!");
            }    
        }

        public override string ToString()
        {
            return base.ToString()+ "\nCurso: "+curso;
        }

    }
}
