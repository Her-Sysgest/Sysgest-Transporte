using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sysgest___Transportes.codigo.dto;
using Sysgest___Transportes.codigo.dal;
using System.Data;

namespace Sysgest___Transportes.codigo.bll
{
    public class rotasBLL: AcessoBancoDados
    {
        public bool testarConexao() { return conectar(); }

        public DataTable index()
        {
            try
            {
                return retDadosTabela("select * from TABROTAS");
            }
            catch (Exception ex)
            {
                msgErro(ex.Message.ToString());
                return null;
            }
        }
    }
}
