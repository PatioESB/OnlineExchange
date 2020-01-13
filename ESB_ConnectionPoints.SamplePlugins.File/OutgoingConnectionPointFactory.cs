using System;
using System.Collections.Generic;
using ESB_ConnectionPoints.PluginsInterfaces;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
    /// <summary>
    /// Фабрика для создания исходящей точки подключения.
    /// </summary>
    public sealed class OutgoingConnectionPointFactory
        : IOutgoingConnectionPointFactory
    {
        //public const string OUTPUT_DIRECTORY_PARAMETER = "OutputDirectory";
        public const string LOGIN = @"Имя пользователя";
        public const string PASSWORD = @"Пароль";
        public const string CONNECTION_POINT = @"Учетная система";
        public const string EXTERNAL_SYSTEM = @"Внешняя система";
        public const string DESTINATION_SERVER = @"Сервер назначения";
        public const string ADRESS_END_POINT = @"Адрес сервиса";

        public IOutgoingConnectionPoint Create(Dictionary<string, string> parameters,
            IServiceLocator serviceLocator)
        {
            string Login = parameters[LOGIN];
            string Password = parameters[PASSWORD];
            string Point = parameters[CONNECTION_POINT];
            string System = parameters[EXTERNAL_SYSTEM];
            string Server = parameters[DESTINATION_SERVER];
            string address = parameters[ADRESS_END_POINT];

            return new OutgoingConnectionPoint( serviceLocator , Login , Password , Point , System , Server , address);
        }
    }
}
