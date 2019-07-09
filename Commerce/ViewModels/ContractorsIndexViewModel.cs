using Commerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public static List<int> RowsCountValues = new List<int>(){ 5, 10, 20, 50 ,100 };

        public bool NavButton_LeftEnable { get; set; }
        public bool NavButton_RightEnable { get; set; }
        public int NavButton_CurrentValue { get; set; }

        public List<Contractor> ContractorsList { get; set; }
        
        public int RowsCountToShow { get; set; }

        public string SearchString { get; set; }

        public SearchStringType SearchType { get; set; }

    }
}
