using AutoMapper;  
using StudentEnrollment.API.DTOs.Enrollment;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace EnrollmentEnrollment.API.Endpoints
{
    public static class EnrollmentEndPoints
    {
        public static void MapEnrollmentEndPoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Enrollment", [Authorize(Roles = "Administrator")] async (IEnrollmentRepository _repo, IMapper _mapper) =>
            {
                var Enrollments = await _repo.GetAllAsync();
                var data = _mapper.Map<List<EnrollmentDto>>(Enrollments);
                return data;
            })
          .WithTags(nameof(Enrollment))
          .WithName("GetAllEnrollments")
          .Produces<List<Enrollment>>(StatusCodes.Status200OK);


            routes.MapGet("/api/Enrollment/{id}", async (int id, IEnrollmentRepository _repo, IMapper _mapper) =>
            {
                return await _repo.GetAsync(id) is Enrollment model ? Results.Ok(_mapper.Map<EnrollmentDto>(model))
                       : Results.NotFound();
            })
           .WithTags(nameof(Enrollment))
           .WithName("GetEnrollmentById")
           .Produces<EnrollmentDto>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status404NotFound);


         //   routes.MapGet("/api/Enrollment/GetDetails/{id}", async (int id, IEnrollmentRepository _repo, IMapper _mapper) =>
         //   {
         //       return await _repo.GetEnrollmentDetails(id) is Enrollment model ? Results.Ok(_mapper.Map<EnrollmentDetailsDto>(model))
         //              : Results.NotFound();
         //   })
         //.WithTags(nameof(Enrollment))
         //.WithName("GetEnrollmentDetailsById")
         //.Produces<EnrollmentDetailsDto>(StatusCodes.Status200OK)
         //.Produces(StatusCodes.Status404NotFound);



            routes.MapPut("/api/Enrollment/{id}", async (int id, EnrollmentDto EnrollmentDto, IEnrollmentRepository _repo, IMapper _mapper) =>
            {
                var Enrollment = await _repo.GetAsync(id);
                if (Enrollment is null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(EnrollmentDto, Enrollment);
                await _repo.UpdateAsync(Enrollment);
                return Results.NoContent();
            })
         .WithTags(nameof(Enrollment))
         .WithName("UpdateEnrollment")
         .Produces(StatusCodes.Status204NoContent)
         .Produces(StatusCodes.Status404NotFound);



            routes.MapPost("/api/Enrollment/{id}", async (CreateEnrollmentDto EnrollmentDto, IEnrollmentRepository _repo, IMapper _mapper) =>
            {
                var enrollment = _mapper.Map<Enrollment>(EnrollmentDto);
                await _repo.AddAsync(enrollment);
                return Results.Created($"/Enrollments/{enrollment.Id}", enrollment);
            })
   .WithTags(nameof(Enrollment))
   .WithName("CreateEnrollment")
   .Produces(StatusCodes.Status201Created);



            routes.MapDelete("/api/Enrollment/{id}", async (int id, IEnrollmentRepository _repo, IMapper _mapper) =>
            {
                return await _repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
            })
        .WithTags(nameof(Enrollment))
        .WithName("DeleteEnrollment")
        .Produces<Enrollment>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);


        }
    }
}
