using System.Text.Json.Serialization;

namespace BlazorGame.Framework.Graphics
{
    public class FileContent<T> : IContent<T>
    {        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public string Path { get; set; }        

        public T Content { get; set; }
    }
}