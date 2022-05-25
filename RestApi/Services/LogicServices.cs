using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApi.Interfaces;
using RestApi.Models;
using System.Collections.Generic;
using System.IO;
using AutoMapper;

namespace RestApi.Services
{

	public class LogicServices : ILogicServices
	{
		private IDataService dataService;
		public LogicServices(IDataService _dataService)
		{
			this.dataService = _dataService;
		}
		public CardModel EditCard(CardModel card)
		{
			var list = dataService.GetData();
			var model = new CardModel();

			foreach(var item in list)
			{
				if(item.Rank == card.Rank)
				{
					item.Status = card.Status;
					item.User = card.User;
					item.Steps = card.Steps;
					model = card;
				}
			}

			dataService.UpdateJson(list);

			return model;
		}

		public List<CardModel> AddCard(CardModel model)
		{
			var list = dataService.GetData();

			model.Rank = list.Count + 1;

			list.Add(model);

			dataService.UpdateJson(list);

			return list;
		}

		public List<CardModel> DeleteCard(int rank)
		{
			var list = dataService.GetData();

			foreach (var card in list)
			{
				if (card.Rank == rank)
				{
					list.Remove(card);
					break;
				}
			}

			dataService.UpdateJson(list);

			return list;
		}
	}
}
