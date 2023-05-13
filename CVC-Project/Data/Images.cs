using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("Image")]
    public class Images
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        [DataType("nchar")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        [DataType("nchar")]
        public string UpdatedBy { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }
}
