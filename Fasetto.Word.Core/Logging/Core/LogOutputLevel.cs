namespace Fasetto.Word.Core
{
    /// <summary>
    /// the level of detail to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// logs everything
        /// </summary>
        Debug = 1,
        /// <summary>
        /// log all information except debug information
        /// </summary>
        Verbose = 2,
        /// <summary>
        /// logs all informative messages, ignoring any debug and verbose messages
        /// </summary>
        Informative = 3,
        /// <summary>
        /// log only critical errors and warnings and success, but no general information
        /// </summary>
        Critical = 4,
        /// <summary>
        /// the logger will output nothing
        /// </summary>
        Nothing = 7
    }
}
