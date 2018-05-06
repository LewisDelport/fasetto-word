using System;
using System.Runtime.CompilerServices;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// holds a bunch of loggers to log messages for the user
    /// </summary>
    public interface ILogFactory
    {

        #region Properties

        /// <summary>
        /// the level of logging to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }
        /// <summary>
        /// if true, includes the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Methods

        /// <summary>
        /// adds the specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        void AddLogger(ILogger logger);
        /// <summary>
        /// removes the specified logger from this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        void RemoveLogger(ILogger logger);
        /// <summary>
        /// logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="Message">the message to log</param>
        /// <param name="level">the level of the message being logged</param>
        /// <param name="origin">the method/function this message was logged in</param>
        /// <param name="filePath">the code filename that this message was logged from</param>
        /// <param name="lineNumber">the line of code in the filename this message was logged from</param>
        void Log(string message, LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);


        #endregion
    }
}
