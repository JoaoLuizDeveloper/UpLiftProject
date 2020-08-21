using System;
using System.Collections.Generic;
using System.Text;

namespace UpLiftCurse.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Service> ServiceList { get; set; }
    }
}
