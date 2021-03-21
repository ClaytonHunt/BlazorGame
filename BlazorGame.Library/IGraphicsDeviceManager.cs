namespace BlazorGame.Framework
{
    public interface IGraphicsDeviceManager
    {
        void ApplyChanges();
        bool BeginDraw();
        void CreateDevice();
        void EndDraw();
    }
}
