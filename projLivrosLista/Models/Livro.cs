using projLivrosLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista.Models
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public List<Exemplar> Exemplares { get { return this.exemplares; } }

        public Livro(int i, string t, string a, string e) {
            this.isbn = i;
            this.titulo = t;
            this.autor = a;
            this.editora = e;
            this.exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar) {
            this.exemplares.Add(exemplar);
        }

        public int qtdeExemplares() {
            return this.exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            int disponiveis = 0;
            this.exemplares.ForEach(item => { if (item.disponivel()) disponiveis++; });
            return disponiveis;
        }

        public int qtdeEmprestimos()
        {
            int emprestados = 0;
            this.exemplares.ForEach(item => emprestados += item.qtdeEmprestimos());
            return emprestados;
        }

        public double percDisponibilidade() {
            double percentual = (this.qtdeExemplares() == 0 || this.qtdeDisponiveis() == 0) ?0:(this.qtdeDisponiveis()/ this.qtdeExemplares()) * 100;
            return percentual;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.isbn.Equals(((Livro)obj).isbn);
            return false;
        }

    }
}
