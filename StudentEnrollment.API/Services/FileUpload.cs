namespace StudentEnrollment.API.Services
{
    public class FileUpload: IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileUpload(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public string UploadStudentFile(byte[] file, string imageName)
        {
            if(file== null || string.IsNullOrEmpty(imageName))
            {
                return string.Empty;
            }

            var folderPath = "studentPictures";
            var url = _httpContextAccessor.HttpContext?.Request.Host.Value;
            var extension = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{extension}";

            var path = $"{_webHostEnvironment.WebRootPath}\\{folderPath}\\{fileName}";
            UploadFile(file, path);
            return $"https://{url}/{folderPath}/{fileName}";
            
        }
        public void UploadFile(byte[] file, string path)
        {
            FileInfo fileInfo = new(path);
            fileInfo?.Directory?.Create();

            var stream = fileInfo?.Create();
            stream?.Write(file, 0, file.Length);
            stream?.Close();
        }
    }
}
