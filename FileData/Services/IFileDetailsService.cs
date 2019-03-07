namespace FileData.Services
{
    public interface IFileDetailsService
    {
        string GetVersion(string filePath);
        int GetSize(string filePath);
    }
}