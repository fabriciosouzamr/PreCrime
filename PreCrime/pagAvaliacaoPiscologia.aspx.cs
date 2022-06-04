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
    public partial class pagAvaliacaoPiscologia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsBancoDados oDB = new clsBancoDados();
                DataRow oRow;
                string sSqlText = "";

                if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, 0)) != 0)
                {
                    sSqlText = "select * from " + oDB.DBTabela("vw_resposta_avaliacao") + 
                               " where id_resposta_avaliacao = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, 0);
                }
                else if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_IDResposta, 0)) != 0)
                {
                    sSqlText = "select * from " + oDB.DBTabela("vw_resposta") +
                               " where id_resposta = " + clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_IDResposta, 0);
                }

                oDB.DBConectar();
                oDB.DBComboBox_Carregar(cboStatus, Constantes.cons_SqlCombo_StatusAvaliacaoPsicologica, true);
                oRow = oDB.DBQuery_PrimeiraLinha(sSqlText);
                oDB.DBDesconectar();

                lblPessoa.Text = oRow["cd_entrevistado_cpfcnpj"].ToString() + " - " + oRow["no_entrevistado_pessoa"].ToString().Trim();
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_IDResposta, oRow["id_resposta"].ToString());

                if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, 0)) != 0)
                {
                    clsFuncao.ComboBox_Possicionar(cboStatus, oRow["id_status"].ToString());
                    lblPessoa.Text = lblPessoa.Text + " - avaliação realizada em: " + oRow["dt_avaliacao"].ToString().Trim();
                    txtComentario.Text = oRow["cm_avaliacao"].ToString().Trim();
                }
            }
        }

        protected void cmdGravar_Click(object sender, EventArgs e)
        {
            if (!clsFuncao.ComboBox_Selecionado(cboStatus))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Selecione o status')</script>");
                return;
            }
            if (txtComentario.Text.Trim() == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o comentário sobre a pesquisa')</script>");
                return;
            }

            clsBancoDados oDB = new clsBancoDados();

            if (oDB.DBConectar())
            {
                int iID = 0;

                iID = Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, 0));

                oDB.DBSQL_Resposta_Avaliacao_Gravar(ref iID,
                                                    Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_IDResposta, 0)),
                                                    Convert.ToInt32(cboStatus.SelectedValue),
                                                    txtComentario.Text);

                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_AvaliacaoPsicologica_ID, iID);

                lblStatus.Text = "Gravação efetuada em " + System.DateTime.Now.ToString();
            }

            oDB.DBDesconectar();
        }
    }
}