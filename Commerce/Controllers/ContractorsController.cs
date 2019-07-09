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

        [ActionName("RangeNavigation")]
        public IActionResult Index(int rangeIndex, int rangeCount)
        {
            if (!ContractorsIndexViewModel.RowsCountValues.Contains(rangeCount))
            {
                rangeCount = ContractorsIndexViewModel.RowsCountValues[0];
            }

            bool rightNavButtonEnabled;

            List<Contractor> contractors = GetContractorsRange(rangeIndex, rangeCount, out rightNavButtonEnabled);

            ContractorsIndexViewModel vm = new ContractorsIndexViewModel();
            vm.ContractorsList = contractors;
            vm.NavButton_CurrentValue = rangeIndex;
            vm.NavButton_LeftEnable = true;
            vm.NavButton_RightEnable = rightNavButtonEnabled;
            vm.RowsCountToShow = rangeCount;
           



            return View("Index",vm);
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            return View(GetInitialVM());
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
                ViewData["Error"] = "An error occur during creating new contractor";

                string[] errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();

                ViewData["ErrorMessages"] = errorMessages;

            }

            return View();
        }


        public IActionResult Edit(int id)
        {
            
            return View();
        }


        public ContractorsIndexViewModel GetInitialVM()
        {
            ContractorsIndexViewModel vm = new ContractorsIndexViewModel();
            int rowsCount = ContractorsIndexViewModel.RowsCountValues[0];
            bool nextRangeButtonEnable = false;
            bool prevRangebuttonEnable = true;
            List<Contractor> contractors = GetContractorsRange(1, rowsCount, out nextRangeButtonEnable);

            vm.NavButton_CurrentValue = 1;
            vm.NavButton_LeftEnable = prevRangebuttonEnable;
            vm.NavButton_RightEnable = nextRangeButtonEnable;
            vm.ContractorsList = contractors;

            return vm;
        }


        public List<Contractor> GetContractorsRange(int rangeNo, int rangeLength, out bool moreExists)
        {
            int skipCount = rangeNo * rangeLength;
            int ctorTotalCount = dbContext.Contractors.Count();

            List<Contractor> contractors = dbContext.Contractors
                .Skip(skipCount)
                .Take(rangeLength)
                .ToList();

            if (ctorTotalCount > skipCount + rangeLength)
                moreExists = true;
            else moreExists = false;

            if (contractors == null) contractors = new List<Contractor>();

            return contractors;
        }

    }
}