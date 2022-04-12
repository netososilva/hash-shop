using HashShop.Handlers.Interfaces;

namespace HashShop.Handlers.Base
{
    public abstract class BaseHandler<T> : IHandler<T>
    {
        protected IHandler<T> _nextHandler;

        public virtual void Handle(T request)
        {
            if (_nextHandler != null) _nextHandler.Handle(request);
        }
        
        public void SetNext(IHandler<T> handler)
        {
            _nextHandler = handler;
        }
    }
}
