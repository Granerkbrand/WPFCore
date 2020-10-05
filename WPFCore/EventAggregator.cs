using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WPFCore
{
    public class EventAggregator : IEventAggregator
    {

        private readonly Dictionary<Type, List<object>> _eventHandlers;

        public EventAggregator()
        {
            _eventHandlers = new Dictionary<Type, List<object>>();
        }

        public void RegisterHandler<T>(IEventHandler<T> handler) where T : EventArgs
        {
            if (_eventHandlers.ContainsKey(typeof(T)))
            {
                _eventHandlers[typeof(T)].Add(handler);
            }
            else
            {
                _eventHandlers.Add(typeof(T), new List<object>() { handler });
            }
        }

        public void Invoke<T>(T eventArg) where T: EventArgs
        {
            if(_eventHandlers.TryGetValue(typeof(T), out List<object> eventHandlers))
            {
                foreach(var handlerObj in eventHandlers)
                {
                    var handler = (IEventHandler<T>)handlerObj;
                    handler.OnHandle(eventArg);
                }
            }
        }
    }
}
