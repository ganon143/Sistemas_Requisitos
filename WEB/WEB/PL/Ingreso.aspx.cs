﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtusuario.Value = string.Empty;
                txtcontrasenia.Value = string.Empty;
            }
            lblMensaje.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cls_Membership_DAL objDAL = new Cls_Membership_DAL();
            Cls_Membership_BLL objBLL = new Cls_Membership_BLL();
            objDAL.sUserLogin = txtusuario.Value;
            objDAL.sContrasena = txtcontrasenia.Value;
            if (objBLL.Login(ref objDAL))
            {
                Session["UserLogin"] = objDAL.sUserLogin;
                txtusuario.Value = string.Empty;
                txtcontrasenia.Value = string.Empty;
                Response.Redirect("/Inicio.aspx");
            }
            else
            {
                lblMensaje.Text = "El servidor no se encuentra disponible ó los datos de acceso son incorrectos";
                lblMensaje.ForeColor = System.Drawing.Color.White;
                lblMensaje.Visible = true;
            }



        }

       
    }
}