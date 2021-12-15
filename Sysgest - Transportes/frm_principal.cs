using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace Sysgest___Transportes
{
    public partial class frm_principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool sair = false;
        frm_rota rotas;
        frm_marca marca;

        public frm_principal()
        {
            InitializeComponent();
        }

        private void btn_sair_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseReason cr = new CloseReason();
            FormClosingEventArgs d = new FormClosingEventArgs(cr, false);
            frm_principal_FormClosing(sender, d);
        }

        private void frm_principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!sair)
            {
                if (XtraMessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sair = true;
                    frm_servidor server = new frm_servidor();
                    this.Hide();
                    server.Show();
                }
                else
                {
                    e.Cancel = true;
                    frm_servidor server = new frm_servidor();
                    this.Hide();
                    server.Show();
                }
            }
            else Application.Exit();
        }

        private void btn_rotas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (forms.Controls.Contains(rotas))
            {
                rotas.BringToFront();
            }
            else
            {
                //tab.Text = "Rotas";
                rotas = new frm_rota();
                rotas.TopLevel = false;
                rotas.Dock = DockStyle.Fill;
                rotas.WindowState = FormWindowState.Normal;
                rotas.Size = forms.Size;
                forms.Controls.Add(rotas); 
                rotas.Show();
                rotas.BringToFront();
            }
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
            //pnl_forms.Tabs.Clear();
        }

        private void pnl_forms_ControlRemoved(object sender, ControlEventArgs e)
        {
        }

        private void forms_BindingContextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_marca_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Controls.Contains(marca))
            {
                marca.BringToFront();
            }
            else
            {
                //tab.Text = "Marca";
                marca = new frm_marca();
                marca.TopLevel = false;
                marca.Dock = DockStyle.Fill;
                this.Controls.Add(marca);
                marca.Show();
                marca.BringToFront();
            }
        }
    }
}
