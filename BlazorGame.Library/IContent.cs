namespace BlazorGame.Framework
{
    public interface IContent
    {
        string Name { get; set; }
        string Path { get; set; }        
    }

    public interface IContent<T> : IContent
    {
        T Content { get; set; }
    }
}