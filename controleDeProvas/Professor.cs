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

        public List<Disciplina> listaDisciplina { get; }

        /**
         * Construtor da Classe
         * */
        public Professor(string _nome, int _matricula,int _idade,/*string _disciplina,*/ double _salario):base(_nome,_matricula,_idade)
        {
            //this._disciplina = _disciplina;
            this._salario = _salario;
            this._aplicada = false;
            this._provaCriada = false;
            listaDisciplina = new List<Disciplina>();
        }

        /**
         * Propriedades da Classe
         * */
        /*public string disciplina
        {

            get { return this._disciplina; }
            set { this._disciplina = value; }
        }*/

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
            
            if (provaCriada)
                aplicada = true;
            else
                Console.WriteLine("Nenhuma prova foi criada!!");
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

        public void lancarNota(Provao provaAluno)
        {
            
            try
            {
                 for (int i = 0; i < provaAluno.aluno.Count; i++)
                 {
                    if (corrigirProva(provaAluno.aluno[i]))
                    {
                        float nota;
                        Console.Write("Informe a nota do aluno " + provaAluno.aluno[i].nome + ": ");
                        nota = float.Parse(Console.ReadLine());
                        provaAluno.aluno[i].minhasProvas[0].nota = nota;
                    }
                    
                 }
            }
            catch(FormatException e)
            {
                MessageBox.Show(e.Message, "Bloco Catch");
            } 
          
        }

       public Provas criarProva()
        {
            int op;
            string assunto;
            Questoes questoes = new Questoes();
            questoes.nDiscursivas = 5;
            questoes.nObjetivas = 5;
            Console.Write("Disciplina: ");
            for(int i = 0; i<listaDisciplina.Count;i++)
                Console.WriteLine("[{0}] {1}",(i +1),listaDisciplina[i].nomeDisciplina);
            op = int.Parse(Console.ReadLine());
            Console.Write("Assunto: ");
            assunto = Console.ReadLine();
            Provas prova = new Provas(listaDisciplina[op - 1], assunto,questoes,10);
            
            provaCriada = true;

            return prova;
       }

        public override string ToString()
        {
            return base.ToString()+/*"\ndisciplina: "+disciplina+*/"\nsalario: R$ "+salario;
        }
    }
}
