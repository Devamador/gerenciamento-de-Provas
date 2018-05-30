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

        List<Disciplina> listDisciplinas = new List<Disciplina>();//lista de todas as diciplinas

        int op, opProf;
        int idade, matricula;
        string nome, curso, disciplina, data, hora, assunto;
        double salario;

        Menu menu = new Menu();
        public Opcao()
        {
            confere();        
        }

        public void confere()
        {
        


                switch (menu.desenharMenu())
                {
                    case 1:
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Curso: ");
                        curso = Console.ReadLine();
                        Console.Write("Idade: ");
                        idade = int.Parse(Console.ReadLine());
                        Console.Write("Matricula: ");
                        matricula = int.Parse(Console.ReadLine());
                        Aluno aluno = new Aluno(nome, matricula, idade, curso);
                        turma1.addAluno(aluno);

                        Console.WriteLine("Aluno cadastrado");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Salario: ");
                        salario = double.Parse(Console.ReadLine());
                        Console.Write("Idade: ");
                        idade = int.Parse(Console.ReadLine());
                        Console.Write("Matricula: ");
                        matricula = int.Parse(Console.ReadLine());
                        Professor prof = new Professor(nome, matricula, idade, salario);
                        do
                        {
                            Console.Write("Disciplina: ");
                            disciplina = Console.ReadLine();
                            Disciplina disc = new Disciplina(disciplina);
                            prof.listaDisciplina.Add(disc);
                            if (!listDisciplinas.Contains(disc))
                                listDisciplinas.Add(disc);
                            Console.Write("Deseja adicionar outra disciplina para o Professor " + prof.nome + "[1]SIM [2] NAO");

                            op = int.Parse(Console.ReadLine());
                        } while (op != 2);

                        listaProfessor.Add(prof);
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
                            opProf = int.Parse(Console.ReadLine());
                            Questoes questoes = new Questoes();
                            questoes.nDiscursivas = 5;
                            questoes.nObjetivas = 5;
                            Console.Write("Data da prova: ");
                            data = Console.ReadLine();
                            Console.Write("Hora: ");
                            hora = Console.ReadLine();
                            Console.Write("Disciplina: ");
                            for (int i = 0; i < listaProfessor[opProf - 1].listaDisciplina.Count; i++)
                                Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[opProf - 1].listaDisciplina[i].nomeDisciplina);
                            op = int.Parse(Console.ReadLine());
                            Console.Write("Assunto: ");
                            assunto = Console.ReadLine();



                            for (int i = 0; i < turma1.listaAlunos.Count; i++)
                            {
                                Prova prova = new Prova(data, hora, turma1.listaAlunos[i], listaProfessor[opProf - 1].listaDisciplina[op - 1], assunto, questoes, 10);
                                turma1.listaAlunos[i].minhasProvas.Add(prova);
                                if (i == 0)
                                    listaProfessor[opProf - 1].prova.Add(prova);

                                listaProvas.Add(prova);
                            }

                            Console.WriteLine("Prova Criada");
                            listaProfessor[opProf - 1].aplicarProva();
                            turma1.listaAlunos.ForEach(i => i.fazerProva(listaProfessor[opProf - 1]));

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
                                Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[i].nome);

                            opProf = int.Parse(Console.ReadLine());
                            Console.Write("Lançar nota da disciplina: ");
                            for (int i = 0; i < listaProfessor[opProf - 1].prova.Count; i++)
                                Console.WriteLine("[{0}] {1}", (i + 1), listaProfessor[opProf - 1].prova[i]._disciplina.nomeDisciplina);
                            op = int.Parse(Console.ReadLine());


                            for (int i = 0; i < turma1.listaAlunos.Count; i++)
                            {
                                for (int j = 0; j < turma1.listaAlunos[i].minhasProvas.Count; j++)
                                {
                                    if (listaProfessor[opProf - 1].prova[op - 1].assunto.Equals(turma1.listaAlunos[i].minhasProvas[j].assunto))
                                        listaProfessor[opProf - 1].lancarNota(turma1.listaAlunos[i].minhasProvas[j]);
                                }

                            }

                            for (int i = 0; i < listaProfessor[opProf - 1].prova.Count; i++)
                            {
                                if (listaProfessor[opProf - 1].prova[i].assunto.Equals(listaProfessor[opProf - 1].prova[op - 1].assunto))
                                    listaProfessor[opProf - 1].prova.Remove(listaProfessor[opProf - 1].prova[i]);
                            }

                            /*foreach(Prova p in (listaProfessor[opProf - 1].prova))
                            {
                                if (p.assunto.Equals(listaProfessor[opProf - 1].prova[op - 1].assunto))
                                    listaProfessor[opProf - 1].prova.Remove(p);
                            }*/


                        }
                        else
                        {
                            Console.WriteLine("Lista de Provas ou professor vazia!!");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("Alunos da turma " + turma1.numSala);
                        turma1.listaAlunos.ForEach(i => Console.WriteLine("  -" + i.nome));
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        foreach (Professor disciplinas in listaProfessor)
                        {
                            Console.WriteLine("Lista de disciplinas do professor " + disciplinas.nome);
                            disciplinas.listaDisciplina.ForEach(i => Console.WriteLine("  -" + i.nomeDisciplina));
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 7:
                        foreach (Aluno a in turma1.listaAlunos)
                        {
                            Console.WriteLine("Notas do aluno " + a.nome);
                            a.minhasProvas.ForEach(i => Console.WriteLine(String.Format("  -{0}: {1:F}", i._disciplina.nomeDisciplina, i.nota)));
                            Console.WriteLine();
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 0:
                        Environment.Exit(1);
                        break;
                }
           
        }
    }
}
