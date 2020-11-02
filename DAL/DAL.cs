using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using technostar_test.Models;

namespace technostar_test
{
    // using JSON here so as not to bother with running a whole SQL server
    public class DAL
    {
        // root-relative paths to all json files
        public static string TransactionsJsonPath = "Data/Transactions.json";
        public static string ProductsJsonPath = "Data/Products.json";
        public static string PersonsJsonPath = "Data/Persons.json";

        // storing all objects in cache to avoid re-reading on page reload
        // because there will not be a lot of data in this project (hopefully).
        // also helps to avoid re-reading json when updating it.
        public static List<Transaction> TransactionsCache { get; set; } = new List<Transaction>();
        public static List<Product> ProductsCache { get; set; } = new List<Product>();
        public static List<Person> PersonsCache { get; set; } = new List<Person>();
        public static int UpdatePersons(List<Person> persons)
        {
            int result = 0;
            return result;
        }
        public static List<Transaction> GetTransactions()
        {
            var result = new List<Transaction>();
            // if cache is not empty, takes it
            if (TransactionsCache != null && TransactionsCache.Any())
            {
                result = TransactionsCache;
            }
            // if cache is empty, reads transactions
            else
            {
                try
                {
                    // reads JSON from disk and deserealizes it
                    var jsonString = System.IO.File.ReadAllText(TransactionsJsonPath);
                    result = JsonSerializer.Deserialize<List<Transaction>>(jsonString);
                    // caches it for future use
                    TransactionsCache = result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown in DAL.GetTransactions() when trying to read JSON from disk and deserialize: ", e);
                }
            }
            return result;
        }
        public static List<Product> GetProducts()
        {
            var result = new List<Product>();
            // if cache is not empty, takes it
            if (ProductsCache != null && ProductsCache.Any())
            {
                result = ProductsCache;
            }
            // if cache is empty, reads products
            else
            {
                try
                {
                    // reads JSON from disk and deserializes it
                    var jsonString = System.IO.File.ReadAllText(ProductsJsonPath);
                    result = JsonSerializer.Deserialize<List<Product>>(jsonString);
                    // caches it for future use
                    ProductsCache = result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown in DAL.GetProducts() when trying to read JSON from disk and deserialize: ", e);
                }
            }
            return result;
        }
        public static List<Person> GetPersons()
        {
            var result = new List<Person>();
            // if cache is not empty, takes it
            if (PersonsCache != null && PersonsCache.Any())
            {
                result = PersonsCache;
            }
            // if cache is empty, reads persons
            else
            {
                try
                {
                    // reads JSON from disk and deserializes it
                    var jsonString = System.IO.File.ReadAllText(PersonsJsonPath);
                    result = JsonSerializer.Deserialize<List<Person>>(jsonString);
                    // caches it for future use
                    PersonsCache = result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown in DAL.GetPersons() when trying to read JSON from disk and deserialize: ", e);
                }
            }
            return result;
        }
        public static int UpdateTransactions()
        {
            var result = 0;
            // if cache is empty, tries to load it
            if (TransactionsCache == null && !TransactionsCache.Any())
            {
                GetTransactions();
            }
            try
            {
                // serializes transactions cache to JSON and writes it to file
                var jsonString = JsonSerializer.Serialize<List<Transaction>>(TransactionsCache);
                System.IO.File.WriteAllText(TransactionsJsonPath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown in DAL.UpdateTransactions() when trying to serialize and write JSON to disk: ", e);
                result = 1;
            }
            return result;
        }
        public static int UpdateProducts()
        {
            var result = 0;
            // if cache is empty, tries to load it
            if (ProductsCache == null && !ProductsCache.Any())
            {
                GetProducts();
            }
            try
            {
                // serializes products cache to JSON and writes it to file
                var jsonString = JsonSerializer.Serialize<List<Product>>(ProductsCache);
                System.IO.File.WriteAllText(ProductsJsonPath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown in DAL.UpdateProducts() when trying to serialize and write JSON to disk: ", e);
                result = 1;
            }
            return result;
        }
        public static int UpdatePersons()
        {
            var result = 0;
            // if cache is empty, tries to load it
            if (PersonsCache == null && !PersonsCache.Any())
            {
                GetPersons();
            }
            try
            {
                // serializes persons cache to JSON and writes it to file
                var jsonString = JsonSerializer.Serialize<List<Person>>(PersonsCache);
                System.IO.File.WriteAllText(PersonsJsonPath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown in DAL.UpdatePersons() when trying to serialize and write JSON to disk: ", e);
                result = 1;
            }
            return result;
        }
        public static int AddTransaction(Transaction transaction)
        {
            // if cache is empty, tries to load it
            if (TransactionsCache == null && !TransactionsCache.Any())
            {
                GetTransactions();
            }
            transaction.Id = TransactionsCache.Max(t => t.Id) + 1;
            TransactionsCache.Add(transaction);
            UpdateTransactions();
            return transaction.Id;
        }
        public static int AddProduct(Product product)
        {
            // if cache is empty, tries to load it
            if (ProductsCache == null && !ProductsCache.Any())
            {
                GetProducts();
            }
            product.Id = ProductsCache.Max(t => t.Id) + 1;
            ProductsCache.Add(product);
            UpdateProducts();
            return product.Id;
        }
        public static int AddPerson(Person person)
        {
            // if cache is empty, tries to load it
            if (PersonsCache == null && !PersonsCache.Any())
            {
                GetPersons();
            }
            person.Id = PersonsCache.Max(t => t.Id) + 1;
            PersonsCache.Add(person);
            UpdatePersons();
            return person.Id;
        }
        public static int EditTransaction(Transaction transaction)
        {
            // if cache is empty, tries to load it
            if (TransactionsCache == null && !TransactionsCache.Any())
            {
                GetTransactions();
            }
            var i = TransactionsCache.FindIndex(t => t.Id == transaction.Id);
            TransactionsCache[i] = transaction;
            UpdateTransactions();
            return 0;
        }
        public static int EditProduct(Product product)
        {
            // if cache is empty, tries to load it
            if (ProductsCache == null && !ProductsCache.Any())
            {
                GetProducts();
            }
            var i = ProductsCache.FindIndex(t => t.Id == product.Id);
            ProductsCache[i] = product;
            UpdateProducts();
            return 0;
        }
        public static int EditPerson(Person person)
        {
            // if cache is empty, tries to load it
            if (PersonsCache == null && !PersonsCache.Any())
            {
                GetPersons();
            }
            var i = PersonsCache.FindIndex(t => t.Id == person.Id);
            PersonsCache[i] = person;
            UpdatePersons();
            return 0;
        }
        public static int RemoveTransaction(int id)
        {
            // if cache is empty, tries to load it
            if (TransactionsCache == null && !TransactionsCache.Any())
            {
                GetTransactions();
            }
            var transaction = TransactionsCache.FirstOrDefault(t => t.Id == id);
            TransactionsCache.Remove(transaction);
            UpdateTransactions();
            return 0;
        }
        public static int RemoveProduct(int id)
        {
            // if cache is empty, tries to load it
            if (ProductsCache == null && !ProductsCache.Any())
            {
                GetProducts();
            }
            var product = ProductsCache.FirstOrDefault(p => p.Id == id);
            ProductsCache.Remove(product);
            UpdateProducts();
            return 0;
        }
        public static int RemovePerson(int id)
        {
            // if cache is empty, tries to load it
            if (PersonsCache == null && !PersonsCache.Any())
            {
                GetPersons();
            }
            var person = PersonsCache.FirstOrDefault(p => p.Id == id);
            PersonsCache.Remove(person);
            UpdatePersons();
            return 0;
        }
    }
}
