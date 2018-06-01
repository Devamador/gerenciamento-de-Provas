using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Professor:Pessoa
    {
        // Atributos

        //private string _disciplina;
        private double _salario;
        private bool _aplicada;
        private bool _provaCriada;

        public List<Disciplina> listaDisciplina { get; }//lista de disciplina do professor
        public List<Prova> prova { get; }//lista de provas criada

        /**
         * Construtor da Classe
         * */
        public Professor(string _nome, int _matricula,int _idade, double _salario):base(_nome,_matricula,_idade)
        {
            
            this._salario = _salario;
            this._aplicada = false;
            this._provaCriada = false;
            listaDisciplina = new List<Disciplina>();
            prova = new List<Prova>();
        }

        /**
         * Propriedades da Classe
         * */
       

        public double salario
        {
            get { return this._salario; }
            //set { this._salario = value; }
        }
        public bool aplicada
        {
            get { return this._aplicada; }
            set { this._aplicada = value; }
        }

        private bool provaCriada
        {
            get { return this._provaCriada; }
            set { this._provaCriada = value; }
        }


        /**
         * Metodos da Classe
         * */

        public void aplicarProva()
        {
            
            aplicada = true;
          
        }

        
        private bool corrigirProva(Aluno aluno)
        {
            if (aluno.feito == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Não pode corrigir, pois o aluno nao terminou");
                return false;
            }
                
            
        }
        /**
         * Metodos da Classe
         * */

        public void lancarNota(Prova provaAluno)
        {
            
            try
            {
             
                if (corrigirProva(provaAluno._aluno))
                {
                    double nota;
                    Console.Write("Informe a nota do aluno " + provaAluno._aluno.nome + ": ");
                    nota = double.Parse(Console.ReadLine());
                    provaAluno.nota = nota;      
                }
            }
            catch(FormatException e)
            {
                MessageBox.Show(e.Message, "Bloco Catch");
            }
        }


        public override string ToString()
        {
            return base.ToString()+/*"\ndisciplina: "+disciplina+*/"\nsalario: R$ "+salario;
        }
    }
}
