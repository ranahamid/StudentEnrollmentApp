using AutoMapper;
using FluentValidation;
using StudentEnrollment.API.DTOs.Enrollment;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.API.Filters;
using StudentEnrollment.API.Services;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.Endpoints
{
    public static class StudentEndPoints
    {
        public static void MapStudentEndPoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/student", async (IStudentRepository _repo, IMapper _mapper) =>
            {
                var students = await _repo.GetAllAsync();
                var data = _mapper.Map<List<StudentDto>>(students);
                return data;
            })
            .WithTags(nameof(Student))
            .WithName("GetAllStudents")
            .Produces<List<StudentDto>>(StatusCodes.Status200OK);


            routes.MapGet("/api/Student/{id}", async (int id, IStudentRepository _repo, IMapper _mapper) =>
            {
                return await _repo.GetAsync(id) is Student model ? Results.Ok(_mapper.Map<StudentDto>(model))
                       : Results.NotFound();
            })
           .WithTags(nameof(Student))
           .WithName("GetStudentById")
           .Produces<StudentDto>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status404NotFound);


            routes.MapGet("/api/Student/GetDetails/{id}", async (int id, IStudentRepository _repo, IMapper _mapper) =>
            {
                return await _repo.GetStudentDetails(id) is Student model ? Results.Ok(_mapper.Map<StudentDetailsDto>(model))
                       : Results.NotFound();
            })
         .WithTags(nameof(Student))
         .WithName("GetStudentDetailsById")
         .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound);



            routes.MapPut("/api/Student/{id}", async (int id, StudentDto studentDto, IStudentRepository _repo, IMapper _mapper,
                    IValidator<StudentDto> validator, IFileUpload _fileUpload) =>
            {
                var validationResult = await validator.ValidateAsync(studentDto);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToDictionary());
                }

                var student = await _repo.GetAsync(id);
                if (student is null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(studentDto, student);
                if (studentDto.ProfilePicture != null)
                {
                    student.Picture =
                        _fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OriginalFileName);
                }
                await _repo.UpdateAsync(student);
                return Results.NoContent();
            })
            .AddEndpointFilter<ValidationFilter<StudentDto>>()
            .AddEndpointFilter<LoggingFilter>()
         .WithTags(nameof(Student))
         .WithName("UpdateStudent")
         .Produces(StatusCodes.Status204NoContent)
         .Produces(StatusCodes.Status404NotFound);



            routes.MapPost("/api/Student/{id}", async (CreateStudentDto studentDto, IStudentRepository _repo, IMapper _mapper,
                    IValidator<CreateStudentDto> validator, IFileUpload _fileUpload) =>
            {
                var validationResult = await validator.ValidateAsync(studentDto);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToDictionary());
                }


                var student = _mapper.Map<Student>(studentDto);

             
                    student.Picture =
                        _fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OriginalFileName);
             

                await _repo.AddAsync(student);
                return Results.Created($"/students/{student.Id}", student);
            })
            //   .AddEndpointFilter<ValidationFilter<CreateStudentDto>>()
            .AddEndpointFilter<LoggingFilter>()
   .WithTags(nameof(Student))
   .WithName("CreateStudent")
   .Produces(StatusCodes.Status201Created);



            routes.MapDelete("/api/Student/{id}", async (int id, IStudentRepository _repo, IMapper _mapper) =>
            {
                return await _repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
            })
        .WithTags(nameof(Student))
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);


        }
    }
}
