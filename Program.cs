using System;

namespace DIO.Membros
{
    class Program
    {
        static MembroRepositorio repositorio = new MembroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMembro();
						break;
					case "2":
						InserirMembro();
						break;
					case "3":
						AtualizarMembro();
						break;
					case "4":
						ExcluirMembro();
						break;
					case "5":
						VisualizarMembro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirMembro()
		{
			Console.Write("Digite o id do membro: ");
			int indiceMembro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMembro);
		}

        private static void VisualizarMembro()
		{
			Console.Write("Digite o id do membro: ");
			int indiceMembro = int.Parse(Console.ReadLine());

			var membro = repositorio.RetornaPorId(indiceMembro);

			Console.WriteLine(membro);
		}

        private static void AtualizarMembro()
		{
			Console.Write("Digite o id do membro: ");
			int indiceMembro = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Equipe)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Equipe), i));
			}
			Console.Write("Digite a equipe entre as opções acima: ");
			int entradaEquipe = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do membro: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a data de Ingresso do Membro na equipe: ");
			string entradaAno = (Console.ReadLine());

			Console.Write("Digite o e-mail do membro: ");
			string entradaEmail = Console.ReadLine();

			Membro atualizaMembro = new Membro(id: indiceMembro,
										equipe: (Equipe)entradaEquipe,
										nome: entradaNome,
										ano: entradaAno,
										email: entradaEmail);

			repositorio.Atualiza(indiceMembro, atualizaMembro);
		}
        private static void ListarMembro()
		{
			Console.WriteLine("Listar membros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum membro cadastrado.");
				return;
			}

			foreach (var membro in lista)
			{
                var excluido = membro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", membro.retornaId(), membro.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMembro()
		{
			Console.WriteLine("Inserir novo membro");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Equipe)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Equipe), i));
			}
			Console.Write("Digite a equipe entre as opções acima: ");
			int entradaEquipe = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do membro: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a data de ingresso do Membro na equipe: ");
			string entradaAno = (Console.ReadLine());

			Console.Write("Digite o e-mail do membro: ");
			string entradaEmail = Console.ReadLine();

			Membro novoMembro = new Membro(id: repositorio.ProximoId(),
										equipe: (Equipe)entradaEquipe,
										nome: entradaNome,
										ano: entradaAno,
										email: entradaEmail);

			repositorio.Insere(novoMembro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Cadastro de Membros de Equipe - Encotro de Carros Antigos");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Membros");
			Console.WriteLine("2- Inserir novo membro");
			Console.WriteLine("3- Atualizar membro");
			Console.WriteLine("4- Excluir membro");
			Console.WriteLine("5- Visualizar membro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
