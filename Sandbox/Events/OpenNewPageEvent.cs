using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Events
{
    public class OpenNewPageEvent : EventArgs
    {

        public Type ViewModelType { get; set; }

    }
}
