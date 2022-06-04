using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;
using System.Data;

namespace PreCrime
{
    public partial class pagAvaliacaoPiscologiaListagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsBancoDados oDB = new clsBancoDados();

                oDB.DBConectar();
                oDB.DBComboBox_Carregar(cboEstadoCivil, Constantes.cons_SqlCombo_EstadoCivil, true);
                oDB.DBComboBox_Carregar(cboOcupacao, Constantes.cons_SqlCombo_Ocupacao, true);
                oDB.DBComboBox_Carregar(cboStatusAvaliacao, Constantes.cons_SqlCombo_Raca, true);
                oDB.DBComboBox_Carregar(cboSexo, Constantes.cons_SqlCombo_Sexo, true);
                oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);
                oDB.DBComboBox_Carregar(cboStatusAvaliacao, Constantes.cons_SqlCombo_StatusAvaliacaoPsicologica, true);

                oDB.DBDesconectar();
            }
        }

        protected void grdItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            string sSqlText = "";
            string sSqlText_Where = "";
            DataTable oData = new DataTable(); ;
            clsBancoDados oDB = new clsBancoDados();

            sSqlText = "select cd_entrevistado_cpfcnpj," +
                              "no_entrevistador_endereco_cidade," +
                              "ds_entrevistador_endereco_bairro," +
                              "cd_entrevistado_cpfcnpj," +
                              "no_entrevistado_pessoa," +
                              "no_entrevistado_mae," +
                              "no_statusavalicao," +
                              "dt_avaliacao," +
                              "id_resposta_avaliacao ID" +
                       " from " + oDB.DBTabela("vw_resposta_avaliacao");

            if (txtCPF.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "(cd_entrevistado_cpfcnpj LIKE '%" + txtCPF.Text.Trim().ToString() + "%' OR " +
                                                             "cd_entrevistado_cpfcnpj LIKE '%" + clsFuncao.SoNumero(txtCPF.Text.Trim().ToString()) + "%' OR " +
                                                             "cd_entrevistado_cpfcnpj LIKE '%" + clsFuncao.CPFCNPJ_Formatar(clsFuncao.SoNumero(txtCPF.Text.Trim().ToString())) + "%')", " AND ");
            }
            if (txtRG.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "(cd_entrevistado_rg LIKE '%" + txtRG.Text.Trim().ToString() + "%' OR " +
                                                             "cd_entrevistado_rg LIKE '%" + clsFuncao.SoNumero(txtRG.Text.Trim().ToString()) + "%')", " AND ");
            }
            if (txtNome.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "no_entrevistado_pessoa LIKE " + clsFuncao.SQL_FormatarLike(txtNome.Text), " AND ");
            }
            if (txtApelido.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "no_entrevistado_reduzido LIKE " + clsFuncao.SQL_FormatarLike(txtApelido.Text), " AND ");
            }
            if (txtMae.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "no_entrevistado_mae LIKE " + clsFuncao.SQL_FormatarLike(txtMae.Text), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboUF))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_entrevistado_endereco_uf = " + cboUF.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboCidade))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_entrevistado_endereco_cidade = " + cboCidade.SelectedValue, " AND ");
            }
            if (txtBairro.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ds_entrevistador_endereco_bairro LIKE " + clsFuncao.SQL_FormatarLike(txtBairro.Text), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboOcupacao))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_entrevistado_ocupacao = " + cboOcupacao.SelectedValue, " AND ");
            }
            if (clsFuncao.IsDate(txtDataNascimento.Text))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "dt_entrevistado_nascimento = '" + oDB.DBDataToStringDB(txtDataNascimento.Text) + "'", " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboEstadoCivil))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_entrevistado_estadocivil = " + cboEstadoCivil.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboSexo))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_entrevistado_sexo = " + cboSexo.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboStatusAvaliacao))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_status = " + cboStatusAvaliacao.SelectedValue, " AND ");
            }
            if (sSqlText_Where.Trim() != "")
            {
                sSqlText = sSqlText +
                           " where " + sSqlText_Where;
            }

            sSqlText = sSqlText +
                       " order by no_entrevistado_pessoa, dt_avaliacao";

            oDB.DBConectar();
            oData = oDB.DBQuery(sSqlText);
            oDB.DBDesconectar();

            grdItens.DataSource = oData;
            grdItens.DataBind();
        }

        protected void BtnSelecionar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, Convert.ToInt32(customer));

            Server.Transfer("pagAvaliacaoPiscologia.aspx");
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
                cboCidade.Focus();
            }
        }

        protected void cmdPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        protected void cmdPendentes_Click(object sender, EventArgs e)
        {
            Server.Transfer("pagPesquisasPendentesAvaliacao.aspx");
        }

        protected void cmdLimparFiltro_Click(object sender, EventArgs e)
        {
            txtCPF.Text = "";
            txtRG.Text = "";
            txtNome.Text = "";
            txtApelido.Text = "";
            txtMae.Text = "";
            cboUF.SelectedIndex = -1;
            cboCidade.SelectedIndex = -1;
            txtBairro.Text = "";
            cboOcupacao.SelectedIndex = -1;
            txtDataNascimento.Text = "";
            cboEstadoCivil.SelectedIndex = -1;
            cboSexo.SelectedIndex = -1;
            cboStatusAvaliacao.SelectedIndex = -1;
        }
    }
}