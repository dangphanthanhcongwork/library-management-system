using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Application.DTOs.Requests
{
    public class UserRequest
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        [MaxLength(100)]
        public required string FullName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public required string EmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        [Phone]
        public required string PhoneNumber { get; set; }
    }
}