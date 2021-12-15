using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sysgest___Transportes.codigo.dto;
using Sysgest___Transportes.codigo.bll;

namespace Sysgest___Transportes
{
    public partial class frm_servidor : DevExpress.XtraEditors.XtraForm
    {
        public frm_servidor()
        {
            InitializeComponent();
        }

        private void frm_servidor_Load(object sender, EventArgs e)
        {
            //size
            txt_servidor.Size = new Size(388, 35);
            txt_instancia.Size = new Size(388, 35);
            txt_utilizador.Size = new Size(388, 35);
            txt_bd.Size = new Size(388, 35);
            txt_senha.Size = new Size(388, 35);
            btn_conectar.Size = new Size(99, 30);
            btn_cancelar.Size = new Size(97, 30);

            //location
            lbl_servidor.Location = new Point(4, 21);
            lbl_instancia.Location = new Point(4, 91);
            lbl_utilizador.Location = new Point(4, 161);
            lbl_bd.Location = new Point(4, 231);
            lbl_senha.Location = new Point(4, 301);

            txt_servidor.Location = new Point(4, 50);
            txt_instancia.Location = new Point(4, 120);
            txt_utilizador.Location = new Point(4, 190);
            txt_bd.Location = new Point(4, 260);
            txt_senha.Location = new Point(4, 330);
            btn_conectar.Location = new Point(190, 372);
            btn_cancelar.Location = new Point(295, 372);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if((new rotasBLL()).msgConfirmacao("Deseja realmente sair?"))
                Application.Exit();
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            if(txt_servidor.Text == "" || txt_instancia.Text == "" || txt_utilizador.Text == "" || txt_bd.Text == "")
            {
                (new rotasBLL()).msgErro("Preencha todos os campos obrigatórios!");
                return;
            }
            servidorDTO.host = txt_servidor.Text;
            servidorDTO.data_source = txt_instancia.Text;
            servidorDTO.user_bd = txt_utilizador.Text;
            servidorDTO.bd = txt_bd.Text;
            servidorDTO.senha = txt_senha.Text;
            if ((new rotasBLL()).testarConexao())
            {
                (new rotasBLL()).msgInformacao("Conexão efectuada com sucesso!");
                frm_principal principal = new frm_principal();
                this.Hide();
                principal.Show();
            }

        }

        private void frm_servidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) btn_conectar.PerformClick();
        }
    }
}