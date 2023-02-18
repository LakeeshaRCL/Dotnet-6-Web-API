using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Models
{
    [Table("student")]
    public class StudentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id {get;set;}

        [Required]
        public string first_name { get;set;}

        [Required]
        public string last_name { get;set;}

        [Required]
        public string address { get;set;}

        [Required]
        public string email { get;set;}

        [Required]
        public string contact_number { get;set;}

    }
}
