using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SyncFileRepoService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyncFileRepoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncFilesController : ControllerBase
    {
        private readonly ILogger<SyncFilesController> _logger;
        private readonly IBlobService _blobService;

        //private readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=funtoot;AccountKey=XmKrQBRlz/U+oXyTpZ0ts+p1BZyEA2aoISxjOgUcHcxMw6zMF4DjDXqFEe7tOWhhnI2vtY8duwQBCYXnZv/CQQ==;EndpointSuffix=core.windows.net";

        public SyncFilesController(ILogger<SyncFilesController> logger, IBlobService blobService)
        {
            _logger = logger;
            _blobService = blobService;
        }

        // GET: api/<SyncFilesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get([FromQuery] string path)
        {
            return await _blobService.ListFiles(path, "sync");
            //return new string[] { "value1", "value2" };
        }

        // GET api/<SyncFilesController>/5
        //[HttpGet("{path}")]
        //public string Get(string path)
        //{
        //    return $"{path}";
        //}

        // POST api/<SyncFilesController>
        [HttpPost]
        public void Post([FromQuery] string path, [FromForm] IFormFile file)
        {
        }

        // PUT api/<SyncFilesController>/5
        [HttpPut]
        public void Put([FromQuery] string path, [FromBody] string newPath)
        {
        }

        // DELETE api/<SyncFilesController>/5
        [HttpDelete]
        public async void Delete(string path)
        {
            await _blobService.Delete(path, "sync");
        }
    }
}
