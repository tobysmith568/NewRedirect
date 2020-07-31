using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NewRedirect
{
    public static class Redirect
    {
        private static readonly Dictionary<string, string> Redirects = new Dictionary<string, string>
        {
            { "doc", "https://docs.google.com/document/u/0/create" },
            { "sheet", "https://docs.google.com/spreadsheets/u/0/create" }
        };

        [FunctionName("Redirect")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            string key = req.Query["key"];

            if (key == null)
            {
                return new BadRequestResult();
            }

            string newURL = Redirects.GetValueOrDefault(key);

            if (newURL == null)
            {
                return new BadRequestResult();
            }

            return new RedirectResult(newURL);
        }
    }
}
