using System.Threading.Tasks;

namespace BlazorGame.Services
{
    public interface IKeyboardDriver
    {
        Task<KeyboardState> GetState();
    }
}