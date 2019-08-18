using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace PL
{
    public partial class CrearSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cls_Membership_DAL objMember = new Cls_Membership_DAL();
            if (Session["UserLogin"] != null)
            {
                objMember.sUserLogin = Session["UserLogin"].ToString();
                Usuario = objMember.sUserLogin;

                if (!IsPostBack)
                {
                    this.Form.Attributes.Add("autocomplete", "off");
                  
                   
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }
        private string Usuario;

       
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Historial_BLL objBLL = new Cls_Historial_BLL();
                Cls_Historial_DAL objDAL = new Cls_Historial_DAL();

                objDAL.SDescripcion = txtDescripcion.Value.ToString().Trim();
                objDAL.SNombre = txtPeso.Value.ToString().Trim();

                objDAL.CAccion = 'I';
                objBLL.Insertar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha producido un error al guardar');", true);
                }
                else
                {
                   
                    if (objDAL.CAccion == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha guardado exitosamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha editado exitosamente');", true);
                    }

                    LimpiarCampos();
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha producido una excepcion' );", true);
                txtMensaje.Value = ex.Message.ToString();
                txtMensaje.Visible = true;
                updpnlBusqueda.Update();
            }
        }

        private void LimpiarCampos()
        {
          
            txtDescripcion.Value = string.Empty;        
            txtPeso.Value = string.Empty;         
            txtMensaje.Value = string.Empty;
            txtMensaje.Visible = false;
            updIngreso.Update();
            updpnlBusqueda.Update();
        }
    }
}