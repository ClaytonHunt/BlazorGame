using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BlazorGame.Framework.Content;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorGame.Client.Shared.RPG
{
    public class FileManager<T>
    {
        private readonly HttpClient _http;
        
        public FileManager(ContentManager content)
        {
            _http = content.ServiceProvider.GetService<HttpClient>();
        }

        public async Task<T> Load<T1>(string path) where T1: T
        {
            return await _http.GetFromJsonAsync<T1>(path, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}