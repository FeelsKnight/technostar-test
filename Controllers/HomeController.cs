using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using technostar_test.AppCode;
using technostar_test.Models;

namespace technostar_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            // fills viewmodel with data
            viewModel.Products = DAL.GetProducts();
            viewModel.Transactions = DAL.GetTransactions();
            viewModel.Persons = DAL.GetPersons();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public FileContentResult Task()
        {
            // MIME type for .docx
            var fileMimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            var fileName = "task.docx";
            // .ReadAllBytes takes a root-relative path
            var filePath = "wwwroot/Files/" + fileName;
            var fileBytes = new byte[] { };
            try
            {
                fileBytes = System.IO.File.ReadAllBytes(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown in Home/Task when trying to read the file from disk: ", e);
            }
            // adding correct response headers via Microsoft.Net.Http.Headers
            Response.Headers.Add(HeaderNames.ContentDisposition, new ContentDispositionHeaderValue("attachment") { FileNameStar = fileName }.ToString());
            return File(fileContents: fileBytes, contentType: fileMimeType, fileDownloadName: fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
