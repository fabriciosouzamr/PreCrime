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
    public partial class pagPessoa_Cidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sSqlText = "";
            DataTable oData;
            clsBancoDados oDB = new clsBancoDados();

            DataTable dbTeste = new DataTable();
            DataRow Row;

            //sSqlText = "SELECT ds_cadastro Descricao, id_cadastro ID" +
            //            " FROM prjpc.tb_cadastro" +
            //            " WHERE id_tipocadastro = " + Session["Cadastro_Tipo"].ToString() +
            //            " ORDER by ds_cadastro";

            //oDB.DBConectar();
            //oData = oDB.DBQuery(sSqlText);
            //oDB.DBDesconectar();

            dbTeste.TableName = "TB_Teste";
            dbTeste.Columns.Add("Descricao");
            dbTeste.Columns.Add("ID");

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Int32");
            //column.ColumnName = "id";
            //table.Columns.Add(column);

            Row = dbTeste.NewRow();
            Row["Descricao"] = "Buerarema";
            Row["ID"] = 1;
            dbTeste.Rows.Add(Row);

            Row = dbTeste.NewRow();
            Row["Descricao"] = "Ilhéus";
            Row["ID"] = 2;
            dbTeste.Rows.Add(Row);

            Row = dbTeste.NewRow();
            Row["Descricao"] = "Itabuna";
            Row["ID"] = 3;
            dbTeste.Rows.Add(Row);

            grdItens.DataSource = dbTeste;
            grdItens.DataBind();
        }

        protected void cmdNovo_Click(object sender, EventArgs e)
        {

        }

        protected void cmdGravar_Click(object sender, EventArgs e)
        {

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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));

            var customer = button.CommandArgument;

            //oFuncao.Session_Setar(Session, "Cadastro_ID", customer);
            //oFuncao.Session_Setar(Session, "Visualizacao", "N");
            Server.Transfer("pagCadastro.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            var button = (((Button)sender));

            var customer = button.CommandArgument;

            clsBancoDados oDB = new clsBancoDados();

            if (oDB.DBConectar())
            {
                oDB.DBSQL_Cadastro_Excluir(Convert.ToInt32(customer));
            }

            oDB.DBDesconectar();
        }

        protected void grdItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            //CarregarGrid();
        }
    }
}