using System.IO;

namespace erdus.ng.Repositories
{
    public interface IFTPRepository
    {
        string SaveFile(Stream fileStream);
    }
}