using System;
using ESB_ConnectionPoints.PluginsInterfaces;
using System.Text;
using ESB_ConnectionPoints.SamplePlugins.File.BPMExchange;
using System.ServiceModel;
using ESB_ConnectionPoints.SamplePlugins.File.axaptaGate;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
    /// <summary>
    /// Исходящая точка подключения для обработки сообщений из шины данных.
    /// </summary>
    public sealed class OutgoingConnectionPoint
        : ISimpleOutgoingConnectionPoint
    {
        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Логин
        /// </summary>
        private readonly string _login;

        /// <summary>
        /// Пароль
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// Приемник сообщений
        /// </summary>
        private readonly string _connectionPoint;

        /// <summary>
        /// Конечная система
        /// </summary>
        private readonly string _system;

        /// <summary>
        /// Конечный сервер
        /// </summary>
        private readonly string _server;

        /// <summary>
        /// Адрес wsdl
        /// </summary>
        private readonly string _wsdlAddress;
        public OutgoingConnectionPoint(IServiceLocator serviceLocator, string Login, string Password, string Point , string Server , string System , string address )
        {
            _connectionPoint = Point;
            _logger = serviceLocator.GetLogger(GetType());
            _login = Login;
            _password = Password;
            _server = Server;
            _system = System;
            _wsdlAddress = address;
        }

        public void Initialize()
        {
            if (string.IsNullOrEmpty(_connectionPoint))
            {
                throw new Exception("Не задан параметр <Connection point>");
            }

            if (_connectionPoint == "1C")
            {
                if (string.IsNullOrEmpty(_login) || string.IsNullOrEmpty(_password))
                {
                    throw new Exception("Не задан логин или пароль, для приложение 1с обязательное заполнение.");
                }

            }
        }

        public bool HandleMessage(PluginsInterfaces.Message message, IMessageReplyHandler replyHandler)
        {
            try
            {
                if (_connectionPoint == "1C")
                {                    
                    BPMExchangePortTypeClient ws = connectionServiceUT(_password, _login);
                    var receiptMethod = ws.SendMessageAsync(createOutgoingMessageUT(message)).ConfigureAwait(false).GetAwaiter();
                    receiptMethod.OnCompleted(() =>
                        {
                            try
                            {
                                var replyMessage = createReplyMessageUT(receiptMethod.GetResult(), message);
                                replyHandler.HandleReplyMessage(replyMessage);
                                _logger.Debug("Ответ сформирован :" + Encoding.UTF8.GetString(replyMessage.Body));
                                ws.Close();
                            }
                            catch (Exception ex)
                            {
                                replyHandler.HandleReplyMessage(createAndSendCatchMessage(ex.Message, message));
                                _logger.Error(ex.Message);
                                ws.Abort();
                            }
                        });
                }
                else if (_connectionPoint == "Axapta")
                {
                    IntegrationaxSoapClient ws = connectionAxapteService();
                    var receiptMethod = ws.sendMessageAsync(createOutgoingMessageAxapta(message)).ConfigureAwait(false).GetAwaiter();
                    receiptMethod.OnCompleted(() =>
                    {
                        try
                        {
                            var replyMessage = createReplyMessageAxapta(receiptMethod.GetResult(), message );
                            replyHandler.HandleReplyMessage(replyMessage);
                            _logger.Debug("Ответ сформирован :" + Encoding.UTF8.GetString(replyMessage.Body));
                            ws.Close();

                        }
                        catch (Exception ex)
                        {
                            replyHandler.HandleReplyMessage(createAndSendCatchMessage(ex.Message, message));
                            _logger.Error(ex.Message);
                            ws.Abort();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка HandleMessage " + ex.Message);
            }
            return true;
        }

        public bool IsReady()
        {
            return true;
        }

        public void Cleanup()
        {
        }

        public void Dispose()
        {
        }

        public void receiptMessage(PluginsInterfaces.Message _inMessage, string _ulr, string _password, string _login)
        {
            //string OutResp;
            //var data = _inMessage.Body;
            //string outMessage = "";

            //try
            //{
            //    string soapEnv = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:bpm=""http://srv-1c-web.patio-minsk.by/BPMExchange/"">
            //        <soapenv:Header/>
            //         <soapenv:Body> 
            //            <bpm:SendMessage>   
            //                <bpm:Request>   
            //                    <bpm:Id>5</bpm:Id>        
            //                    <bpm:Type>" + _inMessage.Type + @"</bpm:Type>             
            //                    <bpm:ClassId>" + _inMessage.ClassId + @"</bpm:ClassId>                   
            //                    <bpm:Body><![CDATA[" + Encoding.UTF8.GetString(data) + @"]]></bpm:Body>
            //                    <bpm:ExternalSystem>?</bpm:ExternalSystem>
            //                    <bpm:DestinationServer>?</bpm:DestinationServer>  
            //                </bpm:Request> 
            //            </bpm:SendMessage>   
            //        </soapenv:Body>
            //    </soapenv:Envelope>";

            //    _logger.Debug("Сформированное тело для отправки \n" + soapEnv);
            //    //Запрос
            //    WebRequest request = HttpWebRequest.Create(_ulr);
            //    request.Credentials = new NetworkCredential(_login, _password);

            //    request.Method = "POST";
            //    request.ContentType = "text/xml; charset=UTF-8";
            //    request.ContentLength = soapEnv.Length;
            //    request.Headers.Add("SOAPAction", "http://srv-1c-web.patio-minsk.by/BPMExchange/#BPMExchange:SendMessage");


            //    //Пишем тело
            //    StreamWriter sw = new StreamWriter(request.GetRequestStream());
            //    sw.Write(soapEnv);
            //    sw.Close();
            //    //Читаем ответ
            //    WebResponse response = request.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    OutResp = reader.ReadToEnd();
            //    reader.Close();

            //    XmlDocument docXML = new XmlDocument(); //Xml документ
            //    docXML.LoadXml(OutResp); // Загрузка xml
            //    XmlNamespaceManager _namespaceManager = new XmlNamespaceManager(docXML.NameTable); // Инициализация NS
            //    _namespaceManager.AddNamespace("m", "http://srv-1c-web.patio-minsk.by/BPMExchange/");
            //    _namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");

            //    string _status = docXML.DocumentElement.SelectNodes("/soap:Envelope/soap:Body/m:SendMessageResponse/m:return/m:resultStatus", _namespaceManager)[0].InnerXml;
            //    string _body = docXML.DocumentElement.SelectNodes("/soap:Envelope/soap:Body/m:SendMessageResponse/m:return/m:resultMessage", _namespaceManager)[0].InnerXml;

            //    string SoapResp = @"<ResponseArg  xmlns=""http://schemas.datacontract.org/2004/07/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
            //                     <resultStatus>" + _status + @"</resultStatus>
            //                     <resultLocation>UT</resultLocation>
            //                     <resultCode>0</resultCode>
            //                     <resultMessage>" + _body + @"</resultMessage> 
            //                     <resultRecId>0</resultRecId>                   
            //                     <resultTableId>0</resultTableId>                  
            //                    <resultDocNum>0</resultDocNum>
            //                    </ResponseArg>";

            //    _logger.Debug("Сформирован ответ :" + SoapResp);
            //    outMessage = SoapResp;
            //}
            //catch (Exception ex)
            //{
            //   _logger.Error(ex + " \n" + ex.Message + "\n" + ex.InnerException + " \n" + ex.StackTrace);
            //}
            //return outMessage;
        }

        public BPMExchangePortTypeClient connectionServiceUT(string password, string login)
        {
            BPMExchangePortTypeClient ws = null;
            try
            {
                    EndpointAddress ep = new EndpointAddress(new Uri(_wsdlAddress));
                    BasicHttpBinding binding = new BasicHttpBinding();
                    binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                    ws = new BPMExchangePortTypeClient(binding, ep);
                    ws.ClientCredentials.UserName.UserName = _login;
                    ws.ClientCredentials.UserName.Password = _password;
                    ws.Open();          
            }
            catch (Exception ex)
            {
                ws.Close();
                _logger.Error(ex.Message);

            }
            return ws;
        }

        public IntegrationaxSoapClient connectionAxapteService()
        {
            IntegrationaxSoapClient ws = null;
            try
            {              
                EndpointAddress ep = new EndpointAddress(new Uri(_wsdlAddress));
                BasicHttpBinding binding = new BasicHttpBinding();                            
                ws = new IntegrationaxSoapClient(binding, ep);
                ws.Open();
            }
            catch(Exception ex)
            {
                ws.Close();
                _logger.Error("Ошибка connectionAxaptService  " + ex.Message);
            }
            return ws;
        }

        public BPMExchange.RequestArg createOutgoingMessageUT(PluginsInterfaces.Message esbMessage)
        {
            BPMExchange.RequestArg BPMMessage = new BPMExchange.RequestArg();
            try
            {
                BPMMessage.Body = Encoding.UTF8.GetString(esbMessage.Body);
                BPMMessage.ClassId = int.Parse(esbMessage.ClassId);
                BPMMessage.DestinationServer = _server;
                BPMMessage.ExternalSystem = _system;
                BPMMessage.Id = esbMessage.Id.ToString();
                BPMMessage.Type = esbMessage.Type;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return BPMMessage;
        }

        public axaptaGate.RequestArg createOutgoingMessageAxapta(PluginsInterfaces.Message esbMessage)
        {
            axaptaGate.RequestArg AxaptaMessage = new axaptaGate.RequestArg();
            try
            {
                AxaptaMessage.Body = Encoding.UTF8.GetString(esbMessage.Body);
                AxaptaMessage.ClassId = esbMessage.ClassId;
                AxaptaMessage.DestinationServer = _system;
                AxaptaMessage.ExternalSystem =  _server;
                AxaptaMessage.Id = esbMessage.Id.ToString();
                AxaptaMessage.Type = esbMessage.Type;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка createOutgoingMessageAxapta " + ex.Message);
            }
            return AxaptaMessage;
        }

        public PluginsInterfaces.Message createReplyMessageUT(BPMExchange.ResponseArg response, PluginsInterfaces.Message message)
        {
            PluginsInterfaces.Message newMessage = new PluginsInterfaces.Message();
            try
            {
                string SoapResp = @"<ResponseArg  xmlns=""http://schemas.datacontract.org/2004/07/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                 <resultStatus>" + response.resultStatus + @"</resultStatus>
                                 <resultLocation>" + response.resultLocation + @"</resultLocation>
                                 <resultCode>" + response.resultCode + @"</resultCode>
                                 <resultMessage><![CDATA[" + response.resultMessage + @"]]></resultMessage> 
                                 <resultRecId>" + response.resultRecId + @"</resultRecId>                   
                                 <resultTableId>" + response.resultTableId + @"</resultTableId>                  
                                <resultDocNum>" + response.resultDocNum + @"</resultDocNum>
                                </ResponseArg>";

                newMessage.Body = Encoding.UTF8.GetBytes(SoapResp);
                newMessage.ClassId = message.ClassId;
                newMessage.Id = Guid.NewGuid();
                newMessage.Type = message.Type;
                newMessage.CorrelationId = message.CorrelationId;
                newMessage.Receiver = message.Source;
                newMessage.NeedAcknowledgment = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);


            }
            return newMessage;
        }

        public PluginsInterfaces.Message createReplyMessageAxapta(axaptaGate.sendMessageResponse response, PluginsInterfaces.Message message )
        {
            PluginsInterfaces.Message newMessage = new PluginsInterfaces.Message();
            try
            {
                string SoapResp = @"<ResponseArg  xmlns=""http://schemas.datacontract.org/2004/07/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                 <resultStatus>" + response.Body.sendMessageResult.resultStatus + @"</resultStatus>
                                 <resultLocation>" + response.Body.sendMessageResult.resultLocation + @"</resultLocation>
                                 <resultCode>" + response.Body.sendMessageResult.resultCode + @"</resultCode>
                                 <resultMessage><![CDATA[" + response.Body.sendMessageResult.resultMessage + @"]]></resultMessage> 
                                 <resultRecId>" + response.Body.sendMessageResult.resultRecId + @"</resultRecId>                   
                                 <resultTableId>" + response.Body.sendMessageResult.resultTableId + @"</resultTableId>                  
                                <resultDocNum>" + response.Body.sendMessageResult.resultDocNum + @"</resultDocNum>
                                </ResponseArg>";
                
                newMessage.Body = Encoding.UTF8.GetBytes(SoapResp);
                newMessage.ClassId = message.ClassId;
                newMessage.Id = Guid.NewGuid();
                newMessage.Type = message.Type;
                newMessage.CorrelationId = message.CorrelationId;
                newMessage.Receiver = message.Source;
                newMessage.NeedAcknowledgment = true;      
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);


            }
            return newMessage;
        }

        public PluginsInterfaces.Message createAndSendCatchMessage(string ex, PluginsInterfaces.Message esbMessage)
        {
            string SoapResp = @"<ResponseArg  xmlns=""http://schemas.datacontract.org/2004/07/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                 <resultStatus>False</resultStatus>
                                 <resultLocation>UT</resultLocation>
                                 <resultCode>0</resultCode>
                                 <resultMessage><![CDATA[" + ex + @"]]></resultMessage> 
                                 <resultRecId>0</resultRecId>                   
                                 <resultTableId>0</resultTableId>                  
                                <resultDocNum>0</resultDocNum>
                                </ResponseArg>";

            PluginsInterfaces.Message newMessage = new PluginsInterfaces.Message();
            newMessage.Body = Encoding.UTF8.GetBytes(SoapResp);
            newMessage.ClassId = esbMessage.ClassId;
            newMessage.Id = Guid.NewGuid();
            newMessage.Type = esbMessage.Type;
            newMessage.CorrelationId = esbMessage.CorrelationId;
            newMessage.Receiver = esbMessage.Source;
            newMessage.NeedAcknowledgment = true;
            return newMessage;
        }
    }
}
