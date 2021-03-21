using BlazorGame.Framework.Graphics;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorGame.Framework.Content
{
    public class ContentManager : IDisposable
    {
        private string _rootDirectory;
        private readonly IJSInProcessRuntime _jsRuntime;

        public string RootDirectory => _rootDirectory;
        
        public IGraphicsDevice GraphicsDevice { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public IDictionary<string, object> ContentDictionary { get; set; } = new Dictionary<string, object>();

        public ContentManager(IServiceProvider serviceProvider)
        {
            _jsRuntime = (IJSInProcessRuntime)serviceProvider.GetService<IJSRuntime>();
            _rootDirectory = "Content";
            ServiceProvider = serviceProvider;
        }

        public ContentManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            _jsRuntime = (IJSInProcessRuntime)serviceProvider.GetService<IJSRuntime>();
            SetRootDirectory(rootDirectory);
            ServiceProvider = serviceProvider;
        }

        public void Register<T>(string name, string filename) where T : IContent, new()
        {
            _jsRuntime.Invoke<T>("BlazorGame.registerContent", name, filename);
        }

        public virtual T Load<T>(string name) where T : IContent, new()
        {
            if (ContentDictionary.ContainsKey(name))
            {
                return (T)ContentDictionary[name];
            }

            var content = _jsRuntime.Invoke<T>("BlazorGame.loadContent", name);

            Console.WriteLine(content.Name);

            ContentDictionary.Add(name, content);

            return content;
        }

        public virtual Task Unload()
        {
            while (ContentDictionary.Count > 0)
            {
                var item = ContentDictionary.First();

                _jsRuntime.Invoke<object>("BlazorGame.unloadContent", item.Key);

                ContentDictionary.Remove(item);
            }

            return Task.CompletedTask;
        }

        public void SetRootDirectory(string path)
        {
            _rootDirectory = _jsRuntime.Invoke<string>("BlazorGame.setRootDirectory", path);
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
