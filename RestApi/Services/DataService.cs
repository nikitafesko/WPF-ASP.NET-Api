using Newtonsoft.Json;
using RestApi.Interfaces;
using RestApi.Models;
using System.Collections.Generic;
using System.IO;

namespace RestApi.Services
{
	public class DataService : IDataService
	{
		public List<CardModel> GetData()
		{
			string json = File.ReadAllText($"./Data/day1.json");
			var list = JsonConvert.DeserializeObject<List<CardModel>>(json);

			return list;
		}
		public void UpdateJson(List<CardModel> list)
		{
			string json = File.ReadAllText("./Data/day1.json");
			var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
			jsonObj = list;
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText("./Data/day1.json", output);
		}
	}
}
