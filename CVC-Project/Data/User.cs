using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVC_Project.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DataType("nchar")]
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedTime { get; set; }
        [DataType("nchar")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        [DataType("nchar")]
        public string UpdatedBy { get; set; }
        public Boolean Status { get; set; }
        [ForeignKey("UserId")]
        public List<Orders> Orders { get; set; }


    }
}
