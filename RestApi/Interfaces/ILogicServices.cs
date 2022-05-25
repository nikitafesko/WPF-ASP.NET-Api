using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
	public interface ILogicServices
	{
		public CardModel EditCard(CardModel card);
		public List<CardModel> AddCard(CardModel model);
		public List<CardModel> DeleteCard(int rank);

	}
}
