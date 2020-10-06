using System.Text.Json.Serialization;

namespace BlazorGame.Shared.Services
{
    public class ImageContent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageWidth")]
        public int Width { get; set; }

        [JsonPropertyName("imageHeight")]
        public int Height { get; set; }
    }
}