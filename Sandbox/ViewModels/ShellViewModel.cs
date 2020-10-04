using System;
using System.Collections.Generic;
using System.Text;
using WPFCore;

namespace Sandbox.ViewModels
{
    public class ShellViewModel : WindowBase
    {
        public ShellViewModel(MainPageViewModel viewModel)
        {
            ActivatePage(viewModel);
        }
    }
}
