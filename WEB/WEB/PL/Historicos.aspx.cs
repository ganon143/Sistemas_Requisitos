using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DAL;

namespace PL
{
    public partial class Historicos : System.Web.UI.Page
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
                    CargarPedidosUsuario();
                }
            }
        }
        private string Usuario;
        private void CargarPedidosUsuario()
        {
            Cls_Historial_BLL objBLL = new Cls_Historial_BLL();
            Cls_Historial_DAL objDAL = new Cls_Historial_DAL();

            gdvPaquetes.DataSource = null;
            gdvPaquetes.DataBind();

            objBLL.Listar(ref objDAL);
            string prueba = txtBuscar.Value;
            if (objDAL.SError == string.Empty)
            {
                Cls_Personas_BLL objPBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objPDAL = new Cls_Personas_DAL();

                objPBLL.Listar(ref objPDAL);
                gdvPaquetes.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    DataTable dts = objPDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> querys = from dtPersonas in dts.AsEnumerable()
                                                             where dtPersonas.Field<string>("Usuario").ToLower().Contains(Session["UserLogin"].ToString().ToLower())
                                                             select dtPersonas;

                    DataView views = querys.AsDataView();

                    if (views.Count > 0)
                    {
                        Usuario = views[0]["Cedula"].ToString();

                    }

                    DataTable dt = objDAL.DtTablaPaquetes;
               

                    EnumerableRowCollection<DataRow> query = from dtTablaPaquetes in dt.AsEnumerable()
                                                             where dtTablaPaquetes.Field<string>("Cedula").ToLower().Replace(" ", "").Replace("-", "").Contains(Usuario.ToLower().Replace(" ", "").Replace("-", ""))
                                                             select dtTablaPaquetes;

                    DataView view = query.AsDataView();

                    gdvPaquetes.DataSource = view;
                }
                else
                {
                    DataTable dt = objDAL.DtTablaPaquetes;

                    EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                             where dtSucursales.Field<string>("DetallePaquete").ToLower().Replace(" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtSucursales;

                    DataView view = query.AsDataView();

                    gdvPaquetes.DataSource = view;

                }


                gdvPaquetes.DataBind();

                if (gdvPaquetes.Rows.Count > 0)
                {
                    gdvPaquetes.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvPaquetes.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.SError;
            }
        }
        protected void gdvPaquetes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPaquetes.PageIndex = e.NewPageIndex;
            CargarPedidosUsuario();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarPedidosUsuario();
            updpnlGrid.Update();
        }

    }
}