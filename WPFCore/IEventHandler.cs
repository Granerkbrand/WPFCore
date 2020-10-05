using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCore
{

    public interface IEventHandler<T> where T : EventArgs
    {

        void OnHandle(T args);

    }
}
