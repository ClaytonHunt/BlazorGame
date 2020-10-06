namespace BlazorGame.Shared.Services
{
    public interface IContent
    {
        string Path { get; set; }
        int Position { get; set; }
    }

    public interface IContent<T> : IContent
    {
        T Content { get; set; }
    }
}