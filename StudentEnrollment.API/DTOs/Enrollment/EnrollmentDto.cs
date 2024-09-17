using FluentValidation;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.DTOs.Enrollment
{
    public class EnrollmentDto: CreateEnrollmentDto
    {
        public int Id { get; set; }
        public virtual CourseDto Course { get; set; }
        public virtual StudentDto Student { get; set; }
    }

    public class EnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
    { 
        public EnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {  
            Include(new CreateEnrollmentDtoValidator(courseRepository, studentRepository));
        }
    }

}
