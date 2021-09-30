using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFileRepoService.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;
        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }

        public async Task<bool> Delete(string file, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            await containerClient.DeleteBlobAsync(file, Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
            return true;
        }

        public Task<bool> Exists(string file, string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> ListFiles(string path, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobs = containerClient.GetBlobsAsync(Azure.Storage.Blobs.Models.BlobTraits.All, Azure.Storage.Blobs.Models.BlobStates.All, path);
            var files = new List<string>();
            await foreach (var item in blobs)
            {
                if(item.Properties.BlobType == Azure.Storage.Blobs.Models.BlobType.Block && !item.Deleted)
                {
                    files.Add(item.Name);
                }
            }
            return files;
        }

        public Task<bool> Move(string srcFile, string destFile, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var srcBlob = containerClient.GetBlobClient(srcFile);
            srcBlob.
            throw new NotImplementedException();
        }
    }
}
