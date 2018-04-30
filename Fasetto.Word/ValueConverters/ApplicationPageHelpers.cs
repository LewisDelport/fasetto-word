using Fasetto.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.Word
{
    /// <summary>
    /// converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            //find the appropriate page
            switch (page)
            { 
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }
        /// <summary>
        /// converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/>
        /// that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage( this BasePage page)
        {
            //find application page that matches the base page
            if (page is ChatPage)
                return ApplicationPage.Chat;
            if (page is LoginPage)
                return ApplicationPage.Login;
            if (page is RegisterPage)
                return ApplicationPage.Register;

            //alert developer of issue
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
