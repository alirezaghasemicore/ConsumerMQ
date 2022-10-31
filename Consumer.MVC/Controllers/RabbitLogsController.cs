using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Consumer.MVC.Controllers
{
    public class RabbitLogsController : Controller
    {
        private IDefaultLogService _defaultLogService;
        private IJsonLogService _jsonLogService;
        public RabbitLogsController(IDefaultLogService defaultLogService, IJsonLogService jsonLogService)
        {
            _defaultLogService = defaultLogService;
            _jsonLogService = jsonLogService;
        }

        public async Task<IActionResult> DefaultLogInSQl()
        {
            List<DefaultLog> model = await _defaultLogService.GetDefaultLogsAsync();
            return View(model);
        }

        public async Task<IActionResult> JsonLogInSQl()
        {
            List<JsonLog> model = await _jsonLogService.GetJsonLogs();
            return View(model);
        }

        public async Task<IActionResult> JsonLogToTextFile()
        {
            List<JsonLog> jsonLogs = await _jsonLogService.GetJsonLogs();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Logs.txt");
            foreach (var json in jsonLogs)
            {
                await System.IO.File.AppendAllTextAsync(path, json.LogText);
            }

            var file = ReadBytes(path);
            return File(file, contentType: "text/plain");

        }

        private byte[] ReadBytes(string path)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return bytes;
        }
    }
}
