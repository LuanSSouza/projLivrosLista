using projLivrosLista.Controller;
using projLivrosLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Program
    {
        static Livros livros = new Livros();

        static void Main(string[] args)
        {
            string op = "";
            do {
                Console.Clear();

                Console.Write("0. Sair\n" +
                              "1. Adicionar livro\n" +
                              "2. Pesquisar livro (sintético)*\n" +
                              "3. Pesquisar livro (analítico)**\n" +
                              "4. Adicionar exemplar\n" +
                              "5. Registrar empréstimo\n" +
                              "6. Registrar devolução\n\n");

                Console.Write("Digite uma opção: ");
                op = Console.ReadLine();

                switch (op){
                    case "0": break;
                    case "1": adicionarLivro(); break;
                    case "2": pesquisarLivroSintetico(); break;
                    case "3": pesquisarLivroAnalitico(); break;
                    case "4": adicionarExemplar(); break;
                    case "5": registrarEmprestimo(); break;
                    case "6": registrarDevolucao(); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            } while (op != "0");

            System.Environment.Exit(0);
        }

        static void adicionarLivro() {
            Console.Clear();

            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o autor: ");
            string autor = Console.ReadLine();
            Console.Write("Digite a editora: ");
            string editora = Console.ReadLine();

            livros.adicionar(new Livro(isbn, titulo, autor, editora));
        }

        static void pesquisarLivroSintetico()
        {
            Console.Clear();

            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn, "", "", ""));
            Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
            Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade() + "%");

            Console.ReadKey();
        }

        static void pesquisarLivroAnalitico()
        {
            Console.Clear();

            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn, "", "", ""));
            Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
            Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade() + "%");

            livro.Exemplares.ForEach( i => {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Tombo: " + i.Tombo);
                i.Emprestimos.ForEach(j => {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Data Empréstimo: " + j.DtEmprestimo);
                    Console.WriteLine("Data Devolução: " + j.DtDevolucao);
                });
            });

            Console.ReadKey();
        }

        static void adicionarExemplar()
        {
            Console.Clear();

            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn, "", "", ""));

            Console.Write("Digite o Tombo: ");
            int tombo = Int32.Parse(Console.ReadLine());
            livro.adicionarExemplar(new Exemplar(tombo));
        }

        static void registrarEmprestimo()
        {
            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn, "", "", ""));

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.disponivel());
            if (exemplar != null) exemplar.emprestar();
        }

        static void registrarDevolucao()
        {
            Console.Write("Digite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn, "", "", ""));

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => !i.disponivel());
            if (exemplar != null) exemplar.devolver();
        }
    }
}
