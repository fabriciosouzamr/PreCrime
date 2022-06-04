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
    public partial class pagPessoa : System.Web.UI.Page
    {
        const string cons_TipoGravacao_Gravar = "G";
        const string cons_TipoGravacao_Entrevista = "E";

        protected void CmdGravar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o C.P.F.')</script>");
                return;
            }
            if (txtNome.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome')</script>");
                return;
            }
            if (txtMae.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome da mãe')</script>");
                return;
            }

            clsBancoDados oDB = new clsBancoDados();

            int Iid_Pessoa = 0;

            if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)) > 0)
            {
                Iid_Pessoa = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0));
            }
            else
            {
                Iid_Pessoa = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_ID, 0));
            }

            oDB.DBConectar();
            oDB.DBSQL_Pessoa_Gravar(ref Iid_Pessoa,
                                    oDB.DBComboBox_Tratar(cboCidade),
                                    oDB.DBComboBox_Tratar(cboEstadoCivil),
                                    oDB.DBComboBox_Tratar(cboSexo),
                                    oDB.DBComboBox_Tratar(cboRaca),
                                    oDB.DBComboBox_Tratar(cboGrauInstrucao),
                                    oDB.DBComboBox_Tratar(cboReligiao),
                                    oDB.DBComboBox_Tratar(cboOcupacao),
                                    txtNome.Text.Trim(),
                                    txtApelido.Text.Trim(),
                                    txtMae.Text.Trim(),
                                    oDB.DBStringToData(txtDataNascimento.Text.Trim()),
                                    txtCPF.Text,
                                    txtRG.Text,
                                    "",
                                    txtTelefone.Text,
                                    "",
                                    txtLogradouro.Text.Trim(),
                                    "",
                                    txtBairro.Text.Trim(),
                                    txtCEP.Text.Trim(),
                                    txtLogradouroComplemento.Text.Trim(),
                                    txtLocalOupacao.Text.Trim(),
                                    "S");
            oDB.DBDesconectar();

            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, Iid_Pessoa);

            if (clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa, "").ToString() != "")
            {
                string sPagina = clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa, "").ToString();    
                clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa);
                Server.Transfer(sPagina);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    switch (Request.QueryString["T"])
                    {
                        case Constantes.cons_TpoChamadorPessoa_Entrevista:
                            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa, "pagPesquisa.aspx");
                            break;
                        case Constantes.cons_TpoChamadorPessoa_Ocorrencia:
                            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa, "pagOcorrencia.aspx");
                            break;
                    }
                }
                catch (Exception)
                {
                    clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa);
                }

                clsBancoDados oDB = new clsBancoDados();

                oDB.DBConectar();
                oDB.DBComboBox_Carregar(cboEstadoCivil, Constantes.cons_SqlCombo_EstadoCivil, true);
                oDB.DBComboBox_Carregar(cboGrauInstrucao, Constantes.cons_SqlCombo_GrauInstrucao, true);
                oDB.DBComboBox_Carregar(cboOcupacao, Constantes.cons_SqlCombo_Ocupacao, true);
                oDB.DBComboBox_Carregar(cboRaca, Constantes.cons_SqlCombo_Raca, true);
                oDB.DBComboBox_Carregar(cboReligiao, Constantes.cons_SqlCombo_Religiao, true);
                oDB.DBComboBox_Carregar(cboSexo, Constantes.cons_SqlCombo_Sexo, true);

                oDB.DBComboBox_Carregar(cboUF, Constantes.cons_SqlCombo_UF, true);

                if ((Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_ID, 0)) > 0) ||
                    (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_PessoaPesquisa_ID, 0)) > 0))
                {
                    string sSqlText;
                    int iID_Pessoa = 0;

                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_ID, 0)) > 0)
                    {
                        iID_Pessoa = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_ID, 0));
                    }
                    else
                    {
                        iID_Pessoa = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_PessoaPesquisa_ID, 0));
                        clsFuncao.Session_Limpar(Session, Constantes.cons_Sessao_PessoaPesquisa_ID);
                    }

                    sSqlText = "SELECT * FROM " + oDB.DBTabela("vw_pessoa") + " WHERE id_pessoa = " + iID_Pessoa;

                    if (CarregarDados(oDB.DBQuery_PrimeiraLinha(sSqlText)))
                    {
                        Editar(true);
                    }

                    txtRG.Focus();
                }
                else
                {
                    lblCodigoPessoa.Text = "<Novo>";
                    txtTipoGravacao.Value = cons_TipoGravacao_Entrevista;

                    Editar(false);
                }

                if (clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_RequestPessoa, "").ToString() != "")
                {
                    cmdGravar.Text = "Prosseguir";
                }
                else
                {
                    cmdGravar.Text = "Gravar";
                }

                oDB.DBDesconectar();
            }
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

        private void Editar(Boolean bEditar)
        {
            clsFuncao.Controle_Desabilitar(txtRG, !bEditar);
            clsFuncao.Controle_Desabilitar(txtNome, !bEditar);
            clsFuncao.Controle_Desabilitar(txtApelido, !bEditar);
            clsFuncao.Controle_Desabilitar(txtMae, !bEditar);
            clsFuncao.Controle_Desabilitar(cboUF, !bEditar);
            clsFuncao.Controle_Desabilitar(cboCidade, !bEditar);
            clsFuncao.Controle_Desabilitar(txtLogradouro, !bEditar);
            clsFuncao.Controle_Desabilitar(txtBairro, !bEditar);
            clsFuncao.Controle_Desabilitar(txtCEP, !bEditar);
            clsFuncao.Controle_Desabilitar(txtLogradouroComplemento, !bEditar);
            clsFuncao.Controle_Desabilitar(txtTelefone, !bEditar);
            clsFuncao.Controle_Desabilitar(txtCelular, !bEditar);
            clsFuncao.Controle_Desabilitar(txtDataNascimento, !bEditar);
            clsFuncao.Controle_Desabilitar(cboEstadoCivil, !bEditar);
            clsFuncao.Controle_Desabilitar(cboSexo, !bEditar);
            clsFuncao.Controle_Desabilitar(cboRaca, !bEditar);
            clsFuncao.Controle_Desabilitar(cboGrauInstrucao, !bEditar);
            clsFuncao.Controle_Desabilitar(cboReligiao, !bEditar);
            clsFuncao.Controle_Desabilitar(cboOcupacao, !bEditar);
            clsFuncao.Controle_Desabilitar(txtLocalOupacao, !bEditar);
        }

        protected void cmdPesquisar_Click(object sender, EventArgs e)
        {
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_RequestPessoaPesquisa, "pagPessoa.aspx");
            Server.Transfer("pagPessoa_Pesquisa.aspx");
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e)
        {
            clsBancoDados oDB = new clsBancoDados();
            DataTable oData;

            string sSqlText;
            Boolean bTelaPesquisa = false;

            sSqlText = "SELECT * FROM " + oDB.DBTabela("VW_PESSOA") +
                       " WHERE CD_CPFCNPJ = '" + txtCPF.Text.Trim().ToString() + "'" +
                          " OR CD_CPFCNPJ = '" + clsFuncao.SoNumero(txtCPF.Text.Trim().ToString()) + "'" +
                          " OR CD_CPFCNPJ = '" + clsFuncao.CPFCNPJ_Formatar(clsFuncao.SoNumero(txtCPF.Text.Trim().ToString())) + "'";
            
            if (oDB.DBConectar())
            {
                oData = oDB.DBQuery(sSqlText);

                if (oData.Rows.Count == 1)
                {
                    CarregarDados(oData.Rows[0]);
                }
                else if (oData.Rows.Count > 0)
                {
                    bTelaPesquisa = true;
                }
            }

            oDB.DBDesconectar();

            Editar(true);
        }

        private Boolean CarregarDados(DataRow oRow)
        {
            if (oRow != null)
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, oRow["id_pessoa"].ToString());

                lblCodigoPessoa.Text = oRow["cd_cpfcnpj"].ToString() + " " + oRow["no_pessoa"].ToString();

                txtCPF.Text = oRow["cd_cpfcnpj"].ToString();
                txtNome.Text = oRow["no_pessoa"].ToString();
                txtRG.Text = oRow["cd_rg"].ToString();
                txtApelido.Text = oRow["no_reduzido"].ToString();
                txtMae.Text = oRow["no_mae"].ToString();
                clsFuncao.ComboBox_Possicionar(cboUF, oRow["id_endereco_uf"].ToString());
                clsFuncao.ComboBoxUF_Validar(cboUF, cboCidade);
                clsFuncao.ComboBox_Possicionar(cboCidade, oRow["id_endereco_cidade"].ToString());
                txtLogradouro.Text = oRow["ds_endereco_logradouro"].ToString();
                txtBairro.Text = oRow["ds_endereco_bairro"].ToString();
                txtCEP.Text = oRow["cd_endereco_cep"].ToString();
                txtLogradouroComplemento.Text = oRow["ds_endereco_complemento"].ToString();
                txtTelefone.Text = oRow["cd_telefone_fixo"].ToString();
                txtCelular.Text = oRow["cd_telefone_celular"].ToString();
                txtDataNascimento.Text = clsBancoDados.DBDataToString((DateTime)(oRow["dt_nascimento"]));
                clsFuncao.ComboBox_Possicionar(cboEstadoCivil, oRow["id_estadocivil"].ToString());
                clsFuncao.ComboBox_Possicionar(cboSexo, oRow["id_sexo"].ToString());
                clsFuncao.ComboBox_Possicionar(cboRaca, oRow["id_raca"].ToString());
                clsFuncao.ComboBox_Possicionar(cboGrauInstrucao, oRow["id_grauinstrucao"].ToString());
                clsFuncao.ComboBox_Possicionar(cboReligiao, oRow["id_religiao"].ToString());
                clsFuncao.ComboBox_Possicionar(cboOcupacao, oRow["id_ocupacao"].ToString());
                txtLocalOupacao.Text = oRow["ds_localocupacao"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}