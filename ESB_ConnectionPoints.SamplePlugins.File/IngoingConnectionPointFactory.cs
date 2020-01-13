using System;
using System.Collections.Generic;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
    /// <summary>
    /// Фабрика для создания входящей точки подключения.
    /// </summary>
    public sealed class IngoingConnectionPointFactory
        : IIngoingConnectionPointFactory
    {
        //public const string INPUT_DIRECTORY_PARAMETER = "InputDirectory";
        public const string FILE_NAME_PATTERN_PARAMETER = "FileNamePattern";

        public IIngoingConnectionPoint Create(Dictionary<string, string> parameters,
            IServiceLocator serviceLocator)
        {

           // string inputDirectory = parameters[INPUT_DIRECTORY_PARAMETER];
            string fileNamePattern = "*.*";
            if (parameters.ContainsKey(FILE_NAME_PATTERN_PARAMETER))
            {
                fileNamePattern = parameters[FILE_NAME_PATTERN_PARAMETER];
            }

            return new IngoingConnectionPoint( fileNamePattern, serviceLocator);
        }
    }
}
