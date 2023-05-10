using System.ComponentModel.DataAnnotations;

namespace ElmotatawraApi.Dto
{
    public class RegisterStudentDto
    {
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ThirdName { get; set; }
        [Required]
        public string FouthName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
