using System.IO;

namespace CaptureService
{
    public class DirectoryCreator
    {
        public void CreateDirectories(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
