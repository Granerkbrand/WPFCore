using System;
using System.Collections.Generic;
using System.Text;
using WPFCore.Core;

namespace WPFCore
{
    public class WindowBase : PropertyChangedBase
    {
        private object _activePage;

        public object ActivePage
        {
            get => _activePage;
            set => SetProperty(ref _activePage, value);
        }

        public void ActivatePage(object item)
        {
            var element = ViewLocator.LocateForModel(item);
            element.DataContext = item;
            ActivePage = element;
        }
    }
}
