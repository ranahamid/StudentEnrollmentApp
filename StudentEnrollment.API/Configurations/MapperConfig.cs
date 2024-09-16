using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Enrollment;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data;

namespace StudentEnrollment.API.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>() 
                .ForMember(x=>x.Students, x=> x.MapFrom(x => x.Enrollments.Select(st=>st.Student))  );

            CreateMap<Course, CreateCourseDto>().ReverseMap();


            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDto>()
            .ForMember(x => x.Courses, x => x.MapFrom(x => x.Enrollments.Select(c => c.Course)));
            CreateMap<Student, CreateStudentDto>().ReverseMap();


            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        }
    }
}
