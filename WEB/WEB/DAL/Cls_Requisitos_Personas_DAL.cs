using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Cls_Requisitos_Personas_DAL
    {
        private DataTable _dtTabla;
        private string _sError, _sFiltro, _sCedula;
        private DataTable _dtParametros;
        private int _iReq, _iReqPersona;

        public DataTable dtTabla
        {
            get
            {
                return _dtTabla;
            }

            set
            {
                _dtTabla = value;
            }
        }

        public string sError
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

        public string sFiltro
        {
            get
            {
                return _sFiltro;
            }

            set
            {
                _sFiltro = value;
            }
        }

        public string sCedula
        {
            get
            {
                return _sCedula;
            }

            set
            {
                _sCedula = value;
            }
        }

        public DataTable dtParametros
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

        public int iReq
        {
            get
            {
                return _iReq;
            }

            set
            {
                _iReq = value;
            }
        }

        public int iReqPersona
        {
            get
            {
                return _iReqPersona;
            }

            set
            {
                _iReqPersona = value;
            }
        }
    }
}
