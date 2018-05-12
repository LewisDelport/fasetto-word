using Fasetto.Word.Core;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //let the base application do what it needs
            base.OnStartup(e);

            //setup the main application
            ApplicationSetup();

            IoC.Logger.Log("Application starting...", LogLevel.Debug);

            //show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
        /// <summary>
        /// configures our application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            //setup IoC
            IoC.Setup();

            //bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }
    }
}
