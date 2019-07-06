using Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.ViewModels
{
    public class ContractorsIndexViewModel
    {
        public enum SearchStringType
        {
            FirstName,
            LastName,
            EMail
        }



        public List<Contractor> Contractors { get; set; }

        public string SearchString { get; set; }

        public SearchStringType SearchType { get; set; }

    }
}
