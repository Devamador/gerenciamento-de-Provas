using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleDeProvas
{
    class Menu
    {
        

        public int desenharMenu()
        {
            int op;
            Console.WriteLine("[1]Cadastrar aluno");
            Console.WriteLine("[2]Cadastrar Professor");
            Console.WriteLine("[3]Criar prova");
            Console.WriteLine("[4]Lançar nota");
            Console.WriteLine("[5]Mostrar lista de alunos");
            Console.WriteLine("[6]Lista de disciplinas dos professores");
            Console.WriteLine("[7]Mostrar notas dos alunos");
            Console.WriteLine("[0]Sair");
            Console.Write("\tOPÇÃO: ");
            op = int.Parse(Console.ReadLine());
            Console.Clear();

            return op;
        }

       
    }
}