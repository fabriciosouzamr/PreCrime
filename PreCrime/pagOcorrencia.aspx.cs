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
    public partial class pagOcorrencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Boolean bEdicao;

                    clsBancoDados oDB = new clsBancoDados();

                    oDB.DBConectar();

                    oDB.DBComboBox_Carregar(cboOrigem, Constantes.cons_SqlCombo_OrigemOcorrencia, true);
                    oDB.DBComboBox_Carregar(cboClassificacao, Constantes.cons_SqlCombo_ClassificacaoOcorrencia, true);
                    oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);

                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)) > 0)
                    {
                        txtNomeIndividuo.Text = oDB.DBSQL_CadastroPessoa_Identificacao(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)));
                        txtNomeIndividuo.ReadOnly = true;
                    }

                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Ocorrencia_ID, 0)) > 0)
                    {
                        string sSqlText;

                        sSqlText = "SELECT * FROM " + oDB.DBTabela("vw_Ocorrencia") + " WHERE id_Ocorrencia = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Ocorrencia_ID, 0);

                        DataRow oRow = oDB.DBQuery_PrimeiraLinha(sSqlText);

                        lblCodigoOcorrencia.Text = oRow["id_Ocorrencia"].ToString().PadLeft(8, '0');
                        cboOrigem.SelectedValue = oRow["id_OrigemOcorrencia"].ToString();
                        cboClassificacao.SelectedValue = oRow["id_ClassificacaoOcorrencia"].ToString();
                        cboUF.SelectedValue = oRow["id_UF"].ToString();
                        clsFuncao.ComboBoxUF_Validar(cboUF, cboCidade);
                        cboCidade.SelectedValue = oRow["id_CidadeOcorrencia"].ToString();
                        
                        if (clsFuncao.IsDate(oRow["dt_Ocorrencia"].ToString()))
                        {
                            txtDataOcorrencia.Text = clsBancoDados.DBDataToString((DateTime)(oRow["dt_Ocorrencia"]));
                            txtHoraOcorrencia.Text = oRow["hr_Ocorrencia"].ToString();
                        }

                        txtNomeIndividuo.Text = oRow["ds_Individuo"].ToString();
                        txtDescricaoOcorrencia.Text = oRow["ds_Ocorrencia"].ToString();
                        txtBairro.Text = oRow["no_BairroOcorrencia"].ToString();
                        txtLogradouro.Text = oRow["ds_LocalOcorrencia"].ToString();
                    }
                    else
                    {
                        lblTitulo.Text = lblTitulo.Text + " - Inclusão";
                        lblCodigoOcorrencia.Text = "00000000";
                    }

                    oDB.DBDesconectar();
                    oDB = null;

                    bEdicao = (clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Visualizar).ToString() != Constantes.cons_Acao_Visualizar);

                    //Edicao(bEdicao);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsFuncao.ComboBoxUF_Validar(cboUF, cboCidade);
            cboCidade.Focus();
        }

        protected void cmdGravar_Click(object sender, EventArgs e)
        {
            if (!clsFuncao.ComboBox_Selecionado(cboOrigem))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Selecione a origem')</script>");
                return;
            }
            if (!clsFuncao.ComboBox_Selecionado(cboClassificacao))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Selecione a classificação')</script>");
                return;
            }
            if (!clsFuncao.IsDate(txtDataOcorrencia.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe a data da ocorrência')</script>");
                return;
            }
            if (!clsFuncao.IsHour(txtHoraOcorrencia.Text.Trim()))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe a hora da ocorrência')</script>");
                return;
            }
            if (txtNomeIndividuo.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome do indivíduo')</script>");
                return;
            }
            if (!clsFuncao.ComboBox_Selecionado(cboUF))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Selecione a U.F.')</script>");
                return;
            }
            if (!clsFuncao.ComboBox_Selecionado(cboCidade))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Selecione a Cidade')</script>");
                return;
            }
            if (txtBairro.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome do bairro')</script>");
                return;
            }
            if (txtLogradouro.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome do logradouro')</script>");
                return;
            }
            if (txtDescricaoOcorrencia.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe a descrição da ocorrência')</script>");
                return;
            }

            clsBancoDados oDB = new clsBancoDados();

            if (oDB.DBConectar())
            {
                int iID = 0;

                iID = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Ocorrencia_ID, 0));

                oDB.DBSQL_Ocorrencia_Gravar(ref iID,
                                            Convert.ToInt32(cboOrigem.SelectedValue),
                                            Convert.ToInt32(cboClassificacao.SelectedValue),
                                            Convert.ToInt32(cboCidade.SelectedValue),
                                            Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)),
                                            oDB.DBStringToData(txtDataOcorrencia.Text.Trim(), txtHoraOcorrencia.Text.Trim()),
                                            txtHoraOcorrencia.Text.Trim(),
                                            txtNomeIndividuo.Text,
                                            txtDescricaoOcorrencia.Text,
                                            txtBairro.Text,
                                            txtLogradouro.Text);

                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Ocorrencia_ID, iID);

                Server.Transfer("pagOcorrenciaListagem.aspx");
            }

            oDB.DBDesconectar();
        }
    }
}