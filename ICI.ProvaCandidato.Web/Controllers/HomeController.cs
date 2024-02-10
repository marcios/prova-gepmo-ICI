using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly AppDbContexto _contexto;

        public HomeController(ILogger<HomeController> logger, AppDbContexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public IActionResult Index()
		{
			var x = _contexto.Tags.ToList();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
