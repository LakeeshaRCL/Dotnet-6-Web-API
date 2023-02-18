using System.ComponentModel.DataAnnotations;

namespace DemoAPI.DTOs.Requests
{
    public class CreateStudentRequest
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string contact_number { get; set; }

    }
}
