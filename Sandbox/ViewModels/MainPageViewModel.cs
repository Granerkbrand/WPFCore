using Logging.Core;
using Sandbox.Events;
using System;
using System.Windows;
using WPFCore;
using WPFCore.Core;

namespace Sandbox.ViewModels
{
    public class MainPageViewModel : View
    {

        public string WelcomeText { get; set; } = "Welcome user";

        public RelayCommand OpenTestCommand { get; set; }

        public RelayCommand OpenNewPageCommand { get; set; }

        public MainPageViewModel(ILoggingSystem<MainPageViewModel> logger, IEventAggregator eventAggregator)
        {
            WelcomeText += $", {logger}";

            OpenTestCommand = new RelayCommand(o => eventAggregator.Invoke(new TestEvent()
            {
                Message = $"Test: {DateTime.Now}"
            }));

            OpenNewPageCommand = new RelayCommand(o => eventAggregator.Invoke(new OpenNewPageEvent()
            {
                ViewModelType = typeof(NewPageViewModel)
            }));
        }

    }
}
