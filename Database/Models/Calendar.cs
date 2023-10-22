using System.ComponentModel.DataAnnotations;
namespace Database.Models

{
    public class Calendar
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required] 
        public String Sex { get; set; }
        [Required] 
        public String Birth { get; set; }
        public String Address { get; set; }
    }
}
