using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CVC_Project.Data
{
    public class TypicalCategories
    {
        [Key]
        public int TypicalCategoryId { get; set; }
        public string TypicalName { get; set; }

        public string TypicalImage { get; set; }
        [ForeignKey("SubCateId")]
        public int SubCateId { get; set; }

    }
}
