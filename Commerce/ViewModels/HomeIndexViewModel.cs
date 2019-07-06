using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.ViewModels
{
    public class HomeIndexViewModel
    {
        public class TableInfo
        {
            public int Count { get; set; }
            public string Name { get; set; }
            public string ControllerName {get; set; }

            public TableInfo(int count, string name, string controllerName)
            {
                Count = count;
                Name = name;
                ControllerName = controllerName;
            }
        }

        public TableInfo[] TablesInfo { get; set; }
    }
}
