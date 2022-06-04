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
    public partial class pagPessoaListagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsBancoDados oDB = new clsBancoDados();

                oDB.DBConectar();
                oDB.DBComboBox_Carregar(cboEstadoCivil, Constantes.cons_SqlCombo_EstadoCivil, true);
                oDB.DBComboBox_Carregar(cboOcupacao, Constantes.cons_SqlCombo_Ocupacao, true);
                oDB.DBComboBox_Carregar(cboRaca, Constantes.cons_SqlCombo_Raca, true);
                oDB.DBComboBox_Carregar(cboSexo, Constantes.cons_SqlCombo_Sexo, true);
                oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);

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
            DataTable oData;
            clsBancoDados oDB = new clsBancoDados();

            sSqlText = "select cd_cpfcnpj," +
                              "no_pessoa," +
                              "no_mae," +
                              "no_reduzido," +
                              "dt_cadastro," +
                              "id_pessoa ID" +
                       " from " + oDB.DBTabela("vw_pessoa");

            if (txtCPF.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "(CD_CPFCNPJ LIKE '%" + txtCPF.Text.Trim().ToString() + "%' OR " +
                                                             "CD_CPFCNPJ LIKE '%" + clsFuncao.SoNumero(txtCPF.Text.Trim().ToString()) + "%' OR " +
                                                             "CD_CPFCNPJ LIKE '%" + clsFuncao.CPFCNPJ_Formatar(clsFuncao.SoNumero(txtCPF.Text.Trim().ToString())) + "%')", " AND ");
            }
            if (txtRG.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "(CD_RG LIKE '%" + txtRG.Text.Trim().ToString() + "%' OR " +
                                                             "CD_RG LIKE '%" + clsFuncao.SoNumero(txtRG.Text.Trim().ToString()) + "%')", " AND ");
            }
            if (txtNome.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "NO_PESSOA LIKE " + clsFuncao.SQL_FormatarLike(txtNome.Text), " AND ");
            }
            if (txtApelido.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "NO_REDUZIDO LIKE " + clsFuncao.SQL_FormatarLike(txtApelido.Text), " AND ");
            }
            if (txtMae.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "NO_MAE LIKE " + clsFuncao.SQL_FormatarLike(txtMae.Text), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboUF))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_ENDERECO_UF = " + cboUF.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboCidade))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_ENDERECO_CIDADE = " + cboCidade.SelectedValue, " AND ");
            }
            if (txtBairro.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "DS_ENDERECO_BAIRRO LIKE " + clsFuncao.SQL_FormatarLike(txtBairro.Text), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboOcupacao))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_OCUPACAO = " + cboOcupacao.SelectedValue, " AND ");
            }
            if (clsFuncao.IsDate(txtDataNascimento.Text))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "DT_NASCIMENTO = '" + oDB.DBDataToStringDB(txtDataNascimento.Text) + "'", " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboEstadoCivil))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_ESTADOCIVIL = " + cboEstadoCivil.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboSexo))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_SEXO = " + cboSexo.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboRaca))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ID_RACA = " + cboRaca.SelectedValue, " AND ");
            }
            if (sSqlText_Where.Trim() != "")
            {
                sSqlText = sSqlText +
                           " where " + sSqlText_Where;
            }

            sSqlText = sSqlText +
                       " order by no_pessoa";

            oDB.DBConectar();
            oData = oDB.DBQuery(sSqlText);
            oDB.DBDesconectar();

            grdItens.DataSource = oData;
            grdItens.DataBind();
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

        protected void cmdPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoaPesquisa);
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_PessoaPesquisa_ID, Convert.ToInt32(customer));

            Server.Transfer("pagPessoa.aspx");
        }

        protected void btnOcorrencias_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoaPesquisa);
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_Filtrar_ID, Convert.ToInt32(customer));

            Server.Transfer("pagOcorrenciaListagem.aspx");
        }

        protected void btnEntrevistas_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoaPesquisa);
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_Filtrar_ID, Convert.ToInt32(customer));
            
            Server.Transfer("pagPesquisa_Listagem.aspx");
        }

        protected void cmdNovo_Click(object sender, EventArgs e)
        {
            clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoaPesquisa);
            clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_PessoaPesquisa_ID);

            Server.Transfer("pagPessoa.aspx");
        }
    }
}