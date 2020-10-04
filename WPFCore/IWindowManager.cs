using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCore
{
    public interface IWindowManager
    {

        void ShowWindow<T>();
        void ShowWindow(Type viewModel);

    }
}
