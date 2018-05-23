using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace controleDeProvas
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Turma turma1 = new Turma();
           
            List<Professor> listaProfessor = new List<Professor>();
            int op, opProf;
            int idade, matricula;
            string nome, curso, disciplina;
            double salario;
            do
            {
                Console.WriteLine("[1]Cadastrar aluno");
                Console.WriteLine("[2]Cadastrar Professor");
                Console.WriteLine("[3]Criar prova");
                Console.WriteLine("[4]Lançar nota");
                Console.WriteLine("[0]Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
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
                        salario = double.Parse( Console.ReadLine());
                        Console.Write("Idade: ");
                        idade = int.Parse(Console.ReadLine());
                        Console.Write("Matricula: ");
                        matricula = int.Parse(Console.ReadLine());
                                     
                        Console.Write("Disciplina: ");
                        disciplina = Console.ReadLine();
                        Professor prof = new Professor(nome, matricula, idade,salario);
                        Disciplina disc = new Disciplina(disciplina);
                        //prof.listaDisciplina.ForEach(i => prof.listaDisciplina.Add(disc)) ;
                        prof.listaDisciplina.Add(disc);
                        listaProfessor.Add(prof);
                        break;

                    case 3:
                        Console.WriteLine("Acessar como: ");
                        for(int i = 0; i < listaProfessor.Count; i++)
                        {
                            Console.WriteLine("[{0}] {1}]",(i+1),listaProfessor[i].nome);
                        }
                        opProf = int.Parse(Console.ReadLine());
                        listaProfessor[opProf - 1].criarProva();
                        //listaProfessor.ForEach(i => Console.WriteLine(" {0}",i.nome));
                        break;

                    case 4:

                        break;
                    case 0:
                        break;
                }

            } while (op != 0);

            /*Disciplina poo = new Disciplina("Programação orientada a objetos");
            Disciplina logica = new Disciplina("Logica de Programação");
            Disciplina estrutura = new Disciplina("Estrutura de Dados");
            Disciplina so = new Disciplina("Sistema Operaciional");
            Disciplina eng = new Disciplina("Engenharia de Software");

            Professor prof = new Professor("Jhonatas",111111,18,10000);
            prof.listaDisciplina.Add(poo);
            prof.listaDisciplina.Add(logica);

            Professor prof2 = new Professor("Sergio", 222222, 20, 10000);
            prof2.listaDisciplina.Add(estrutura);

            Aluno rodrigo = new Aluno("Rodrigo", 17243840, 21, "CIN");
            Aluno savio = new Aluno("Savio", 123456, 20, "CIN");
            Aluno claudio = new Aluno("Claudio", 147258, 28, "CIN");
            Aluno karol = new Aluno("Ana Karolina", 789456, 25, "CIN");
     
            Provao provao = new Provao("10/10/10","18:30",prof.criarProva());
            List<Provao> p = new List<Provao>();

            
            turma1.addAluno(rodrigo);
            turma1.addAluno(savio);
            turma1.addAluno(claudio);
            turma1.addAluno(karol);

            p.Add(provao);

           //adicionando alunos na lista de alunos da classe Provao
            provao.aluno.Add(rodrigo);
            provao.aluno.Add(savio);
            provao.aluno.Add(claudio);
            provao.aluno.Add(karol);
           
            //provao.aluno.ForEach(i => Console.WriteLine(i.nome));
            
            prof.aplicarProva();
            prof2.aplicarProva();
            //Colocando os alunos para fazer prova e add provao na lista de provas do aluno
            for(int i = 0; i < provao.aluno.Count; i++)
            {
                provao.aluno[i].fazerProva(prof);
                provao.aluno[i].minhasProvas.Add(provao);
            }


            prof.lancarNota(provao);
            Console.WriteLine("Notas do "+ rodrigo.nome);
            rodrigo.minhasProvas.ForEach(i => Console.WriteLine("{0} = {1} ",i.dadosProva.disciplina.nomeDisciplina,i.nota));

            //Console.WriteLine(prof.ToString()); 
            //Console.WriteLine("Nota do {0} é {1}",aluno.nome,aluno.minhasProvas[0].nota); 
            
            //Console.WriteLine(aluno.prova.nota);*/
            
            
            
            Console.ReadKey();
        }
    }
}
