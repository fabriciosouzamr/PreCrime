using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PreCrime.Funcoes;

namespace PreCrime
{
    public partial class pagCadastroListagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Tipo, Request.QueryString["C"]);

                    lblTitulo.Text = clsFuncao.Cadastro_Tipo_Texto(Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Cadastro_Tipo, 0)));
                }
                catch (Exception)
                {
                };

                CarregarGrid();
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
            DataTable oData = new DataTable();
            clsBancoDados oDB = new clsBancoDados();

            //DataTable dbTeste = new DataTable();
            //DataRow Row;

            sSqlText = "SELECT ds_cadastro Descricao, id_cadastro ID" +
                        " FROM " + oDB.DBTabela("tb_cadastro") +
                        " WHERE id_tipocadastro = " + Session["Cadastro_Tipo"].ToString()  +
                        " ORDER by ds_cadastro";

            oDB.DBConectar();
            oData = oDB.DBQuery(sSqlText);
            oDB.DBDesconectar();

            //dbTeste.TableName = "TB_Teste";
            //dbTeste.Columns.Add("Descricao");
            //dbTeste.Columns.Add("ID");

            ////column = new DataColumn();
            ////column.DataType = System.Type.GetType("System.Int32");
            ////column.ColumnName = "id";
            ////table.Columns.Add(column);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 01";
            //Row["ID"] = 1;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 02";
            //Row["ID"] = 2;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 03";
            //Row["ID"] = 3;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 04";
            //Row["ID"] = 4;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 05";
            //Row["ID"] = 5;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 06";
            //Row["ID"] = 6;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 07";
            //Row["ID"] = 7;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 08";
            //Row["ID"] = 8;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 09";
            //Row["ID"] = 9;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 10";
            //Row["ID"] = 10;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 11";
            //Row["ID"] = 11;
            //dbTeste.Rows.Add(Row);

            //Row = dbTeste.NewRow();
            //Row["Descricao"] = "Nome Completo e Algo Mais e Tudo Mais 12";
            //Row["ID"] = 12;
            //dbTeste.Rows.Add(Row);

            grdItens.DataSource = oData;
            grdItens.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));
            var customer = button.CommandArgument;

            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_ID, customer);
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Listagem);
            Server.Transfer("pagCadastro.aspx");
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
            clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_ID, ID);

            if (Visualizar)
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Visualizar);
            }
            else
            {
                clsFuncao.Session_Setar(Session, Constantes.cons_Sessao_Cadastro_Acao, Constantes.cons_Acao_Editar_Listagem);
            }
            Server.Transfer("pagCadastro.aspx");
        }
    }
}