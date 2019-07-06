using Commerce.Data;
using Commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Controllers
{
    public class IssueTypeController : Controller
    {
        CommerceDbContext commerceDbContext;

        public IssueTypeController(CommerceDbContext commerceDbContext)
        {
            this.commerceDbContext = commerceDbContext;
        }
        public IActionResult Index()
        {
            var issueTypes = (from v in commerceDbContext.IssueType select new 
                              IssueTypeIndexViewModel.NameId(v.Name, v.ID)).ToArray();

            IssueTypeIndexViewModel viewModel = new IssueTypeIndexViewModel(issueTypes);

            return View(viewModel);
        }
    }
}
