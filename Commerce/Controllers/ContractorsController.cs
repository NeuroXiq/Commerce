using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Data;
using Commerce.Models;
using Commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace Commerce.Controllers
{
    public class ContractorsController : Controller
    {
        CommerceDbContext dbContext;

        public ContractorsController(CommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IActionResult Index()
        //{
        //    return Index(1, 11);
        //}

        
        public IActionResult Index(int start=1, int end=11)
        {
            if (start > end) return BadRequest();
            if (start - end > 100) end = (start + 100);

            var query = from c in dbContext.Contractors where c.ID >= start && c.ID <= end select c;

            var contractors = query.ToList();
            ContractorsIndexViewModel viewModel = new ContractorsIndexViewModel();

            viewModel.Contractors = contractors;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contractor contractor)
        {

            if (ModelState.IsValid)
            {
                dbContext.Add<Contractor>(contractor);
                dbContext.SaveChanges();
                ViewData["Success"] = "Contractor created successfully";
            }
            else
            {
                ViewData["Error"] = "Error occur during creating new contractor";

                string[] errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();

                ViewData["ErrorMessages"] = errorMessages;

            }

            return View();
        }


        public IActionResult Edit(int id)
        {
            
            return View();
        }
        

    }
}