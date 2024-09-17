using FluentValidation;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.DTOs.Authentication
{
    public class RegisterDto: LoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            Include(new LoginDtoValidator());
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .Must( (dob) =>
                {
                    if (dob.HasValue)
                    {
                        return dob.Value < DateTime.UtcNow.AddYears(-12);
                    } 
                    return true;
                });
        }
    }
}
 