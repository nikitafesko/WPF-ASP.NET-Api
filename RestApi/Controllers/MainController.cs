using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Interfaces;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MainController : ControllerBase
	{
		public ILogicServices service;
		public IDataService dataService;

		public MainController(ILogicServices service, IDataService dataService)
		{
			this.service = service;
			this.dataService = dataService;
		}
		[HttpGet]
		[Route("/getData")]
		public List<CardModel> GetDataFromJSON()
		{
			var list = dataService.GetData();
			return list;
		}
		[HttpPost]
		[Route("/editModel")]
		public CardModel EditModel(CardModel card)
		{
			var model = service.EditCard(card);
			return model;
		}
		[HttpPost]
		[Route("/addModel")]
		public List<CardModel> AddModel(CardModel card)
		{
			var list = service.AddCard(card);
			return list;
		}
		[HttpDelete]
		[Route("/deleteModel/{id}")]
		public List<CardModel> DeleteModel(int id)
		{
			var list = service.DeleteCard(id);
			return list;
		}
	}
}
