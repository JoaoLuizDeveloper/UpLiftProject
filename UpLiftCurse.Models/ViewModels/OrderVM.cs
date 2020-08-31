using System;
using System.Collections.Generic;
using System.Text;

namespace UpLiftCurse.Models.ViewModels
{
    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
