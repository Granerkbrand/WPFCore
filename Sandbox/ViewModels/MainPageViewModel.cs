using Logging.Core;
using System.Windows;
using WPFCore.Core;

namespace Sandbox.ViewModels
{
    public class MainPageViewModel : View
    {

        public string WelcomeText { get; set; } = "Welcome user";

        public MainPageViewModel(ILoggingSystem<MainPageViewModel> logger)
        {
            WelcomeText += $", {logger}";
        }

    }
}
