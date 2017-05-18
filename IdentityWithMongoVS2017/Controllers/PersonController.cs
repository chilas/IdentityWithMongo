using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityWithMongoVS2017.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using System;

namespace IdentityWithMongoVS2017.Controllers
{
    public class PersonController : Controller
    {
        private IdentityWithMongoDBContext dbCOntext;
        public PersonController(IConfigurationRoot config)
        {
            dbCOntext = new IdentityWithMongoDBContext(config);
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var model = await dbCOntext.PersonCollection.FindSync(p => true).ToListAsync();
            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await dbCOntext.PersonCollection.InsertOneAsync(person);
                return View();
            }
            return View(person);
        }
    }
}