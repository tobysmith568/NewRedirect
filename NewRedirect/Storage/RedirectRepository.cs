using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewRedirect.Storage
{
    public class Redirection
    {
        public string Key { get; set; }
        public string Location { get; set; }

        public Redirection(string key, string location)
        {
            Key = key;
            Location = location;
        }
    }

    public static class RedirectRepository
    {
        private static readonly Dictionary<string, string> redirectData = new Dictionary<string, string>
        {
            { "doc", "https://docs.google.com/document/u/0/create" },
            { "sheet", "https://docs.google.com/spreadsheets/u/0/create" },
            { "slides", "https://docs.google.com/presentation/u/0/create" },
            { "form", "https://docs.google.com/forms/u/0/create" }
        };

        public static Redirection[] Get()
        {
            return redirectData.Select(r => new Redirection(r.Key, r.Value)).ToArray();
        }

        public static string? Get(string key)
        {
            return redirectData.GetValueOrDefault(key);
        }
    }
}
