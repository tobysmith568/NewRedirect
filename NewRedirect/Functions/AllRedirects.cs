using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using NewRedirect.Storage;

namespace NewRedirect.Functions
{
    public static class AllRedirects
    {
        [FunctionName("AllRedirects")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "all")] HttpRequest _)
        {
            return new OkObjectResult(RedirectRepository.Get());
        }
    }
}
