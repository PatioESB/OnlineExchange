﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaGate {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestArg", Namespace="http://srv-aos2-gate:80/integrationax/")]
    [System.SerializableAttribute()]
    public partial class RequestArg : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClassIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExternalSystemField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DestinationServerField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ClassId {
            get {
                return this.ClassIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassIdField, value) != true)) {
                    this.ClassIdField = value;
                    this.RaisePropertyChanged("ClassId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Body {
            get {
                return this.BodyField;
            }
            set {
                if ((object.ReferenceEquals(this.BodyField, value) != true)) {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string ExternalSystem {
            get {
                return this.ExternalSystemField;
            }
            set {
                if ((object.ReferenceEquals(this.ExternalSystemField, value) != true)) {
                    this.ExternalSystemField = value;
                    this.RaisePropertyChanged("ExternalSystem");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string DestinationServer {
            get {
                return this.DestinationServerField;
            }
            set {
                if ((object.ReferenceEquals(this.DestinationServerField, value) != true)) {
                    this.DestinationServerField = value;
                    this.RaisePropertyChanged("DestinationServer");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponceArg", Namespace="http://srv-aos2-gate:80/integrationax/")]
    [System.SerializableAttribute()]
    public partial class ResponceArg : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool resultStatusField;
        
        private ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArgLocation resultLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string resultCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string resultMessageField;
        
        private long resultRecIdField;
        
        private long resultTableIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string resultDocNumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool resultStatus {
            get {
                return this.resultStatusField;
            }
            set {
                if ((this.resultStatusField.Equals(value) != true)) {
                    this.resultStatusField = value;
                    this.RaisePropertyChanged("resultStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArgLocation resultLocation {
            get {
                return this.resultLocationField;
            }
            set {
                if ((this.resultLocationField.Equals(value) != true)) {
                    this.resultLocationField = value;
                    this.RaisePropertyChanged("resultLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.resultCodeField, value) != true)) {
                    this.resultCodeField = value;
                    this.RaisePropertyChanged("resultCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string resultMessage {
            get {
                return this.resultMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.resultMessageField, value) != true)) {
                    this.resultMessageField = value;
                    this.RaisePropertyChanged("resultMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public long resultRecId {
            get {
                return this.resultRecIdField;
            }
            set {
                if ((this.resultRecIdField.Equals(value) != true)) {
                    this.resultRecIdField = value;
                    this.RaisePropertyChanged("resultRecId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public long resultTableId {
            get {
                return this.resultTableIdField;
            }
            set {
                if ((this.resultTableIdField.Equals(value) != true)) {
                    this.resultTableIdField = value;
                    this.RaisePropertyChanged("resultTableId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string resultDocNum {
            get {
                return this.resultDocNumField;
            }
            set {
                if ((object.ReferenceEquals(this.resultDocNumField, value) != true)) {
                    this.resultDocNumField = value;
                    this.RaisePropertyChanged("resultDocNum");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponceArgLocation", Namespace="http://srv-aos2-gate:80/integrationax/")]
    public enum ResponceArgLocation : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AX = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WebService = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WebServiceValidation = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://srv-aos2-gate:80/integrationax/", ConfigurationName="axaptaGate.IntegrationaxSoap")]
    public interface IntegrationaxSoap {
        
        // CODEGEN: Контракт генерации сообщений с именем request из пространства имен http://srv-aos2-gate:80/integrationax/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://srv-aos2-gate:80/integrationax/sendMessage", ReplyAction="*")]
        ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse sendMessage(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://srv-aos2-gate:80/integrationax/sendMessage", ReplyAction="*")]
        System.Threading.Tasks.Task<ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse> sendMessageAsync(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class sendMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="sendMessage", Namespace="http://srv-aos2-gate:80/integrationax/", Order=0)]
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequestBody Body;
        
        public sendMessageRequest() {
        }
        
        public sendMessageRequest(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://srv-aos2-gate:80/integrationax/")]
    public partial class sendMessageRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.RequestArg request;
        
        public sendMessageRequestBody() {
        }
        
        public sendMessageRequestBody(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.RequestArg request) {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class sendMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="sendMessageResponse", Namespace="http://srv-aos2-gate:80/integrationax/", Order=0)]
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponseBody Body;
        
        public sendMessageResponse() {
        }
        
        public sendMessageResponse(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://srv-aos2-gate:80/integrationax/")]
    public partial class sendMessageResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArg sendMessageResult;
        
        public sendMessageResponseBody() {
        }
        
        public sendMessageResponseBody(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArg sendMessageResult) {
            this.sendMessageResult = sendMessageResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IntegrationaxSoapChannel : ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IntegrationaxSoapClient : System.ServiceModel.ClientBase<ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap>, ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap {
        
        public IntegrationaxSoapClient() {
        }
        
        public IntegrationaxSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        public IntegrationaxSoapClient(string endpointConfigurationName, string remoteAddress ) : 
                base(endpointConfigurationName, remoteAddress  ) {
        }
        
        public IntegrationaxSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntegrationaxSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap.sendMessage(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest request) {
            return base.Channel.sendMessage(request);
        }
        
        public ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArg sendMessage(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.RequestArg request) {
            ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest inValue = new ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest();
            inValue.Body = new ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequestBody();
            inValue.Body.request = request;
            ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse retVal = ((ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap)(this)).sendMessage(inValue);
            return retVal.Body.sendMessageResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse> ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap.sendMessageAsync(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest request) {
            return base.Channel.sendMessageAsync(request);
        }
        
        public System.Threading.Tasks.Task<ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse> sendMessageAsync(ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.RequestArg request) {
            ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest inValue = new ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequest();
            inValue.Body = new ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageRequestBody();
            inValue.Body.request = request;
            return ((ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoap)(this)).sendMessageAsync(inValue);
        }
    }
}