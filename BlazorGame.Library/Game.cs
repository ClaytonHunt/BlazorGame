using BlazorGame.Framework.Content;
using BlazorGame.Framework.Graphics;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorGame.Framework
{
    public class Game : ComponentBase, IDisposable
    {
        public GameComponentCollection Components { get; }
        
        [CascadingParameter]
        public ContentManager Content { get; set; }

        [CascadingParameter]
        public IGraphicsDevice GraphicsDevice { get; protected set; }

        public TimeSpan InactiveSleepTime { get; set; }
        public bool IsActive { get; }
        public bool IsFixedTimeStep { get; set; }
        public bool IsMouseVisible { get; set; }
        public LaunchParameters LaunchParameters { get; }
        public TimeSpan MaxElapsedTime { get; set; }
        public GameServiceContainer Services { get; }
        public TimeSpan TargetElapsedTime { get; set; }
        public GameWindow Window { get; }

        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> Exiting;

        public void Run()
        {

        }

        public void Run(GameRunBehavior runBehavior)
        {

        }

        public void RunOneFrame()
        {

        }

        public void SuppressDraw()
        {

        }

        public void ResetElapsedTime()
        {

        }

        public void Tick()
        {

        }

        public void Exit()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        protected virtual async Task InitializeAsync()
        {
            await Task.Run(() => {
                while(GraphicsDevice == null) 
                { 
                    Thread.Sleep(100); 
                };
            });

            await LoadContent();

            GraphicsDevice.OnReady += (gameTime) =>
            {                    
                BeginRun();
                Update(gameTime);

                if (BeginDraw())
                {
                    Draw(gameTime);
                    EndDraw();
                }
            };            
        }

        protected virtual Task LoadContent()
        {
            return Task.CompletedTask;
        }

        protected virtual void UnloadContent()
        {
            throw new NotImplementedException();
        }

        protected virtual void BeginRun() { }

        protected virtual void EndRun()
        {
            throw new NotImplementedException();
        }

        protected virtual void Initialize()
        {
            throw new NotImplementedException();
        }

        protected virtual Task Update(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        protected virtual bool BeginDraw()
        {
            return true;
        }

        protected virtual void Draw(GameTime gameTime) { }

        protected virtual void EndDraw() { }

        protected virtual void OnActivated(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeactivated(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected void Finalize()
        {

        }
    }
}
