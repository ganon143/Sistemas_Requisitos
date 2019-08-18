using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Cls_Historial_DAL
    {

        private DataTable _dtTablaPaquetes;
        private DataTable _dtParametros;
        private string _sError, _sNombre, _sDescripcion, _sIdRequisito, _sPersona;     
    
        private char _cAccion;

        public DataTable DtTablaPaquetes
        {
            get
            {
                return _dtTablaPaquetes;
            }

            set
            {
                _dtTablaPaquetes = value;
            }
        }

        public DataTable DtParametros
        {
            get
            {
                return _dtParametros;
            }

            set
            {
                _dtParametros = value;
            }
        }

        public string SIdRequisito
        {
            get
            {
                return _sIdRequisito;
            }

            set
            {
                _sIdRequisito = value;
            }
        }

        public char CAccion
        {
            get
            {
                return _cAccion;
            }

            set
            {
                _cAccion = value;
            }
        }

        public string SError
        {
            get
            {
                return _sError;
            }

            set
            {
                _sError = value;
            }
        }
        

        public string SDescripcion
        {
            get
            {
                return _sDescripcion;
            }

            set
            {
                _sDescripcion = value;
            }
        }

        public string SNombre
        {
            get
            {
                return _sNombre;
            }

            set
            {
                _sNombre = value;
            }
        }

        public string SPersona
        {
            get
            {
                return _sPersona;
            }

            set
            {
                _sPersona = value;
            }
        }
    }
}
