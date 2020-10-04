using Logging.Core;
using Samantha;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace WPFCore
{
    public abstract class Startup
    {

        internal static IContainer Container;

        protected Application Application { get; private set; }

        public Startup()
        {
            Init();
        }

        private void Init()
        {
            IContainerBuilder builder = new ContainerBuilder();

            builder.Register<WindowManager>().As<IWindowManager>();
            builder.RegisterGeneric(typeof(LoggingSystem<>)).As(typeof(ILoggingSystem<>));

            ConfigureContainer(builder);
            Container = builder.Build();

            Assemblies.Add(GetType().Assembly);

            Application = Application.Current;

            Application.Startup += OnStartup;
            Application.DispatcherUnhandledException += OnUnhandledException;
            Application.Exit += OnExit;
        }

        protected virtual void OnStartup(object sender, StartupEventArgs e)
        {

        }

        protected virtual void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

        }

        protected virtual void OnExit(object sender, ExitEventArgs e)
        {

        }

        protected void ShowWindow<TViewModel>()
        {
            Container.Resolve<IWindowManager>().ShowWindow<TViewModel>();
        }

        public abstract void ConfigureContainer(IContainerBuilder containerBuilder);

    }
}
