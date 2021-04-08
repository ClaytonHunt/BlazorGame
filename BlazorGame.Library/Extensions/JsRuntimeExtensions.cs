using System.IO;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;

namespace BlazorGame.Framework.Extensions
{
    public static class JsRuntimeExtensions
    {
        public static async Task<IJSObjectReference> ImportAsync<T>(this IJSRuntime jSRuntime, string path)
        {
            var libraryName = typeof(T).Assembly.GetName().Name;

            return await jSRuntime.InvokeAsync<IJSObjectReference>("import", Path.Combine($"./_content/{libraryName}/", path));
        }
    }  
}
