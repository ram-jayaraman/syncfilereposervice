using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFileRepoService.Services
{
    public interface IBlobService
    {
        Task<IEnumerable<string>> ListFiles(string path, string containerName);
        Task<bool> Move(string srcFile, string destFile, string containerName);
        Task<bool> Delete(string file, string containerName);
        Task<bool> Exists(string file, string containerName);
    }
}
