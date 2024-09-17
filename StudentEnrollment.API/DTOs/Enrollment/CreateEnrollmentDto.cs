using FluentValidation;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.DTOs.Enrollment
{
    public class CreateEnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

    }
    public class CreateEnrollmentDtoValidator : AbstractValidator<CreateEnrollmentDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
         
        public CreateEnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {

            _courseRepository = courseRepository;
            _studentRepository = studentRepository;

            RuleFor(x => x.CourseId)
                .MustAsync(async (id, token) =>
                {
                    var courseExist =await _courseRepository.Exists(id);
                    return courseExist;
                }).WithMessage("{PropertyName} does not exist");
            RuleFor(x => x.StudentId)
                .MustAsync(async (id, token) =>
                {
                    var studentExist = await _studentRepository.Exists(id);
                    return studentExist;
                }).WithMessage("{PropertyName} does not exist");
        }
    }
}
