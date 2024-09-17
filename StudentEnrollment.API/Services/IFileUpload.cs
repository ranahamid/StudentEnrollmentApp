namespace StudentEnrollment.API.Services
{
    public interface IFileUpload
    {
        string UploadStudentFile(byte[]file, string fileName);
    }
}
