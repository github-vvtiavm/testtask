using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Buisness.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTimeOffset OrderDateTime { get; set; }
        public DateTime ApprovalDateTime { get; set; }
    }
}
