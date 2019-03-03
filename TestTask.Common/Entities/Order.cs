using System;
using TestTask.Common.Abstract;

namespace TestTask.Common.Entities
{
    public class Order : EntityKey
    {
        public string OrderNumber { get; set; }
        public DateTimeOffset OrderDateTime { get; set; }
        public DateTime ApprovalDateTime { get; set; }
    }
}
