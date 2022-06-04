using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;

namespace PreCrime
{
    public partial class pagUsuario : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsBancoDados oDB = new clsBancoDados();

                oDB.DBConectar();
                oDB.DBComboBox_Carregar(cboEstadoCivil, Constantes.cons_SqlCombo_EstadoCivil, true);
                oDB.DBComboBox_Carregar(cboGrauInstrucao, Constantes.cons_SqlCombo_GrauInstrucao, true);
                oDB.DBComboBox_Carregar(cboRaca, Constantes.cons_SqlCombo_Raca, true);
                oDB.DBComboBox_Carregar(cboReligiao, Constantes.cons_SqlCombo_Religiao, true);
                oDB.DBComboBox_Carregar(cboSexo, Constantes.cons_SqlCombo_Sexo, true);

                oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);
                oDB.DBDesconectar();

                lblEntrevistado.Text = "<Novo>";
            }
        }

        protected void CmdGravar_Click(object sender, EventArgs e)
        {
        }

        protected void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUF.SelectedIndex == -1)
            {
                cboCidade.DataSource = null;
            }
            else
            {
                clsBancoDados oDB = new clsBancoDados();

                oDB.DBConectar();
                oDB.DBComboBox_Carregar_Cidade(cboCidade,
                                               Convert.ToInt32(cboUF.SelectedValue), true);
                oDB.DBDesconectar();
            }
        }
    }
}