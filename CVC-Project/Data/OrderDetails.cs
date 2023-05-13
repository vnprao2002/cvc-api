using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key, ForeignKey("OrderId")]
        public int OrderId { get; set; }
        [Key, ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
