using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace WPFCore
{
    public interface IEventAggregator
    {

        void RegisterHandler<T>(IEventHandler<T> handler) where T : EventArgs;

        public void Invoke<T>(T eventArg) where T : EventArgs;

    }
}
