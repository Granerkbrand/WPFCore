using Samantha;
using Sandbox.Events;
using System.Windows;
using WPFCore;

namespace Sandbox.ViewModels
{
    public class ShellViewModel : WindowBase, IEventHandler<TestEvent>, IEventHandler<OpenNewPageEvent>
    {
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.RegisterHandler<TestEvent>(this);
            eventAggregator.RegisterHandler<OpenNewPageEvent>(this);

            ActivatePage<MainPageViewModel>();
        }

        public void OnHandle(TestEvent args)
        {
            MessageBox.Show(args.Message);
        }

        public void OnHandle(OpenNewPageEvent args)
        {
            ActivatePage(args.ViewModelType);
        }
    }
}
