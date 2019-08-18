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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                if (!IsPostBack)
                {
                    CargarUsuario();
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        private void CargarUsuario()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {

                DataTable dt = objDAL.dtTablaPersonas;

                EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                         where dtPersonas.Field<string>("Usuario").ToLower().Contains(Session["UserLogin"].ToString().ToLower())
                                                         select dtPersonas;

                DataView view = query.AsDataView();

                if (view.Count > 0)
                {
                    txtCedula.Value = view[0]["Cedula"].ToString();
                    txtNombre.Value = view[0]["Nombre"].ToString();
                    txtPrimerApellido.Value = view[0]["Primer_Apellido"].ToString();
                    txtSegundoApellido.Value = view[0]["Segundo_Apellido"].ToString();
                    txtEmail.Value = view[0]["Email"].ToString();
                    txtTelefono1.Value = view[0]["Telefono1"].ToString();                  
                    txtUsuario.Value = view[0]["Usuario"].ToString();
                    txtContrasenia.Value = view[0]["Contrasena"].ToString();
                    chkSuperUsuario.Checked = Convert.ToBoolean(view[0]["Super_Usuario"].ToString());
                    chkActivo.Checked = Convert.ToBoolean(view[0]["Activo"].ToString());
                    txtCedula.Disabled = true;
                    chkSuperUsuario.Visible = false;
                    chkActivo.Visible = false;
                }
            }
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
                if (chkSuperUsuario.Checked)
                    objDAL.sSuperUsuario = "true";
                else
                    objDAL.sSuperUsuario = "false";

                if (chkActivo.Checked)
                    objDAL.sActivo = "true";
                else
                    objDAL.sActivo = "false";         

                objBLL.Editar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    CargarUsuario();

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }
        protected void btnVerificacion_Click(object sender, EventArgs e)
        {

        }


    }
}