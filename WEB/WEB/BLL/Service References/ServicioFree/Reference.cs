﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL.ServicioFree {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioFree.IBDService")]
    public interface IBDService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/ListarDatos", ReplyAction="http://tempuri.org/IBDService/ListarDatosResponse")]
        BLL.ServicioFree.ListarDatosResponse ListarDatos(BLL.ServicioFree.ListarDatosRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/ListarDatos", ReplyAction="http://tempuri.org/IBDService/ListarDatosResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.ListarDatosResponse> ListarDatosAsync(BLL.ServicioFree.ListarDatosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/FiltrarDatos", ReplyAction="http://tempuri.org/IBDService/FiltrarDatosResponse")]
        BLL.ServicioFree.FiltrarDatosResponse FiltrarDatos(BLL.ServicioFree.FiltrarDatosRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/FiltrarDatos", ReplyAction="http://tempuri.org/IBDService/FiltrarDatosResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.FiltrarDatosResponse> FiltrarDatosAsync(BLL.ServicioFree.FiltrarDatosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/InsertarDato", ReplyAction="http://tempuri.org/IBDService/InsertarDatoResponse")]
        BLL.ServicioFree.InsertarDatoResponse InsertarDato(BLL.ServicioFree.InsertarDatoRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/InsertarDato", ReplyAction="http://tempuri.org/IBDService/InsertarDatoResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.InsertarDatoResponse> InsertarDatoAsync(BLL.ServicioFree.InsertarDatoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/ModificarDato", ReplyAction="http://tempuri.org/IBDService/ModificarDatoResponse")]
        BLL.ServicioFree.ModificarDatoResponse ModificarDato(BLL.ServicioFree.ModificarDatoRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/ModificarDato", ReplyAction="http://tempuri.org/IBDService/ModificarDatoResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.ModificarDatoResponse> ModificarDatoAsync(BLL.ServicioFree.ModificarDatoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/EliminarDato", ReplyAction="http://tempuri.org/IBDService/EliminarDatoResponse")]
        BLL.ServicioFree.EliminarDatoResponse EliminarDato(BLL.ServicioFree.EliminarDatoRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/EliminarDato", ReplyAction="http://tempuri.org/IBDService/EliminarDatoResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.EliminarDatoResponse> EliminarDatoAsync(BLL.ServicioFree.EliminarDatoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/InsertarDatoSinIdentity", ReplyAction="http://tempuri.org/IBDService/InsertarDatoSinIdentityResponse")]
        BLL.ServicioFree.InsertarDatoSinIdentityResponse InsertarDatoSinIdentity(BLL.ServicioFree.InsertarDatoSinIdentityRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBDService/InsertarDatoSinIdentity", ReplyAction="http://tempuri.org/IBDService/InsertarDatoSinIdentityResponse")]
        System.Threading.Tasks.Task<BLL.ServicioFree.InsertarDatoSinIdentityResponse> InsertarDatoSinIdentityAsync(BLL.ServicioFree.InsertarDatoSinIdentityRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListarDatos", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ListarDatosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string sMsjError;
        
        public ListarDatosRequest() {
        }
        
        public ListarDatosRequest(string sNombreSP, string sNombreTabla, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListarDatosResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ListarDatosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataTable ListarDatosResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sMsjError;
        
        public ListarDatosResponse() {
        }
        
        public ListarDatosResponse(System.Data.DataTable ListarDatosResult, string sMsjError) {
            this.ListarDatosResult = ListarDatosResult;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FiltrarDatos", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FiltrarDatosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Data.DataTable dtParametros;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string sMsjError;
        
        public FiltrarDatosRequest() {
        }
        
        public FiltrarDatosRequest(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.dtParametros = dtParametros;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FiltrarDatosResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FiltrarDatosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataTable FiltrarDatosResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sMsjError;
        
        public FiltrarDatosResponse() {
        }
        
        public FiltrarDatosResponse(System.Data.DataTable FiltrarDatosResult, string sMsjError) {
            this.FiltrarDatosResult = FiltrarDatosResult;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarDato", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertarDatoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Data.DataTable dtParametros;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string sMsjError;
        
        public InsertarDatoRequest() {
        }
        
        public InsertarDatoRequest(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, char cAccion, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.dtParametros = dtParametros;
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarDatoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertarDatoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string InsertarDatoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string sMsjError;
        
        public InsertarDatoResponse() {
        }
        
        public InsertarDatoResponse(string InsertarDatoResult, char cAccion, string sMsjError) {
            this.InsertarDatoResult = InsertarDatoResult;
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModificarDato", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ModificarDatoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Data.DataTable dtParametros;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string sMsjError;
        
        public ModificarDatoRequest() {
        }
        
        public ModificarDatoRequest(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, char cAccion, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.dtParametros = dtParametros;
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModificarDatoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ModificarDatoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sMsjError;
        
        public ModificarDatoResponse() {
        }
        
        public ModificarDatoResponse(char cAccion, string sMsjError) {
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EliminarDato", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class EliminarDatoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Data.DataTable dtParametros;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string sMsjError;
        
        public EliminarDatoRequest() {
        }
        
        public EliminarDatoRequest(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.dtParametros = dtParametros;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EliminarDatoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class EliminarDatoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sMsjError;
        
        public EliminarDatoResponse() {
        }
        
        public EliminarDatoResponse(string sMsjError) {
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarDatoSinIdentity", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertarDatoSinIdentityRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sNombreSP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sNombreTabla;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Data.DataTable dtParametros;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string sMsjError;
        
        public InsertarDatoSinIdentityRequest() {
        }
        
        public InsertarDatoSinIdentityRequest(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, char cAccion, string sMsjError) {
            this.sNombreSP = sNombreSP;
            this.sNombreTabla = sNombreTabla;
            this.dtParametros = dtParametros;
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarDatoSinIdentityResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertarDatoSinIdentityResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string InsertarDatoSinIdentityResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public char cAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string sMsjError;
        
        public InsertarDatoSinIdentityResponse() {
        }
        
        public InsertarDatoSinIdentityResponse(string InsertarDatoSinIdentityResult, char cAccion, string sMsjError) {
            this.InsertarDatoSinIdentityResult = InsertarDatoSinIdentityResult;
            this.cAccion = cAccion;
            this.sMsjError = sMsjError;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBDServiceChannel : BLL.ServicioFree.IBDService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BDServiceClient : System.ServiceModel.ClientBase<BLL.ServicioFree.IBDService>, BLL.ServicioFree.IBDService {
        
        public BDServiceClient() {
        }
        
        public BDServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BDServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BDServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BDServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.ListarDatosResponse BLL.ServicioFree.IBDService.ListarDatos(BLL.ServicioFree.ListarDatosRequest request) {
            return base.Channel.ListarDatos(request);
        }
        
        public System.Data.DataTable ListarDatos(string sNombreSP, string sNombreTabla, ref string sMsjError) {
            BLL.ServicioFree.ListarDatosRequest inValue = new BLL.ServicioFree.ListarDatosRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.ListarDatosResponse retVal = ((BLL.ServicioFree.IBDService)(this)).ListarDatos(inValue);
            sMsjError = retVal.sMsjError;
            return retVal.ListarDatosResult;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.ListarDatosResponse> ListarDatosAsync(BLL.ServicioFree.ListarDatosRequest request) {
            return base.Channel.ListarDatosAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.FiltrarDatosResponse BLL.ServicioFree.IBDService.FiltrarDatos(BLL.ServicioFree.FiltrarDatosRequest request) {
            return base.Channel.FiltrarDatos(request);
        }
        
        public System.Data.DataTable FiltrarDatos(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, ref string sMsjError) {
            BLL.ServicioFree.FiltrarDatosRequest inValue = new BLL.ServicioFree.FiltrarDatosRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.dtParametros = dtParametros;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.FiltrarDatosResponse retVal = ((BLL.ServicioFree.IBDService)(this)).FiltrarDatos(inValue);
            sMsjError = retVal.sMsjError;
            return retVal.FiltrarDatosResult;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.FiltrarDatosResponse> FiltrarDatosAsync(BLL.ServicioFree.FiltrarDatosRequest request) {
            return base.Channel.FiltrarDatosAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.InsertarDatoResponse BLL.ServicioFree.IBDService.InsertarDato(BLL.ServicioFree.InsertarDatoRequest request) {
            return base.Channel.InsertarDato(request);
        }
        
        public string InsertarDato(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, ref char cAccion, ref string sMsjError) {
            BLL.ServicioFree.InsertarDatoRequest inValue = new BLL.ServicioFree.InsertarDatoRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.dtParametros = dtParametros;
            inValue.cAccion = cAccion;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.InsertarDatoResponse retVal = ((BLL.ServicioFree.IBDService)(this)).InsertarDato(inValue);
            cAccion = retVal.cAccion;
            sMsjError = retVal.sMsjError;
            return retVal.InsertarDatoResult;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.InsertarDatoResponse> InsertarDatoAsync(BLL.ServicioFree.InsertarDatoRequest request) {
            return base.Channel.InsertarDatoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.ModificarDatoResponse BLL.ServicioFree.IBDService.ModificarDato(BLL.ServicioFree.ModificarDatoRequest request) {
            return base.Channel.ModificarDato(request);
        }
        
        public void ModificarDato(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, ref char cAccion, ref string sMsjError) {
            BLL.ServicioFree.ModificarDatoRequest inValue = new BLL.ServicioFree.ModificarDatoRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.dtParametros = dtParametros;
            inValue.cAccion = cAccion;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.ModificarDatoResponse retVal = ((BLL.ServicioFree.IBDService)(this)).ModificarDato(inValue);
            cAccion = retVal.cAccion;
            sMsjError = retVal.sMsjError;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.ModificarDatoResponse> ModificarDatoAsync(BLL.ServicioFree.ModificarDatoRequest request) {
            return base.Channel.ModificarDatoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.EliminarDatoResponse BLL.ServicioFree.IBDService.EliminarDato(BLL.ServicioFree.EliminarDatoRequest request) {
            return base.Channel.EliminarDato(request);
        }
        
        public void EliminarDato(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, ref string sMsjError) {
            BLL.ServicioFree.EliminarDatoRequest inValue = new BLL.ServicioFree.EliminarDatoRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.dtParametros = dtParametros;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.EliminarDatoResponse retVal = ((BLL.ServicioFree.IBDService)(this)).EliminarDato(inValue);
            sMsjError = retVal.sMsjError;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.EliminarDatoResponse> EliminarDatoAsync(BLL.ServicioFree.EliminarDatoRequest request) {
            return base.Channel.EliminarDatoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BLL.ServicioFree.InsertarDatoSinIdentityResponse BLL.ServicioFree.IBDService.InsertarDatoSinIdentity(BLL.ServicioFree.InsertarDatoSinIdentityRequest request) {
            return base.Channel.InsertarDatoSinIdentity(request);
        }
        
        public string InsertarDatoSinIdentity(string sNombreSP, string sNombreTabla, System.Data.DataTable dtParametros, ref char cAccion, ref string sMsjError) {
            BLL.ServicioFree.InsertarDatoSinIdentityRequest inValue = new BLL.ServicioFree.InsertarDatoSinIdentityRequest();
            inValue.sNombreSP = sNombreSP;
            inValue.sNombreTabla = sNombreTabla;
            inValue.dtParametros = dtParametros;
            inValue.cAccion = cAccion;
            inValue.sMsjError = sMsjError;
            BLL.ServicioFree.InsertarDatoSinIdentityResponse retVal = ((BLL.ServicioFree.IBDService)(this)).InsertarDatoSinIdentity(inValue);
            cAccion = retVal.cAccion;
            sMsjError = retVal.sMsjError;
            return retVal.InsertarDatoSinIdentityResult;
        }
        
        public System.Threading.Tasks.Task<BLL.ServicioFree.InsertarDatoSinIdentityResponse> InsertarDatoSinIdentityAsync(BLL.ServicioFree.InsertarDatoSinIdentityRequest request) {
            return base.Channel.InsertarDatoSinIdentityAsync(request);
        }
    }
}