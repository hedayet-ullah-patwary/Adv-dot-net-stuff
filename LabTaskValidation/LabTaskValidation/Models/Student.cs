using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LabTaskValidation.Models
{
    public class Student 
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s\.\-]+$", ErrorMessage = "Only alphabets, space, dot, and dash allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ID is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Format must be XX-XXXXX-X")]
        public string StudentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^.+@student\.aiub\.edu$", ErrorMessage = "Must be a xx-xxxxx-x@student.aiub.edu email")]
        
        [ConditionalValidation]
        public string Email { get; set; }
    }

    public class ConditionalValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;

            var age = DateTime.Today.Year - student.DateOfBirth.Year;
            if (student.DateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (student.DateOfBirth > DateTime.Now)
            {
                return new ValidationResult("Date of Birth cannot be in the future");
            }

            if (age <= 20)
            {
                return new ValidationResult("Age must be greater than 20");
            }

            if (!string.IsNullOrEmpty(student.Email) && !string.IsNullOrEmpty(student.StudentId))
            {
                var emailPrefix = student.Email.Split('@')[0];
                if (emailPrefix != student.StudentId)
                {
                    return new ValidationResult("The ID part of the email must match the Student ID field");
                }
            }
            return ValidationResult.Success;
        }
    }
}
