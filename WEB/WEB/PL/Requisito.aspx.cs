using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Data;

namespace PL
{
    public partial class Requisito : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
              Cls_Membership_DAL objDAL = new Cls_Membership_DAL();
              Cls_Membership_BLL objBLL = new Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Administrar_Requisito";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarRoles();
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

        private void CargarRoles()
        {
            Cls_Requisitos_BLL objBLL = new Cls_Requisitos_BLL();
            Cls_Requisitos_DAL objDAL = new Cls_Requisitos_DAL();

            gdvRequisitos.DataSource = null;
            gdvRequisitos.DataBind();

            objBLL.Listar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {
                gdvRequisitos.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvRequisitos.DataSource = objDAL.dtTabla;
                }
                else
                {
                    DataTable dt = objDAL.dtTabla;

                    EnumerableRowCollection<DataRow> query = from dtRequisito in dt.AsEnumerable()
                                                             where dtRequisito.Field<string>("Requsito").ToLower().Replace(" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtRequisito;

                    DataView view = query.AsDataView();

                    gdvRequisitos.DataSource = view;

                }

                gdvRequisitos.DataBind();

                if (gdvRequisitos.Rows.Count > 0)
                {
                    gdvRequisitos.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvRequisitos.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }

        protected void gdvRequisitos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRequisitos.PageIndex = e.NewPageIndex;
            CargarRoles();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarRoles();
            updpnlGrid.Update();
        }

        protected void gdvRequisitos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvRequisitos.Rows[index];
                String idRol = gdvRequisitos.Rows[index].Cells[2].Text;
                lblHeader.InnerText = "Editar Requisito";
                updpnlModalHeader.Update();
                txtIdRol.Value = idRol;
                txtRol.Value = Server.HtmlDecode(gdvRequisitos.Rows[index].Cells[3].Text);
                txtDescripcion.Value = Server.HtmlDecode(gdvRequisitos.Rows[index].Cells[4].Text);              
                updpnlGrid.Update();
                lblIdRol.Visible = true;
                txtIdRol.Visible = true;               
                updpnlModal.Update();
            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvRequisitos.Rows[index];
                String idRol = gdvRequisitos.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;
                Cls_Requisitos_BLL objBLL = new Cls_Requisitos_BLL();
                Cls_Requisitos_DAL objDAL = new Cls_Requisitos_DAL();

                objDAL.iId_Requisito = Convert.ToInt32(idRol.Trim());
                objBLL.Eliminar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarRoles();
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
                lblHeader.InnerText = "Agregar Requisito";
                lblIdRol.Visible = false;
                txtIdRol.Visible = false;             
                LimpiarCampos();
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
                Cls_Requisitos_BLL objBLL = new Cls_Requisitos_BLL();
                Cls_Requisitos_DAL objDAL = new Cls_Requisitos_DAL();

                objDAL.sReq = txtRol.Value.ToString().Trim();
                objDAL.sDescripcion = txtDescripcion.Value.ToString().Trim();
                if (txtIdRol.Visible == false)
                {
                    objDAL.cAccion = 'I';
                    objBLL.Insertar(ref objDAL);
                }
                else
                {
                    objDAL.iId_Requisito = Convert.ToInt32(txtIdRol.Value.ToString().Trim());
                    objDAL.cAccion = 'U';
                    objBLL.Editar(ref objDAL);
                }

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (objDAL.cAccion == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro agregado correctamente');", true);
                    }

                    CargarRoles();

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
            txtIdRol.Value = string.Empty;
            txtRol.Value = string.Empty;
            txtDescripcion.Value = string.Empty;
            updpnlModal.Update();
        }           

        

       
       
        }
    }
