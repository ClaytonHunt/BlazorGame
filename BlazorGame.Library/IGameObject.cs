namespace BlazorGame.Framework
{
    interface IGameObject
    {
        virtual void Update(float elapsedTime) { }
        virtual void Draw() { }
    }
}
