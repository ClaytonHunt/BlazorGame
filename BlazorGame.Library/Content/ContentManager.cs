using BlazorGame.Framework.Graphics;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorGame.Framework.Content
{
    public class ContentManager : IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private string _rootDirectory;

        public string RootDirectory => _rootDirectory;
        
        public IGraphicsDevice GraphicsDevice { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public ContentManager(IJSRuntime jsRuntime)        
        {
            _jsRuntime = jsRuntime;
        }

        public ContentManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            _rootDirectory = rootDirectory;
            ServiceProvider = serviceProvider;
        }

        public void Register<T>(string name, string filename) where T : IContent, new()
        {
            _jsRuntime.InvokeAsync<T>("BlazorGame.registerContent", name, filename);
        }

        public virtual async Task<T> Load<T>(string name) where T : IContent, new()
        {
            var content = await _jsRuntime.InvokeAsync<T>("BlazorGame.loadContent", name);

            return content;
        }

        public virtual void Unload()
        {
            throw new NotImplementedException();
        }

        public async Task SetRootDirectory(string path)
        {
            _rootDirectory = await _jsRuntime.InvokeAsync<string>("BlazorGame.setRootDirectory", path);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }
    }
}
