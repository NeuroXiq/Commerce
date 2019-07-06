using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.ViewModels
{
    public class IssueTypeIndexViewModel
    {
        public class NameId
        {
            public string Name { get; set; }
            public int ID { get; set; }

            public NameId(string name, int id)
            {
                Name = name;
                ID = id;
            }
        }

        public NameId[] NameIdValues { get; set; }
        public IssueTypeIndexViewModel(NameId[] nameIdPairs)
        {
            NameIdValues = nameIdPairs;
        }
    }
}
