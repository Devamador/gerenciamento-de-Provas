using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Opcao
    {
        Turma turma1 = new Turma();

        List<Professor> listaProfessor = new List<Professor>();//lista de todos os professores

        List<Prova> listaProvas = new List<Prova>();//lista de todas as provas criadas

        private int op, opProf;
        private int idade, matricula;
        private string nome, curso, disciplina, data, hora, assunto;
        private double salario;
        private bool achou;

        Menu menu = new Menu();
        public Opcao()
        {
            confere();
            this.achou = false;
        }

        public void confere()
        {

            switch (menu.desenharMenu())
            {
                case 1:
                    Console.Write("Nome: ");
                    this.nome = Console.ReadLine();
                    Console.Write("Curso: ");
                    this.curso = Console.ReadLine();
                    Console.Write("Idade: ");
                    this.idade = int.Parse(Console.ReadLine());
                    Console.Write("Matricula: ");
                    this.matricula = int.Parse(Console.ReadLine());
                    Aluno aluno = new Aluno(this.nome, this.matricula, this.idade, this.curso);
                    turma1.addAluno(aluno);

                    Console.WriteLine("Aluno cadastrado");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    Console.Write("Nome: ");
                    this.nome = Console.ReadLine();
                    Console.Write("Salario: ");
                    this.salario = double.Parse(Console.ReadLine());
                    Console.Write("Idade: ");
                    this.idade = int.Parse(Console.ReadLine());
                    Console.Write("Matricula: ");
                    this.matricula = int.Parse(Console.ReadLine());
                    Professor prof = new Professor(this.nome, this.matricula, this.idade, this.salario);
                    do
                    {
                        Console.Write("Disciplina: ");
                        this.disciplina = Console.ReadLine();
                        Disciplina disc = new Disciplina(disciplina);
                        prof.listaDisciplina.Add(disc);
                        Console.Write("Deseja adicionar outra disciplina para o Professor " + prof.nome + "[1]SIM [2] NAO");

                        this.op = int.Parse(Console.ReadLine());
                    } while (this.op != 2);

                    listaProfessor.Add(prof);//adiciona o professor na lista de professores
                    Console.WriteLine("Professor {0} CADASTRADO COM SUCESSO", prof.nome);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    if (listaProfessor.Count != 0)
                    {
                        Console.WriteLine("Acessar como: ");
                        for (int i = 0; i < listaProfessor.Count; i++)
                        {
                            Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[i].nome);
                        }
                        this.opProf = int.Parse(Console.ReadLine());
                        Questoes questoes = new Questoes();
                        questoes.nDiscursivas = 5;
                        questoes.nObjetivas = 5;
                        Console.Write("Data da prova: ");
                        this.data = Console.ReadLine();
                        Console.Write("Hora: ");
                        this.hora = Console.ReadLine();
                        Console.Write("Disciplina: ");
                        for (int i = 0; i < listaProfessor[opProf - 1].listaDisciplina.Count; i++)
                        {
                            
                            Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[opProf - 1].listaDisciplina[i].nomeDisciplina);
                        }
                            
                        this.op = int.Parse(Console.ReadLine());
                        Console.Write("Assunto: ");
                        this.assunto = Console.ReadLine();

                        for (int i = 0; i < turma1.listaAlunos.Count; i++)
                        {
                            //cria uma prova para cada aluno
                            Prova prova = new Prova(data, hora, turma1.listaAlunos[i], listaProfessor[opProf - 1].listaDisciplina[op - 1], assunto, questoes, 10);
                            turma1.listaAlunos[i].minhasProvas.Add(prova);
                            if (i == 0)
                                listaProfessor[opProf - 1].prova.Add(prova);

                            listaProvas.Add(prova);
                        }

                        Console.WriteLine("Prova Criada");
                        listaProfessor[opProf - 1].aplicarProva();//professor aplica a prova
                        turma1.listaAlunos.ForEach(i => i.fazerProva(listaProfessor[opProf - 1]));//os alunos fazem as provas

                    }
                    else
                    {
                        Console.WriteLine("Lista de Professor vazia!!");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 4:
                    if (listaProvas.Count != 0)
                    {
                        Console.WriteLine("Acessar como: ");
                        for (int i = 0; i < listaProfessor.Count; i++)
                        {
                            if (listaProfessor[i].prova.Count > 0)
                            {
                                //mostra somente os professores que tem notas para lançar
                                Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[i].nome);
                                this.achou = true;
                            }    
                        }
                        if (!this.achou)
                        {
                            Console.WriteLine("Nenhum professor tem notas para lançar");
                            Console.ReadKey();

                            return;
                        }

                                

                        this.opProf = int.Parse(Console.ReadLine());
                        Console.Write("Lançar nota da disciplina: ");
                        for (int i = 0; i < listaProfessor[this.opProf - 1].prova.Count; i++)
                            Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[this.opProf - 1].prova[i]._disciplina.nomeDisciplina);
                        this.op = int.Parse(Console.ReadLine());


                        for (int i = 0; i < turma1.listaAlunos.Count; i++)
                        {
                            for (int j = 0; j < turma1.listaAlunos[i].minhasProvas.Count; j++)
                            {
                                //lança a nota para cada aluno que fez a prova
                                if (listaProfessor[this.opProf - 1].prova[this.op - 1].assunto.Equals(turma1.listaAlunos[i].minhasProvas[j].assunto))
                                    listaProfessor[this.opProf - 1].lancarNota(turma1.listaAlunos[i].minhasProvas[j]);
                            }

                        }

                        for (int i = 0; i < listaProfessor[this.opProf - 1].prova.Count; i++)
                        {
                            //exclui a prova que o professor acabou de lançar nota  da sua lista
                            if (listaProfessor[this.opProf - 1].prova[i].assunto.Equals(listaProfessor[this.opProf - 1].prova[this.op - 1].assunto))
                                listaProfessor[this.opProf - 1].prova.Remove(listaProfessor[this.opProf - 1].prova[i]);
                        }

                        /*foreach(Prova p in (listaProfessor[opProf - 1].prova))
                        {
                            if (p.assunto.Equals(listaProfessor[opProf - 1].prova[op - 1].assunto))
                                listaProfessor[opProf - 1].prova.Remove(p);
                        }*/


                    }
                    else
                    {
                        Console.WriteLine("Nenhuma prova criada!!");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 5:
                    Console.WriteLine("Alunos da turma " + turma1.numSala);
                    turma1.listaAlunos.ForEach(i => Console.WriteLine("  -" + i.nome));//imprime o nome de cada aluno
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 6:
                    foreach (Professor disciplinas in listaProfessor)//pecorre a lista de professores
                    {
                        Console.WriteLine("Lista de disciplinas do professor " + disciplinas.nome);
                        disciplinas.listaDisciplina.ForEach(i => Console.WriteLine("  -" + i.nomeDisciplina));//imprime as disciplina do professor
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 7:
                    foreach (Aluno a in turma1.listaAlunos)//pecorre a lista de alunos
                    {
                        Console.WriteLine("Notas do aluno " + a.nome);
                        //imprime o nome da disciplina e a nota do aluno na forma decimal
                        a.minhasProvas.ForEach(i => Console.WriteLine(String.Format("  -{0}: {1:F}", i._disciplina.nomeDisciplina, i.nota)));
                        Console.WriteLine();
                    }

                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 0:
                    System.Windows.Forms.MessageBox.Show("Fechando aplicativo ...");
                    Environment.Exit(1);//fecha o aplicativo
                        
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show("Opção invalida!", "ERRO");
                    break;
            }
           
        }
    }
}
