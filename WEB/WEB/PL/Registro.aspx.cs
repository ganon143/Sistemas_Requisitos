using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL
{
    public partial class Registro1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtCedula.Value = string.Empty;
            txtNombre.Value = string.Empty;
            txtPrimerApellido.Value = string.Empty;
            txtSegundoApellido.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtTelefono1.Value = string.Empty;          
            txtUsuario.Value = string.Empty;
            txtContrasenia.Value = string.Empty;     
  
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = false;
                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objDAL.sCedula = txtCedula.Value;
                objDAL.sNombre = txtNombre.Value;
                objDAL.sPrimerApellido = txtPrimerApellido.Value;
                objDAL.sSegundoApellido = txtSegundoApellido.Value;
                objDAL.sEmail = txtEmail.Value;
                objDAL.sTelefono1 = txtTelefono1.Value;         
                objDAL.sUsuario = txtUsuario.Value;
                objDAL.sContrasenia = txtContrasenia.Value;
                objDAL.sSuperUsuario = "false";
                objDAL.sActivo = "true";
   
                objBLL.Insertar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro agregado correctamente');", true);
                    Response.Redirect("Ingreso.aspx");

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }
        

    }
}