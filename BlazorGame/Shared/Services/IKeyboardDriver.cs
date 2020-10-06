using System.Threading.Tasks;

namespace BlazorGame.Shared.Services
{
    public interface IKeyboardDriver
    {
        Task<KeyboardState> GetState();
    }
}