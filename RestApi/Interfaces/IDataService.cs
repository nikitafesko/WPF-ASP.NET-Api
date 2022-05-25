using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
	public interface IDataService
	{
		public List<CardModel> GetData();
		public void UpdateJson(List<CardModel> list);
	}
}
