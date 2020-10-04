using Samantha;
using Sandbox.ViewModels;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace Sandbox
{
    class Startup : WPFCore.Startup
    {

        public Startup()
        {

        }

        public override void ConfigureContainer(IContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterSelf();

            containerBuilder.RegisterAssemplyTypes(Assembly.GetExecutingAssembly())
                .Where(e => e.ConstructionType.Name.EndsWith("ViewModel"));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            ShowWindow<ShellViewModel>();
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Application?.MainWindow?.Close();
        }

        protected override void OnExit(object sender, ExitEventArgs e)
        {

        }
    }
}
