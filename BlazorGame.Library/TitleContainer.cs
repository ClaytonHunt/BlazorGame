using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorGame.Framework
{
    public static class TitleContainer
    {
        public static HttpClient Http { get; set; }
        public static Task<Stream> OpenStream(string name)
        {
            return Http.GetStreamAsync($"/{name}");
        }
    }
}
