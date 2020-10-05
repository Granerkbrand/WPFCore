using Logging.Core;
using Samantha;
using Sandbox.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPFCore;

namespace Sandbox.ViewModels
{
    public class ShellViewModel : WindowBase, IEventHandler<TestEvent>, IEventHandler<OpenNewPageEvent>
    {

        private readonly IContainer _container;

        public ShellViewModel(IContainer container, IEventAggregator eventAggregator, MainPageViewModel viewModel)
        {
            ActivatePage(viewModel);
            eventAggregator.RegisterHandler<TestEvent>(this);
            eventAggregator.RegisterHandler<OpenNewPageEvent>(this);

            _container = container;
        }

        public void OnHandle(TestEvent args)
        {
            MessageBox.Show(args.Message);
        }

        public void OnHandle(OpenNewPageEvent args)
        {
            ActivatePage(_container.Resolve(args.ViewModelType));
        }
    }
}
