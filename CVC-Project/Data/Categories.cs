using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        [ForeignKey("CateId")]
        public List<SubCategories> SubCategories { get; set; }

    }
}
