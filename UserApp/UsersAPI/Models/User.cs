using System;
using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Models
{
    public class User
    {
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "First Name Field is Required")]
        public string FName { set; get; }
        [Required(ErrorMessage = "Last Name Field is Required")]
        public string LName { set; get; }
        [Required]
        public string UserName { set; get; }
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required(ErrorMessage = "Phone Number Field is Required")]
        [StringLength(11)]
        public string PhoneNumber { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string Email { set; get; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { set; get; }

    }
}
