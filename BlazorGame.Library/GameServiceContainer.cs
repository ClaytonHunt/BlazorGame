using System;

namespace BlazorGame.Framework
{
    public class GameServiceContainer : IServiceProvider
    {
        public GameServiceContainer()
        {

        }

        public T GetService<T>() where T : class
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void AddService<T>(T provider)
        {
            AddService(typeof(T), provider);
        }

        public void AddService(Type type, object provider)
        {

        }  
        
        public void RemoveService(Type type)
        {

        }
    }
}
