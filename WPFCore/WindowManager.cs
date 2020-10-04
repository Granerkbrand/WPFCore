using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFCore
{
    public class WindowManager : IWindowManager
    {
        public void ShowWindow<T>()
        {
            ShowWindow(typeof(T));
        }

        public void ShowWindow(Type viewModel)
        {
            NavigationWindow navigationWindow = null;

            var application = Application.Current;

            if (application != null && application.MainWindow != null)
            {
                navigationWindow = application.MainWindow as NavigationWindow;
            }

            if (navigationWindow != null)
            {
                //Create Page
                navigationWindow.Navigate(CreatePage(Startup.Container.Resolve(viewModel)));
            }
            else
            {
                //Create Window
                var window = CreateWindow(Startup.Container.Resolve(viewModel));
                window?.Show();
            }
        }

        private Window CreateWindow(object viewModel)
        {
            var view = ViewLocator.LocateForModel(viewModel);
            ((Window)view).DataContext = viewModel;
            return view as Window;
        }

        private Page CreatePage(object viewModel)
        {
            var view = ViewLocator.LocateForModel(viewModel);
            Page page = new Page()
            {
                Content = view,
                DataContext = viewModel
            };
            return page;
        }
    }
}
