using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Data;
using Commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class CommerceController : Controller
    {
        CommerceDbContext commerceDbContext;

        public CommerceController(CommerceDbContext dbContext)
        {
            commerceDbContext = dbContext;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = GetIndexViewModel();
            return View(viewModel);
        }
        private HomeIndexViewModel GetIndexViewModel()
        {
            var contractorsCount = (from c in commerceDbContext.Contractors select c).Count();
            var issueTypeCount = (from c in commerceDbContext.IssueType select c).Count();



            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.TablesInfo = new HomeIndexViewModel.TableInfo[]
            {
                new HomeIndexViewModel.TableInfo(contractorsCount,"Contractors", "Contractors"),
                new HomeIndexViewModel.TableInfo(issueTypeCount,"Issue Type", "IssueType")
            };

            return viewModel;
        }

    }
}