using Sandbox.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFCore;
using WPFCore.Core;

namespace Sandbox.ViewModels
{
    public class NewPageViewModel : View
    {

        public string NewPageText { get; set; } = "This is a new Page";

        public ICommand OpenWelcomePageCommand { get; set; }

        public NewPageViewModel(IEventAggregator eventAggregator)
        {
            OpenWelcomePageCommand = new RelayCommand(o => eventAggregator.Invoke(new OpenNewPageEvent()
            {
                ViewModelType = typeof(MainPageViewModel)
            }));
        }

    }
}
