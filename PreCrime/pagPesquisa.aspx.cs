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
     public partial class pagPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNomePesquisa.Text = "Pesquisa Teste";

                Carregar();

                if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0)) != 0)
                {
                    if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Sistema_IdTipoUsuario, 0)) == Constantes.cons_TipoUsuario_Psicologo)
                    {
                        cmdGravar.Text = "Avaliar";
                    }
                    else
                    {
                        cmdGravar.Visible = false;
                    }
                }
                else
                {
                    cmdGravar.Visible = true;
                }
            }
        }

        protected void CmdGravar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Sistema_IdTipoUsuario, 0)) == Constantes.cons_TipoUsuario_Psicologo &&
                Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0)) != 0)
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_IDResposta, clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0));

                Server.Transfer("pagAvaliacaoPiscologia.aspx");
            }
            else
            {
                Boolean bInvalido = false;

                Pergunta_Validar(cboPergunta01, lblPergunta01, ref bInvalido);
                Pergunta_Validar(cboPergunta02, lblPergunta02, ref bInvalido);
                Pergunta_Validar(cboPergunta03, lblPergunta03, ref bInvalido);
                Pergunta_Validar(cboPergunta04, lblPergunta04, ref bInvalido);
                Pergunta_Validar(cboPergunta05, lblPergunta05, ref bInvalido);
                Pergunta_Validar(cboPergunta06, lblPergunta06, ref bInvalido);
                Pergunta_Validar(cboPergunta07, lblPergunta07, ref bInvalido);
                Pergunta_Validar(cboPergunta08, lblPergunta08, ref bInvalido);
                Pergunta_Validar(cboPergunta09, lblPergunta09, ref bInvalido);
                Pergunta_Validar(cboPergunta10, lblPergunta10, ref bInvalido);
                Pergunta_Validar(cboPergunta11, lblPergunta11, ref bInvalido);
                Pergunta_Validar(cboPergunta12, lblPergunta12, ref bInvalido);
                Pergunta_Validar(cboPergunta13, lblPergunta13, ref bInvalido);
                Pergunta_Validar(cboPergunta14, lblPergunta14, ref bInvalido);
                Pergunta_Validar(cboPergunta15, lblPergunta15, ref bInvalido);

                if (bInvalido)
                {
                    clsFuncao.Alert(Response, "As perguntas em vermelho precisam ser respondidas");
                    return;
                }
                else
                {
                    clsBancoDados oDB = new clsBancoDados();

                    if (oDB.DBConectar())
                    {
                        int iId_Resposta = 0;
                        int iId_Usuario = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Sistema_IdUsuario, 0));
                        int iId_Entrevistado = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0));
                        int iId_Questionario = Convert.ToInt32(oDB.DBQuery_ValorUnico("SELECT id_pesquisa_padrao FROM " + oDB.DBTabela("tb_configuracao")));

                        oDB.DBSQL_Resposta_Gravar(ref iId_Resposta, iId_Usuario, iId_Entrevistado, iId_Questionario);

                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta01.Attributes["ID"]), Convert.ToInt32(cboPergunta01.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta02.Attributes["ID"]), Convert.ToInt32(cboPergunta02.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta03.Attributes["ID"]), Convert.ToInt32(cboPergunta03.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta04.Attributes["ID"]), Convert.ToInt32(cboPergunta04.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta05.Attributes["ID"]), Convert.ToInt32(cboPergunta05.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta06.Attributes["ID"]), Convert.ToInt32(cboPergunta06.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta07.Attributes["ID"]), Convert.ToInt32(cboPergunta07.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta08.Attributes["ID"]), Convert.ToInt32(cboPergunta08.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta09.Attributes["ID"]), Convert.ToInt32(cboPergunta09.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta10.Attributes["ID"]), Convert.ToInt32(cboPergunta10.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta11.Attributes["ID"]), Convert.ToInt32(cboPergunta11.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta12.Attributes["ID"]), Convert.ToInt32(cboPergunta12.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta13.Attributes["ID"]), Convert.ToInt32(cboPergunta13.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta14.Attributes["ID"]), Convert.ToInt32(cboPergunta14.SelectedValue));
                        oDB.DBSQL_Resposta_Pergunta_Gravar(iId_Resposta, Convert.ToInt32(cboPergunta15.Attributes["ID"]), Convert.ToInt32(cboPergunta15.SelectedValue));

                        Server.Transfer("pagInicial.aspx");
                    }

                    oDB.DBDesconectar();
                }
            }
        }

        private void Pergunta_Validar(DropDownList oComboBox, Label oLabel, ref Boolean bInvalido)
        {
            if (!clsFuncao.ComboBox_Selecionado(oComboBox))
            {
                oLabel.ForeColor = System.Drawing.Color.Red;
                bInvalido = true;
            }
            else
            {
                oLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Carregar()
        {
            clsBancoDados oDB = new clsBancoDados();
            object[] oControles = new object[15];
            DropDownList oControle;
            
            cboPergunta01.Attributes.Add("ID", "1");
            cboPergunta02.Attributes.Add("ID", "2");
            cboPergunta03.Attributes.Add("ID", "3");
            cboPergunta04.Attributes.Add("ID", "4");
            cboPergunta05.Attributes.Add("ID", "5");
            cboPergunta06.Attributes.Add("ID", "6");
            cboPergunta07.Attributes.Add("ID", "7");
            cboPergunta08.Attributes.Add("ID", "8");
            cboPergunta09.Attributes.Add("ID", "9");
            cboPergunta10.Attributes.Add("ID", "10");
            cboPergunta11.Attributes.Add("ID", "11");
            cboPergunta12.Attributes.Add("ID", "12");
            cboPergunta13.Attributes.Add("ID", "13");
            cboPergunta14.Attributes.Add("ID", "14");
            cboPergunta15.Attributes.Add("ID", "15");

            oControles[0] = cboPergunta01;
            oControles[1] = cboPergunta02;
            oControles[2] = cboPergunta03;
            oControles[3] = cboPergunta04;
            oControles[4] = cboPergunta05;
            oControles[5] = cboPergunta06;
            oControles[6] = cboPergunta07;
            oControles[7] = cboPergunta08;
            oControles[8] = cboPergunta09;
            oControles[9] = cboPergunta10;
            oControles[10] = cboPergunta11;
            oControles[11] = cboPergunta12;
            oControles[12] = cboPergunta13;
            oControles[13] = cboPergunta14;
            oControles[14] = cboPergunta15;

            oDB.DBConectar();

            if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)) != 0)
            {
                lblEntrevistado.Text = oDB.DBSQL_CadastroPessoa_Identificacao(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pessoa_Gravado_ID, 0)));
            }
            else if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0)) != 0)
            {
                string sSqlText;
                DataTable oData;
                DataRow oRow;

                sSqlText = "select * from " + oDB.DBTabela("vw_resposta") + " where id_resposta = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0);
                oRow = oDB.DBQuery_PrimeiraLinha(sSqlText);
                lblEntrevistado.Text = oRow["cd_entrevistado_cpfcnpj"].ToString().Trim() + " " + oRow["no_entrevistado_pessoa"].ToString().Trim();
                lblEntrevistado.Text = lblEntrevistado.Text + " - entrevista realizada em: " + oRow["dt_resposta"].ToString().Trim();

                sSqlText = "select * from " + oDB.DBTabela("vw_resposta_pergunta") + " where id_resposta = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Pesquisa_ID, 0);
                oData = oDB.DBQuery(sSqlText);

                for (int i = 0; i < oData.Rows.Count; i++)
                {
                    oRow = oData.Rows[i];

                    for (int ii = 0; ii < oControles.Length; ii++)
                    {
                        oControle = (oControles[ii] as DropDownList);

                        if (Convert.ToInt32((oControle as DropDownList).Attributes["ID"]) == Convert.ToInt32(oRow["id_questionario_pergunta"].ToString()))
                        {
                            clsFuncao.ComboBox_Possicionar(oControle, oRow["id_questionario_pergunta_opcao"].ToString());
                        }
                    }
                }

                for (int ix = 0; ix < oControles.Length; ix++)
                {
                    (oControles[ix] as DropDownList).Enabled = false;
                    (oControles[ix] as DropDownList).CssClass = "disabled";
                }
            }

            oDB.DBDesconectar();
        }
    }
}