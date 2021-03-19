using BlazorGame.Framework.Graphics;
using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorGame.Framework.Content
{
    public class ContentManager : IDisposable
    {
        private string _rootDirectory;
        private readonly IJSRuntime _jsRuntime;

        public string RootDirectory => _rootDirectory;
        
        public IGraphicsDevice GraphicsDevice { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public IDictionary<string, object> ContentDictionary { get; set; } = new Dictionary<string, object>();

        public ContentManager(IServiceProvider serviceProvider)
        {
            _jsRuntime = serviceProvider.GetService<IJSRuntime>();
            _rootDirectory = "Content";
            ServiceProvider = serviceProvider;
        }

        public ContentManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            _jsRuntime = serviceProvider.GetService<IJSRuntime>();
            _ = SetRootDirectory(rootDirectory);
            ServiceProvider = serviceProvider;
        }

        public async Task Register<T>(string name, string filename) where T : IContent, new()
        {
            await _jsRuntime.InvokeAsync<T>("BlazorGame.registerContent", name, filename);
        }

        public virtual async Task<T> Load<T>(string name) where T : IContent, new()
        {
            if (ContentDictionary.ContainsKey(name))
            {
                return (T)ContentDictionary[name];
            }

            var content = await _jsRuntime.InvokeAsync<T>("BlazorGame.loadContent", name);

            Console.WriteLine(content.Name);

            ContentDictionary.Add(name, content);

            return content;
        }

        public virtual async Task Unload()
        {
            while (ContentDictionary.Count > 0)
            {
                var item = ContentDictionary.First();

                await _jsRuntime.InvokeVoidAsync("BlazorGame.unloadContent", item.Key);

                ContentDictionary.Remove(item);
            }
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
