using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [DataType("nchar")]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public DateTime CreatedTime { get; set; }
        [DataType("nchar")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public byte Status { get; set; }
        public byte Colors { get; set; }
        public string FullDesc { get; set; }
        public string Specification { get; set; }
        public string Others { get; set; }
        public string Brand { get; set; }
        public string Origin { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string View { get; set; }
        public string Certificates { get; set; }
        public string ProductImg { get; set; }
        [ForeignKey("ProductId")]
        public List<Images> Images { get; set; }
        [ForeignKey("ProductId")]
        public List<OrderDetails> OrderDetails { get; set; }
        [ForeignKey("SubCateId")]
        public int SubCateId { get; set; }
        
    }
}
