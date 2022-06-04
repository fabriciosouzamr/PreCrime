using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;

namespace PreCrime
{
    public partial class pagCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Boolean bEdicao;

                    lblTitulo.Text = clsFuncao.Cadastro_Tipo_Texto(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Tipo, 0)));

                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_ID, 0)) > 0)
                    {
                        clsBancoDados oDB = new clsBancoDados();
                        string sSqlText;

                        oDB.DBConectar();

                        sSqlText = "SELECT DS_CADASTRO FROM " + oDB.DBTabela("TB_CADASTRO") + " WHERE ID_CADASTRO = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_ID, 0);

                        txtNomeCadastro.Text = oDB.DBQuery_ValorUnico(sSqlText, "").ToString();

                        oDB.DBDesconectar();
                        oDB = null;

                        lblTitulo.Text = lblTitulo.Text + " - Edição (" + txtNomeCadastro.Text.Trim() + ")";
                    }
                    else
                    {
                        lblTitulo.Text = lblTitulo.Text + " - Inclusão";
                    }

                    bEdicao = (clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Visualizar).ToString() != Constantes.cons_Acao_Visualizar);

                    Edicao(bEdicao);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void cmdEditar_Click(object sender, EventArgs e)
        {
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Cadastro);
            Edicao(true);
        }

        protected void cmdCancelar_Click(object sender, EventArgs e)
        {
            Voltar();
        }

        private void Voltar()
        {
            if (clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Cadastro).ToString() != Constantes.cons_Acao_Editar_Cadastro)
            {
                Server.Transfer("pagCadastroListagem.aspx");
            }
            else
            {
                Edicao(false);
            }
        }

        private void Edicao(Boolean bEditar)
        {
            cmdEditar.Visible = !bEditar;
            cmdVoltar.Visible = !bEditar;
            cmdExcluir.Visible = !bEditar;
            cmdSalvar.Visible = bEditar;
            cmdCancelar.Visible = bEditar;
            frmCadastro.Disabled = !bEditar;

            if (bEditar)
            {
                txtNomeCadastro.CssClass = "form-control";
            }
            else
            {
                txtNomeCadastro.CssClass = "form-control disabled";
            }

            txtNomeCadastro.Enabled = bEditar;
        }

        protected void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeCadastro.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o nome')</script>");
                return;
            }

            clsBancoDados oDB = new clsBancoDados();

            if (oDB.DBConectar())
            {
                int iID = 0;

                iID = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_ID, 0));

                oDB.DBSQL_Cadastro_Gravar(ref iID,
                                          Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Tipo, 0)),
                                          txtNomeCadastro.Text);

                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_ID, iID);

                Voltar();
            }

            oDB.DBDesconectar();
        }

        protected void cmdVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("pagCadastroListagem.aspx");
        }

        protected void cmdExcluir_Click(object sender, EventArgs e)
        {
            clsBancoDados oDB = new clsBancoDados();

            if (oDB.DBConectar())
            {
                oDB.DBSQL_Cadastro_Excluir(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_ID, 0)));
            }

            oDB.DBDesconectar();
        }
    }
}