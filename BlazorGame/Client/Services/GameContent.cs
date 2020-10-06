using System.Threading.Tasks;
using BlazorGame.Shared.Services;
using Microsoft.JSInterop;

namespace BlazorGame.Client.Services
{
    public class GameContent
    {
        private readonly IJSRuntime _jsRuntime;
        private string _rootDirectory;

        public GameContent(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Register<T>(string name, string filename) where T : IContent, new()
        {
            await _jsRuntime.InvokeAsync<T>("BlazorGame.registerContent", name, filename);
        }

        public async Task<T> Load<T>(string name) where T : IContent, new()
        {
            var content = await _jsRuntime.InvokeAsync<T>("BlazorGame.loadContent", name);

            return content;
        }

        public string RootDirectory
        {
            get => _rootDirectory;
            set
            {
                Task.Run(async () =>
                {
                    _rootDirectory = await _jsRuntime.InvokeAsync<string>("BlazorGame.setRootDirectory", value);
                });
            }
        }
    }
}