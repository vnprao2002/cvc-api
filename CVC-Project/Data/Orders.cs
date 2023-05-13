using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("Order")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustAdress { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
        public string CustNote { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("OrderId")]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
