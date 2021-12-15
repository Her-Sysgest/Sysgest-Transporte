using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Sysgest___Transportes.codigo.dto;
using DevExpress.XtraEditors;
using System.Data;

namespace Sysgest___Transportes.codigo.dal
{
    public class AcessoBancoDados
    {
        private SqlConnection conexao;
        private DataTable tabela;
        private SqlDataAdapter adaptador;

        //metodo para mensagem de confirmação
        public bool msgConfirmacao(string msg)
        {
            return XtraMessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        //metodo para mensagem de erro
        public bool msgErro(string msg)
        {
           XtraMessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        //metodo para mensagem de informacao
        public bool msgInformacao(string msg)
        {
            XtraMessageBox.Show(msg, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        //metodo para conectar-se ao banco de dados
        protected bool conectar()
        {
            try
            {
                if (servidorDTO.host == "" || servidorDTO.data_source == "" || servidorDTO.bd == "" || servidorDTO.user_bd == "" || servidorDTO.senha == "")
                {
                    MessageBox.Show("Parametros de conexão em falta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (conexao != null) conexao.Close();
                //"Data Source =" + BV_SRV + "\\" + BV_INSTSQL + ";Initial Catalog=" + BV_BD + ";User Id=" + BV_USER + ";Password=" + BV_PASS + ";"

                conexao = new SqlConnection("Data Source=" + servidorDTO.host + "\\" + servidorDTO.data_source + "; Initial Catalog=" + servidorDTO.bd + "; User ID=" + servidorDTO.user_bd + "; password=" + servidorDTO.senha);
                conexao.Open();
                //conexao.Close();
                return true;
            }
            catch (Exception e)
            {
                msgErro("Erro ao conectar-se com o banco de dados: " + e.Message.ToString() + "\nContacte o fornecedor da aplicação!");
                return false;
            }
        }

        //metodo para executar um comando no banco de dados
        protected bool executarComando(string comandoSQL)
        {
            try
            {
                if (!conectar()) return false;

                SqlCommand comando = new SqlCommand(comandoSQL, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
                return true;
            }
            catch (Exception ex)
            {
                msgErro("Erro ao executar esta acção: " + ex.Message.ToString() + "\nContacte o fornecedor da aplicação...!");
            }
            return false;
        }

        //metodo para consultar no banco de dados
        protected DataTable retDadosTabela(string comandoSql)
        {
            try
            {
                tabela = new DataTable();
                tabela.Clear();
                if (!conectar()) return tabela;
                adaptador = new SqlDataAdapter(comandoSql, conexao);
                adaptador.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                tabela = new DataTable();
                tabela.Clear();
                msgErro("Erro de consulta: " + ex.Message.ToString() + "\nContacte o fornecedor da aplicação...!");
            }
            return tabela;
        }
    }
}

