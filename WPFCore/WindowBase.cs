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

        public void ActivatePage(Type type)
        {
            var item = Startup.Container.Resolve(type);
            var element = ViewLocator.LocateForModel(item);
            element.DataContext = item;
            ActivePage = element;
        }

        public void ActivatePage<T>()
        {
            var item = Startup.Container.Resolve<T>();
            var element = ViewLocator.LocateForModel(item);
            element.DataContext = item;
            ActivePage = element;
        }
    }
}
