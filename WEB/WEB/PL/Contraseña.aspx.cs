using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using DAL;
using BLL;


namespace PL
{
    public partial class Contraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     

        protected void btnRecuperarContrasenia_Click(object sender, EventArgs e)
        {


            Cls_Personas_DAL objDall = new Cls_Personas_DAL();
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            objDall.sEmail = txtcorreo.Value;
            if (objBLL.Correo(ref objDall))
            {
                Random rd = new Random(DateTime.Now.Millisecond);
                int nuevaContrasena = rd.Next(100000, 999999);

                SmtpClient smtpClient = new SmtpClient("Smtp.Gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("sistemasteoria9@gmail.com", "newmateo65");


                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(txtcorreo.Value);
                mailMessage.From = new MailAddress("sistemasteoria9@gmail.com");
                mailMessage.Subject = "Cambio de contraseña";
                mailMessage.Body = "Su nueva contraseña es : " + Convert.ToString(nuevaContrasena);

                try
                {

                    smtpClient.Send(mailMessage);
                    lblMensaje.Text = "Revise su correo";

                    Cls_Personas_DAL objDall2 = new Cls_Personas_DAL();
                    Cls_Personas_BLL objBLL1 = new Cls_Personas_BLL();

                    objDall2.sContrasenia = Convert.ToString(nuevaContrasena);
                    objDall2.sEmail = txtcorreo.Value;
                    objBLL1.Editar_Usuario(ref objDall2);
                    LimpiarCampos();
                    Response.Redirect("/Ingreso.aspx");


                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.ToString();
                }

            }
            else
            {
                lblMensaje.Text = "Usuario incorrecta";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }

           private void LimpiarCampos()
        {

            txtcorreo.Value = string.Empty;
            lblMensaje.Text = string.Empty;
         
        }
    }
}