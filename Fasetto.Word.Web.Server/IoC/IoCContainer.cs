using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fasetto.Word.Web.Server
{
    /// <summary>
    /// a shorthand access class to get DI(dependency injection) services with nice short clean code
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// the scoped instance of the <see cref="ApplicationDbContext"/>
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();
    }
    /// <summary>
    /// the dependency injection container making use of the built in .net core service provider
    /// </summary>
    public static class IoCContainer
    {
        /// <summary>
        /// the service provider for this application
        /// </summary>
        public static ServiceProvider Provider { get; set; }
    }
}
