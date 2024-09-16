using StudentEnrollment.API.DTOs.Student;

namespace StudentEnrollment.API.DTOs.Course
{
    public class CourseDetailsDto: CourseDto
    {
        public List<StudentDto> Students { get;set; }    = new List<StudentDto>();
    }
}
