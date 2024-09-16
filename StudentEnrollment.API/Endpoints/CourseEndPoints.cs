using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;

namespace StudentEnrollment.API.Endpoints
{
    public static class CourseEndPoints
    {
        public static void MapCourseEndPoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Course", async (ICourseRepository _repo, IMapper _mapper) =>
            {
                var Courses = await _repo.GetAllAsync();
                var data = _mapper.Map<List<CourseDto>>(Courses);
                return data;
            })
         .WithTags(nameof(Course))
         .WithName("GetAllCourses")
         .Produces<List<CourseDto>>(StatusCodes.Status200OK);


            routes.MapGet("/api/Course/{id}", async (int id, ICourseRepository _repo, IMapper _mapper) =>
            {
                return await _repo.GetAsync(id) is Course model ? Results.Ok(_mapper.Map<CourseDto>(model))
                       : Results.NotFound();
            })
           .WithTags(nameof(Course))
           .WithName("GetCourseById")
           .Produces<CourseDto>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status404NotFound);


            routes.MapGet("/api/Course/GetStudents/{id}", async (int id, ICourseRepository _repo, IMapper _mapper) =>
            {
                return await _repo.GetStudentList(id) is Course model ? Results.Ok(_mapper.Map<CourseDetailsDto>(model))
                       : Results.NotFound();
            })
         .WithTags(nameof(Course))
         .WithName("GetCourseDetailsById")
         .Produces<CourseDetailsDto>(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound);



            routes.MapPut("/api/Course/{id}", async (int id, CourseDto CourseDto, ICourseRepository _repo, IMapper _mapper) =>
            {
                var Course = await _repo.GetAsync(id);
                if (Course is null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(CourseDto, Course);
                await _repo.UpdateAsync(Course);
                return Results.NoContent();
            })
         .WithTags(nameof(Course))
         .WithName("UpdateCourse")
         .Produces(StatusCodes.Status204NoContent)
         .Produces(StatusCodes.Status404NotFound);



            routes.MapPost("/api/Course/{id}", async (CreateCourseDto CourseDto, ICourseRepository _repo, IMapper _mapper) =>
            {
                var Course = _mapper.Map<Course>(CourseDto);
                await _repo.AddAsync(Course);
                return Results.Created($"/Courses/{Course.Id}", Course);
            })
   .WithTags(nameof(Course))
   .WithName("CreateCourse")
   .Produces(StatusCodes.Status201Created);



            routes.MapDelete("/api/Course/{id}", async (int id, ICourseRepository _repo, IMapper _mapper) =>
            {
                return await _repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
            })
        .WithTags(nameof(Course))
        .WithName("DeleteCourse")
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        }
    }
}
