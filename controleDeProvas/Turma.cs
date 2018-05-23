using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Turma
    {
        private int _numSala;

        private static int total = 50;

        public List<Aluno> listaAlunos { get; }

        public Turma()
        {
            this._numSala = 6403;
            listaAlunos = new List<Aluno>();       
        }

        public int numSala
        {
            get { return this._numSala; }
            set { this._numSala = value; }
        }

        public void addAluno(Aluno aluno)
        {
            if (listaAlunos.Count != total)
                listaAlunos.Add(aluno);
            else
                Console.WriteLine("Sala lotada!!");

        }
        
        /*Aluno dadoAluno;

        public void inserirAluno(Aluno aluno)
        {

            if (dadoAluno == null)
                dadoAluno = aluno;
            else
            {
                Aluno tmp = dadoAluno;
                while (tmp.prox != null)
                    tmp = tmp.prox;

                tmp.prox = aluno;
            }
        }

        public void mostrarAluno()
        {
            
            Aluno tmp = dadoAluno;
            if (dadoAluno == null)
                Console.WriteLine("Turma esta vazia!!");
            else
            {
                string output;
                output = "\n -" + tmp.nome;
                tmp = tmp.prox;
                while (tmp != null)
                {
                    output += "\n -" + tmp.nome;
                    //Console.WriteLine("Aluno: " + tmp.nome);
                    tmp = tmp.prox;
                }

                System.Windows.Forms.MessageBox.Show(output, "Lista de alunos: ");
            }
            
                
        }*/
    }
}
