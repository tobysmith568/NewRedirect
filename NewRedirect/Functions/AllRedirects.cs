using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NewRedirect.Storage;

namespace NewRedirect.Functions
{
    public static class AllRedirects
    {
        [FunctionName("AllRedirects")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "all")] HttpRequest req)
        {
            return new OkObjectResult(RedirectRepository.Get());
        }
    }
}
