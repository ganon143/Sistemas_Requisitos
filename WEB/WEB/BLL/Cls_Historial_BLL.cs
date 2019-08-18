using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BLL.ServicioFree;

namespace BLL
{
    public class Cls_Historial_BLL
    {

        public void Crear_Parametros(ref Cls_Historial_DAL objPaqDAL)
        {
            try
            {
                objPaqDAL.DtParametros = new DataTable("Parametros");
                objPaqDAL.DtParametros.Columns.Add("Nombre");
                objPaqDAL.DtParametros.Columns.Add("Tipo");
                objPaqDAL.DtParametros.Columns.Add("Valor");

                objPaqDAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                objPaqDAL.SError = Error.Message.ToString();
                objPaqDAL.DtParametros = null;
            }

        }

        public void Insertar(ref Cls_Historial_DAL objPaqDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objPaqDAL.CAccion;
            Crear_Parametros(ref objPaqDAL);
            objPaqDAL.DtParametros.Rows.Add("@Nombre_Requsito", "2", objPaqDAL.SNombre);
            objPaqDAL.DtParametros.Rows.Add("@Descripcion", "2", objPaqDAL.SDescripcion);        
            objPaqDAL.DtParametros.Rows.Add("@@Usuario", "2", objPaqDAL.SPersona);
            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Requisito", "Requisito", objPaqDAL.DtParametros, ref vAccion, ref vError);
            objPaqDAL.CAccion = vAccion;
            objPaqDAL.SError = vError;
        }

        public void Listar(ref Cls_Historial_DAL objPaqDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Requisito_Personas";
                string SNombreTabla = "Requisito";
                string error = "";

                objPaqDAL.DtTablaPaquetes = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);

                if (error == string.Empty && objPaqDAL.DtTablaPaquetes != null)
                {
                    objPaqDAL.SError = string.Empty;
                }
                else
                {
                    objPaqDAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                objPaqDAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

        public void Editar(ref Cls_Historial_DAL objPaqDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objPaqDAL.CAccion;
            Crear_Parametros(ref objPaqDAL);
            objPaqDAL.DtParametros.Rows.Add("@Id_Requisito", "1", objPaqDAL.SIdRequisito);
            objPaqDAL.DtParametros.Rows.Add("@Nombre_Requsito", "2", objPaqDAL.SNombre);
            objPaqDAL.DtParametros.Rows.Add("@Descripcion", "2", objPaqDAL.SDescripcion);
            objPaqDAL.DtParametros.Rows.Add("@@Usuario", "2", objPaqDAL.SPersona);
            Obj_BDService.ModificarDato("sp_Modificar_Requisito", "Requisito", objPaqDAL.DtParametros, ref vAccion, ref vError);
            objPaqDAL.CAccion = vAccion;
            objPaqDAL.SError = vError;
        }
    }
}
