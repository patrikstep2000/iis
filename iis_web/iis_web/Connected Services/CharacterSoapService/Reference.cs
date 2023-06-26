﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iis_web.CharacterSoapService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CharacterSoapService.CharacterSoap")]
    public interface CharacterSoap {
        
        // CODEGEN: Generating message contract since element name term from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Search", ReplyAction="*")]
        iis_web.CharacterSoapService.SearchResponse Search(iis_web.CharacterSoapService.SearchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Search", ReplyAction="*")]
        System.Threading.Tasks.Task<iis_web.CharacterSoapService.SearchResponse> SearchAsync(iis_web.CharacterSoapService.SearchRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Search", Namespace="http://tempuri.org/", Order=0)]
        public iis_web.CharacterSoapService.SearchRequestBody Body;
        
        public SearchRequest() {
        }
        
        public SearchRequest(iis_web.CharacterSoapService.SearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string term;
        
        public SearchRequestBody() {
        }
        
        public SearchRequestBody(string term) {
            this.term = term;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public iis_web.CharacterSoapService.SearchResponseBody Body;
        
        public SearchResponse() {
        }
        
        public SearchResponse(iis_web.CharacterSoapService.SearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SearchResult;
        
        public SearchResponseBody() {
        }
        
        public SearchResponseBody(string SearchResult) {
            this.SearchResult = SearchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CharacterSoapChannel : iis_web.CharacterSoapService.CharacterSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CharacterSoapClient : System.ServiceModel.ClientBase<iis_web.CharacterSoapService.CharacterSoap>, iis_web.CharacterSoapService.CharacterSoap {
        
        public CharacterSoapClient() {
        }
        
        public CharacterSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CharacterSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CharacterSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CharacterSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        iis_web.CharacterSoapService.SearchResponse iis_web.CharacterSoapService.CharacterSoap.Search(iis_web.CharacterSoapService.SearchRequest request) {
            return base.Channel.Search(request);
        }
        
        public string Search(string term) {
            iis_web.CharacterSoapService.SearchRequest inValue = new iis_web.CharacterSoapService.SearchRequest();
            inValue.Body = new iis_web.CharacterSoapService.SearchRequestBody();
            inValue.Body.term = term;
            iis_web.CharacterSoapService.SearchResponse retVal = ((iis_web.CharacterSoapService.CharacterSoap)(this)).Search(inValue);
            return retVal.Body.SearchResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<iis_web.CharacterSoapService.SearchResponse> iis_web.CharacterSoapService.CharacterSoap.SearchAsync(iis_web.CharacterSoapService.SearchRequest request) {
            return base.Channel.SearchAsync(request);
        }
        
        public System.Threading.Tasks.Task<iis_web.CharacterSoapService.SearchResponse> SearchAsync(string term) {
            iis_web.CharacterSoapService.SearchRequest inValue = new iis_web.CharacterSoapService.SearchRequest();
            inValue.Body = new iis_web.CharacterSoapService.SearchRequestBody();
            inValue.Body.term = term;
            return ((iis_web.CharacterSoapService.CharacterSoap)(this)).SearchAsync(inValue);
        }
    }
}
