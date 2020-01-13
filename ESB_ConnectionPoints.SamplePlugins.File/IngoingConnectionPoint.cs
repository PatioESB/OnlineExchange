using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
    /// <summary>
    /// Входящая точка подключения для передачи сообщений в шину.
    /// </summary>
    public sealed class IngoingConnectionPoint
        : IStandartIngoingConnectionPoint
    {
        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Фабрика сообщений.
        /// </summary>
        private readonly IMessageFactory _messageFactory;

        /// <summary>
        /// Директория с файлами.
        /// </summary>
        private readonly string _inputDirectory;

        /// <summary>
        /// Шаблон для поиска файлов (пример - *.txt).
        /// </summary>
        private readonly string _fileNamePattern;

        /// <summary>
        /// Интервал чтения директории.
        /// </summary>
        private TimeSpan _readInterval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Список обработанных файлов.
        /// </summary>
        private readonly HashSet<string> _processedFiles = new HashSet<string>();

        public IngoingConnectionPoint( string fileNamePattern,
            IServiceLocator serviceLocator)
        {

            _logger = serviceLocator.GetLogger(GetType());
            _messageFactory = serviceLocator.GetMessageFactory();
            _fileNamePattern = fileNamePattern;
        }

        public void Initialize()
        {

        }

        public void Run(IMessageHandler messageHandler, CancellationToken ct)
        {
            
        }

        public void Cleanup()
        {
        }

        public void Dispose()
        {
        }

    }
}
