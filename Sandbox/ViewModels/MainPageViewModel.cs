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

        private string _message;

        public string WelcomeText { get; set; } = "Welcome user";

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public RelayCommand OpenTestCommand { get; set; }

        public RelayCommand OpenNewPageCommand { get; set; }

        public MainPageViewModel(ILoggingSystem<MainPageViewModel> logger, IEventAggregator eventAggregator)
        {
            OpenTestCommand = new RelayCommand(o => eventAggregator.Invoke(new TestEvent()
            {
                Message = $"Input: {Message}"
            }));

            OpenNewPageCommand = new RelayCommand(o => eventAggregator.Invoke(new OpenNewPageEvent()
            {
                ViewModelType = typeof(NewPageViewModel)
            }));
        }

    }
}
