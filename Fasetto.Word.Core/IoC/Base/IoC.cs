using System;
using Ninject;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the IoC container for our application
    /// </summary>
    public static class IoC
    {

        #region Public Properties

        /// <summary>
        /// the kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        /// <summary>
        /// a shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        #endregion

        #region Construction

        /// <summary>
        /// sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application start up to ensure all
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            //bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            //Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();

            //bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        /// <summary>
        /// gets a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">the type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}
