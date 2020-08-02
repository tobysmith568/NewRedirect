using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using NewRedirect.Storage;

namespace NewRedirect.Functions
{
    public static class Redirect
    {
        [FunctionName("Redirect")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "redirect")] HttpRequest req)
        {
            string key = req.Query["key"];

            if (key == null)
            {
                return new BadRequestResult();
            }

            string? newURL = RedirectRepository.Get(key);

            if (newURL == null)
            {
                return new BadRequestResult();
            }

            return new RedirectResult(newURL);
        }
    }
}
