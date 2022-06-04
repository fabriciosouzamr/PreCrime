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
    public partial class pagOcorrenciaListagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    clsBancoDados oDB = new clsBancoDados();

                    oDB.DBConectar();

                    oDB.DBComboBox_Carregar(cboOrigem, Constantes.cons_SqlCombo_OrigemOcorrencia, true);
                    oDB.DBComboBox_Carregar(cboClassificacao, Constantes.cons_SqlCombo_ClassificacaoOcorrencia, true);
                    oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);

                    oDB.DBDesconectar();
                    oDB = null;

                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Filtrar_ID, 0)) != 0)
                    {
                        CarregarGrid(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Filtrar_ID, 0)));
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        protected void grdItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }

        private void CarregarGrid(int iPessoa = 0)
        {
            string sSqlText = "";
            string sSqlText_Where = "";
            DataTable oData = new DataTable();
            clsBancoDados oDB = new clsBancoDados();

            sSqlText = "SELECT ds_OrigemOcorrencia," +
                              "ds_ClassificacaoOcorrencia," +
                              "ds_LocalOcorrencia," +
                              "no_BairroOcorrencia," +
                              "date_format(dt_Registro, '%d/%m/%Y') dt_Registro," +
                              "date_format(dt_Ocorrencia, '%d/%m/%Y') dt_Ocorrencia," +
                              "hr_Ocorrencia," +
                              "ds_Individuo," +
                              "id_Ocorrencia ID" +
                        " FROM " + oDB.DBTabela("vw_ocorrencia_7dias");

            if (iPessoa != 0)
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_Pessoa = " + iPessoa.ToString(), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboOrigem))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_OrigemOcorrencia = " + cboOrigem.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboClassificacao))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_ClassificacaoOcorrencia = " + cboClassificacao.SelectedValue, " AND ");
            }
            if (txtDataOcorrencia.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "dt_Ocorrencia = '" + oDB.DataMySql(oDB.DBStringToData(txtDataOcorrencia.Text)) + "'", " AND ");
            }
            if (txtHoraOcorrencia.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "hr_Ocorrencia = '" + txtHoraOcorrencia.Text + "'", " AND ");
            }
            if (txtNomeIndividuo.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ds_Individuo LIKE " + clsFuncao.SQL_FormatarLike(txtNomeIndividuo.Text), " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboUF))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_UF = " + cboUF.SelectedValue, " AND ");
            }
            if (clsFuncao.ComboBox_Selecionado(cboCidade))
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "id_Cidade = " + cboCidade.SelectedValue, " AND ");
            }
            if (txtBairro.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "no_BairroOcorrencia LIKE " + clsFuncao.SQL_FormatarLike(txtBairro.Text), " AND ");
            }
            if (txtLogradouro.Text.Trim() != "")
            {
                clsFuncao.Str_Adicionar(ref sSqlText_Where, "ds_LocalOcorrencia LIKE " + clsFuncao.SQL_FormatarLike(txtLogradouro.Text), " AND ");
            }

            if (sSqlText_Where.Trim() != "")
            {
                sSqlText = sSqlText +
                           " where " + sSqlText_Where;
            }

            sSqlText = sSqlText +
                        " ORDER by dt_Registro, ds_OrigemOcorrencia";

            oDB.DBConectar();
            oData = oDB.DBQuery(sSqlText);
            oDB.DBDesconectar();

            grdItens.DataSource = oData;
            grdItens.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Ocorrencia_ID, customer);
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Listagem);
            Server.Transfer("pagOcorrencia.aspx");
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            FormCadastro(Convert.ToInt32(customer), true);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));

            var customer = button.CommandArgument;

            clsBancoDados oDB = new clsBancoDados();

            return;

            if (oDB.DBConectar())
            {
                oDB.DBSQL_Cadastro_Excluir(Convert.ToInt32(customer));
                CarregarGrid();
            }

            oDB.DBDesconectar();
        }

        protected void cmdNovoItem_Click(object sender, EventArgs e)
        {
            FormCadastro(0, false);
        }

        private void FormCadastro(int ID, Boolean Visualizar)
        {
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Ocorrencia_ID, ID);

            if (Visualizar)
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Visualizar);
            }
            else
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Listagem);
            }
  
            Server.Transfer("pagPessoa.aspx?T=2");
        }

        protected void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsFuncao.ComboBoxUF_Validar(cboUF, cboCidade);
            cboCidade.Focus();
        }

        protected void cmdPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}