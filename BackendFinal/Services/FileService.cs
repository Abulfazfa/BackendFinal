using BackendFinal.Services.Interfaces;

namespace BackendFinal.Services
{
    public class FileService : IFileService
    {
        public string ReadFile(string path, string body)
        {
            using(StreamReader stream = new StreamReader(path))
            {
                body = stream.ReadToEnd();
            }
            return body;
        }
    }
}
