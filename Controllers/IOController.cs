using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using technostar_test.Models;

namespace technostar_test.Controllers
{
    public class IOController : Controller
    {
        public int AddTransaction(Transaction transaction)
        {
            return DAL.AddTransaction(transaction);
        }
        public int AddProduct(Product product)
        {
            return DAL.AddProduct(product);
        }
        public int AddPerson(Person person)
        {
            return DAL.AddPerson(person);
        }
        public int EditTransaction(Transaction transaction)
        {
            return DAL.EditTransaction(transaction);
        }
        public int EditProduct(Product product)
        {
            return DAL.EditProduct(product);
        }
        public int EditPerson(Person person)
        {
            return DAL.EditPerson(person);
        }
        public int RemoveTransaction(int id)
        {
            return DAL.RemoveTransaction(id);
        }
        public int RemoveProduct(int id)
        {
            return DAL.RemoveProduct(id);
        }
        public int RemovePerson(int id)
        {
            return DAL.RemovePerson(id);
        }
    }
}