using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;
using System.Web.Security;
using System.Data;

namespace PreCrime
{
    public partial class pagLogin : System.Web.UI.Page
    {
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            clsBancoDados oDB = new clsBancoDados();

            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Informe o usuário')</script>");
                    return;
                }
                if (txtSenha.Text.Trim() == "")
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Informe a senha')</script>");
                    return;
                }

                oDB.oResponse = Response;
                oDB.DBConectar();

                if (!oDB.bErro)
                {
                    string sSqlText = "SELECT id_Usuario, id_Tipo_Usuario FROM " + oDB.DBTabela("tb_usuario") + " WHERE ds_usuario= '" + txtUsuario.Text.Trim() + "' and ds_senha= '" + txtSenha.Text.Trim() + "'";
                    DataRow oRow = oDB.DBQuery_PrimeiraLinha(sSqlText);

                    if (oRow == null)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Usuário ou senha inválido')</script>");
                    }
                    else
                    {
                        Int32 iId_Usuario = Convert.ToInt32(oRow["id_Usuario"]);
                        Int32 iId_TipoUsuario = Convert.ToInt32(oRow["id_Tipo_Usuario"]);

                        if (iId_Usuario > 0)
                        {
                            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Sistema_IdUsuario, iId_Usuario);
                            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Sistema_IdTipoUsuario, iId_TipoUsuario);

                            FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text.ToString(), false);
                        }
                        else
                        {
                            Response.Write("<script LANGUAGE='JavaScript' >alert('Usuário ou senha inválido')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('" + oDB.sErro + "')</script>");
                }

                oDB.DBDesconectar();
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + ex.ToString() + "')</script>");
            }

            oDB = null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}