using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using technostar_test.Models;

namespace technostar_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TechnostarDbContext db;

        public HomeController(ILogger<HomeController> logger, TechnostarDbContext dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            // fills viewmodel with data
            //
            // equivalent without EF:
            //
            // var result = new List<Transaction>();
            // var query = "select * from dbo.Transactions";
            // var conn = new SqlConnection(connStr);
            // var sqlCommand = new sqlCommand(conn, query);
            // conn.Open();
            // var reader = sqlCommand.ExecuteReader();
            // while (reader.Read())
            // { 
            // var transaction = new Transaction { Id = reader["Id"], ... };
            // result.Add(transaction);
            // }
            // return result;
            //
            // for the rest, I will just provide the queries
            viewModel.Transactions = db.Transactions.ToList();
            viewModel.Products = db.Products.ToList();
            viewModel.Persons = db.Persons.ToList();
            return View(viewModel);
        }
        // "insert into dbo.Transactions (BuyerId, SellerId, DateTime, UsdAmount) values (@BuyerId, ...)
        // return SCOPE_IDENTITY();"
        // ...
        // sqlCommand.Parameters.AddWithValue("BuyerId", transaction.BuyerId); ...
        public int AddTransaction(Transaction transaction)
        {
            int result = 0;
            try
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                result = transaction.Id;
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int AddProduct(Product product)
        {
            int result = 0;
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                result = product.Id;
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int AddPerson(Person person)
        {
            int result = 0;
            try
            {
                db.Persons.Add(person);
                db.SaveChanges();
                result = person.Id;
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        // "update dbo.Transactions set BuyerId=@BuyerId, ... where Id=@Id"
        public int EditTransaction(Transaction transaction)
        {
            int result = 0;
            try
            {
                var recordedTransaction = db.Transactions.Find(transaction.Id);
                if (recordedTransaction != null)
                {
                    db.Entry(recordedTransaction).CurrentValues.SetValues(transaction);
                    db.SaveChanges();
                } else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int EditProduct(Product product)
        {
            int result = 0;
            try
            {
                var recordedProduct = db.Products.Find(product.Id);
                if (recordedProduct != null)
                {
                    db.Entry(recordedProduct).CurrentValues.SetValues(product);
                    db.SaveChanges();
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int EditPerson(Person person)
        {
            int result = 0;
            try
            {
                var recordedPerson = db.Persons.Find(person.Id);
                if (recordedPerson != null)
                {
                    db.Entry(recordedPerson).CurrentValues.SetValues(person);
                    db.SaveChanges();
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        // "delete from dbo.Transactions where Id=@Id"
        public int RemoveTransaction(int id)
        {
            int result = 0;
            try
            {
                var recordedTransaction = db.Transactions.Find(id);
                if (recordedTransaction != null)
                {
                    db.Transactions.Remove(recordedTransaction);
                    db.SaveChanges();
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int RemoveProduct(int id)
        {
            int result = 0;
            try
            {
                var recordedProduct = db.Products.Find(id);
                if (recordedProduct != null)
                {
                    db.Products.Remove(recordedProduct);
                    db.SaveChanges();
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
        }
        public int RemovePerson(int id)
        {
            int result = 0;
            try
            {
                var recordedPerson = db.Persons.Find(id);
                if (recordedPerson != null)
                {
                    db.Persons.Remove(recordedPerson);
                    db.SaveChanges();
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                result = 1;
            }
            return result;
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

        // json is a thing of the past, but the old json files could be used to populate the database if anything goes wrong with it
        // something of a rudimentary backup. not all too useful, I just used it to populate the database when switching from json
        // and decided to keep it around, just in case
        public void FillDatabaseFromJson()
        {
            var transactions = JsonSerializer.Deserialize<List<Transaction>>(System.IO.File.ReadAllText("Data/Transactions.json"));
            var products = JsonSerializer.Deserialize<List<Product>>(System.IO.File.ReadAllText("Data/Products.json"));
            var persons = JsonSerializer.Deserialize<List<Person>>(System.IO.File.ReadAllText("Data/Persons.json"));
            transactions.ForEach(t => t.Id = 0);
            products.ForEach(t => t.Id = 0);
            persons.ForEach(t => t.Id = 0);
            db.Transactions.AddRange(transactions);
            db.Products.AddRange(products);
            db.Persons.AddRange(persons);
            db.SaveChanges();
        }
    }
}
