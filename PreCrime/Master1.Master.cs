using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;

namespace PreCrime
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(clsFuncao.Session_Valor(Session, Constantes.cons_Sessao_Sistema_IdTipoUsuario, 0)) == 1)
            {
                mnuConfiguracao.Visible = false;
            }
        }
    }
}