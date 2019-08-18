using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace PL
{
    public partial class EditarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                Cls_Membership_DAL objDAL = new Cls_Membership_DAL();
                Cls_Membership_BLL objBLL = new Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Administrar_usuarios";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarUsuarios();
                    }
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        private void CargarUsuarios()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            gdvUsuarios.DataSource = null;
            gdvUsuarios.DataBind();

            objBLL.Listar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {
                gdvUsuarios.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvUsuarios.DataSource = objDAL.dtTablaPersonas;
                }
                else
                {
                    DataTable dt = objDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> query = from dtUsuarios in dt.AsEnumerable()
                                                             where dtUsuarios.Field<string>("Nombre").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtUsuarios;

                    DataView view = query.AsDataView();

                    gdvUsuarios.DataSource = view;

                }


                gdvUsuarios.DataBind();

                if (gdvUsuarios.Rows.Count > 0)
                {
                    gdvUsuarios.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvUsuarios.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }

        protected void gdvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvUsuarios.PageIndex = e.NewPageIndex;
            CargarUsuarios();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            updpnlGrid.Update();
        }

        protected void gdvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvUsuarios.Rows[index];
                String sCedula = gdvUsuarios.Rows[index].Cells[2].Text;

                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objBLL.Listar(ref objDAL);

                if (objDAL.sError == string.Empty)
                {

                    DataTable dt = objDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                             where dtPersonas.Field<string>("Cedula").ToLower().Contains(sCedula.ToLower())
                                                             select dtPersonas;

                    DataView view = query.AsDataView();

                    if (view.Count > 0)
                    {
                        lblHeader.InnerText = "Editar Usuario";
                        updpnlModalHeader.Update();
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
                        lblContrasenia.Visible = false;
                        txtContrasenia.Visible = false;
                        Session["Action"] = 'U';
                        updpnlGrid.Update();
                        updpnlModal.Update();
                    }
                }
            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvUsuarios.Rows[index];
                String sCedula = gdvUsuarios.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;

                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objDAL.sFiltro = sCedula;
                objBLL.Eliminar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarUsuarios();
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Registro eliminado correctamente";
                    lblMensaje.ForeColor = System.Drawing.Color.White;
                    updpnlGrid.Update();
                }

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblHeader.InnerText = "Agregar Usuario";
                Session["Action"] = 'I';
                LimpiarCampos();               
                txtCedula.Disabled = false;
                lblContrasenia.Visible = false;
                txtContrasenia.Visible = false;
                updpnlModalHeader.Update();
                updpnlModal.Update();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
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
                    Random rd = new Random(DateTime.Now.Millisecond);
                    int nuevaContrasena = rd.Next(100000, 999999);

                    SmtpClient smtpClient = new SmtpClient("Smtp.Gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("sistemasteoria9@gmail.com", "newmateo65");


                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(txtEmail.Value);
                    mailMessage.From = new MailAddress("sistemasteoria9@gmail.com");
                    mailMessage.Subject = "Usuario Registrado";
                    mailMessage.Body = "Su NOmbre de usuario es: " + Convert.ToString(txtUsuario.Value.Trim()) + " " +"Su contraseña es : " + Convert.ToString(nuevaContrasena);

                    try
                    {

                        smtpClient.Send(mailMessage);                     
                        
                     


                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = ex.ToString();
                    }
                objDAL.sContrasenia = Convert.ToString(nuevaContrasena);            
                if (chkSuperUsuario.Checked)
                    objDAL.sSuperUsuario = "true";
                else
                    objDAL.sSuperUsuario = "false";

                if (chkActivo.Checked)
                    objDAL.sActivo = "true";
                else
                    objDAL.sActivo = "false";
                if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    objBLL.Editar(ref objDAL);
                else
                    objBLL.Insertar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro guardado correctamente');", true);
                    }
                    CargarUsuarios();

                }
                updpnlGrid.Update();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
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
            chkSuperUsuario.Checked = false;
            chkActivo.Checked = false;    
            updpnlModal.Update();
        }

       
    }
}