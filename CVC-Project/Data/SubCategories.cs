using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("SubCategories")]
    public class SubCategories
    {
        [Key]
        public int Id { get; set; }
        [DataType("nchar")]
        public string Name { get; set; }
        public string Image { get; set; }
        public int View { get; set; }
        [ForeignKey("CateId")]
        public int CateId { get; set; }
        public string Description { get; set; }
        [ForeignKey("SubCateId")]
        public List<Product> Products { get; set; }
    }
}
