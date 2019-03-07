using ThirdPartyTools;

namespace FileData.Service
{
    public interface IFileDetailsService
    {
        string GetVersion(string filePath);
        int GetSize(string filePath);
    }
    public class FileDetailsService : IFileDetailsService
    {
        private readonly FileDetails _fileDetails;

        public FileDetailsService(FileDetails fileDetails)
        {
            _fileDetails = fileDetails;
        }
        public string GetVersion(string filePath)
        {
            return _fileDetails.Version(filePath);
        }

        public int GetSize(string filePath)
        {
            return _fileDetails.Size(filePath);
        }
    }
}
