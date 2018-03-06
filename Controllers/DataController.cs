using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncryptionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/data")]
    public class DataController : Controller
    {
        [HttpPost]
        public string Post([FromBody] Data data)
        {
            var xor = new XOREncryptionAlgorithm();
            string output = xor.EncryptDecrypt(data.Text, data.Key, data.Option);
            return output;
        }
    }
}