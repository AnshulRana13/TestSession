using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestSession.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

       // [HttpGet]
        public string Get()
        {
            IPAddress[] ipv4Addresses = Array.FindAll(
    Dns.GetHostEntry(Dns.GetHostName()).AddressList,
    a => a.AddressFamily == AddressFamily.InterNetwork);

            //  IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            IPAddress ipAddress = ipv4Addresses[0];



            if (HttpContext.Session.GetString("name") == null)
                HttpContext.Session.SetString("name", "App");

            string data = HttpContext.Session.GetString("name");

            Thread.Sleep(10000);
            data = data + "::" + DateTime.Now.Ticks.ToString() + $" {ipAddress.ToString()}";
            HttpContext.Session.SetString("name", data);

            return data;

        }
    }
}
