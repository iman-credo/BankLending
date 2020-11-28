using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		private readonly IDapper _dapper;

		public SampleDataController(IDapper dapper)
		{
			_dapper = dapper;
		}

		public async Task<bool> Add(DataAccess.Models.Sample data)
		{
			var dbParams = new DynamicParameters();
			dbParams.Add("Id", data.Id, System.Data.DbType.Int32);
			dbParams.Add("FirstName", data.FirstName, System.Data.DbType.String);
			dbParams.Add("LastName", data.LastName, System.Data.DbType.String);
			var res = await Task.FromResult(_dapper.Insert<DataAccess.Models.Sample>("SP Name", dbParams, commandType: CommandType.StoredProcedure));
			return true;
		}

		//private static string[] Summaries = new[]
		//{
		//				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		//		};

		//[HttpGet("[action]")]
		//public IEnumerable<WeatherForecast> WeatherForecasts()
		//{
		//	var rng = new Random();
		//	return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		//	{
		//		DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
		//		TemperatureC = rng.Next(-20, 55),
		//		Summary = Summaries[rng.Next(Summaries.Length)]
		//	});
		//}

		//public class WeatherForecast
		//{
		//	public string DateFormatted { get; set; }
		//	public int TemperatureC { get; set; }
		//	public string Summary { get; set; }

		//	public int TemperatureF
		//	{
		//		get
		//		{
		//			return 32 + (int)(TemperatureC / 0.5556);
		//		}
		//	}
		//}
	}
}
