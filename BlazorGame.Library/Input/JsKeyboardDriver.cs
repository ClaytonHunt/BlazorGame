using Microsoft.JSInterop;

namespace BlazorGame.Framework.Input
{
    public class JsKeyboardDriver : IKeyboardDriver
    {
        private readonly IJSInProcessRuntime _jsRuntime;

        public JsKeyboardDriver(IJSRuntime jsRuntime)
        {
            _jsRuntime = (IJSInProcessRuntime)jsRuntime;
        }

        public KeyboardState GetState()
        {
            return _jsRuntime.Invoke<KeyboardState>("BlazorGame.getKeyState");
        }
    }
}