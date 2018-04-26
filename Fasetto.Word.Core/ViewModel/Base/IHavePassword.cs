using System.Security;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// an interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// the secure password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
