using Microsoft.JSInterop;

namespace BlazorGame.Framework.Input
{
    public class JsKeyboardDriver : IKeyboardDriver
    {
        private readonly IJSRuntime _jsRuntime;

        public JsKeyboardDriver(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        //public async Task<KeyboardState> GetState()
        //{
        //    return await _jsRuntime.InvokeAsync<KeyboardState>("BlazorGame.getKeyState");
        //}
    }
}