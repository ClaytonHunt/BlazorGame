using System.Threading.Tasks;

namespace BlazorGame.Library
{
    public interface IKeyboardDriver
    {
        Task<KeyboardState> GetState();
    }
}