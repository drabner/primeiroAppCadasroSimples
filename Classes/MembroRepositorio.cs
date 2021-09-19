using System;
using System.Collections.Generic;
using DIO.Membros.Interfaces;

namespace DIO.Membros
{
	public class MembroRepositorio : IRepositorio<Membro>
	{
        private List<Membro> listaMembro = new List<Membro>();
		public void Atualiza(int id, Membro objeto)
		{
			listaMembro[id] = objeto;
		}

		public void Exclui(int id)
		{

			listaMembro[id].Excluir();
		}	//Exemplo, caso eu queira enviar um e mail toda vez que exluir uma serie, aqui é o campo onde se aplicaria tal comando.

		public void Insere(Membro objeto)
		{
			listaMembro.Add(objeto);
		}

		public List<Membro> Lista()
		{
			return listaMembro;
		}

		public int ProximoId()
		{
			return listaMembro.Count;//
		}

		public Membro RetornaPorId(int id)
		{
			return listaMembro[id];
		}
	}
}