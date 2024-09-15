var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.StudentEnrollment_API>("studentenrollment-api");

builder.Build().Run();
