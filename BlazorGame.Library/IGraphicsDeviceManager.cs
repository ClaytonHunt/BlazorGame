using System.Threading.Tasks;

namespace BlazorGame.Framework
{
    public interface IGraphicsDeviceManager
    {
        Task ApplyChanges();
        Task<bool> BeginDraw();
        Task CreateDevice();
        Task EndDraw();
    }
}
