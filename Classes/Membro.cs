using System;

namespace DIO.Membros
{
    public class Membro : EntidadeBase
    {
        // Atributos
		private Equipe Equipe { get; set; }
		private string Nome { get; set; }
		private string Email { get; set; }
		private string Ano { get; set; }
        private bool Excluido {get; set;} //campo booleano para definir se meu artigo foi excluido ou não

        // Métodos
		public Membro(int id, Equipe equipe, string nome, string email, string ano)
		{
			this.Id = id;
			this.Equipe = equipe;
			this.Nome = nome;
			this.Email = email;
			this.Ano = ano;
            this.Excluido = false; //quando se cria a serie, o excluido retorna o false. Cuidado ao excluir permanentemente uma informação do programa, recomenda - se apenas marcar como excluido
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Equipe: " + this.Equipe + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "E-mail: " + this.Email + Environment.NewLine;
            retorno += "Ano de Ingresso na Equipe: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}