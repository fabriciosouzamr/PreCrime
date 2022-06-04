using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PreCrime.Funcoes
{
    public static class clsFuncao
    {
        private static Boolean Session_Existe(System.Web.SessionState.HttpSessionState oSession, string sNome)
        {
            Boolean bRet = false;

            if (oSession.Keys.Count > 0)
            {
                for (int i = 0; i < oSession.Keys.Count; i++)
                {
                    if (oSession.Keys[i] == sNome)
                    {
                        bRet = true;
                        break;
                    }
                }
            }

            return bRet;
        }

        public static object Session_Valor(System.Web.SessionState.HttpSessionState oSession, string sNome, object ValorPadrao)
        {
            object oRet;

            oRet = ValorPadrao;

            try
            {
                if (Session_Existe(oSession, sNome))
                {
                    oRet = oSession[sNome];
                }
            }
            catch (Exception ex)
            {
            }

            return oRet;
        }

        public static void Session_Setar(System.Web.SessionState.HttpSessionState oSession, string sNome, object Valor)
        {
            try
            {
                oSession.Remove(sNome);
            }
            catch (Exception ex)
            {
            }

            oSession.Add(sNome, Valor);
        }

        public static void Session_Limpar(System.Web.SessionState.HttpSessionState oSession, string sNome)
        {
            try
            {
                oSession.Remove(sNome);
            }
            catch (Exception ex)
            {
            }
        }

        public static string Cadastro_Tipo_Texto(int iTipoCadastro)
        {
            string sRet = "";

            switch (iTipoCadastro)
            {
                case Constantes.cons_TipoCadastro_BloqueioPesquisa:
                    sRet = "Bloqueio de Pesquisa";
                    break;
                case Constantes.cons_TipoCadastro_ClassificacaoOcorrencia:
                    sRet = "Classificação de Ocorrência";
                    break;
                case Constantes.cons_TipoCadastro_EstadoCivil:
                    sRet = "Estado Civil";
                    break;
                case Constantes.cons_TipoCadastro_GrauInstrucao:
                    sRet = "Grau de Instrução";
                    break;
                case Constantes.cons_TipoCadastro_Ocupacao:
                    sRet = "Ocupação";
                    break;
                case Constantes.cons_TipoCadastro_OrigemOcorrencia:
                    sRet = "Origem Ocorrência";
                    break;
                case Constantes.cons_TipoCadastro_Raca:
                    sRet = "Raça";
                    break;
                case Constantes.cons_TipoCadastro_Religiao:
                    sRet = "Religião";
                    break;
                case Constantes.cons_TipoCadastro_Sexo:
                    sRet = "Sexo";
                    break;
                case Constantes.cons_TipoCadastro_StatusAcompanhamento:
                    sRet = "Status do Acompanhamento";
                    break;
                case Constantes.cons_TipoCadastro_StatusAvaliacaoPsicologica:
                    sRet = "Status de Avaliação Psicológica";
                    break;
            }

            return sRet;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsHour(string sHora)
        {
            try
            {
                if (sHora.Length == 5)
                {
                    if (sHora.Trim().Substring(2, 1) == ":")
                    {
                        if ((Convert.ToInt32(sHora.Trim().Substring(0, 2)) >= 0) && (Convert.ToInt32(sHora.Trim().Substring(0, 2)) <= 23))
                        {
                            if ((Convert.ToInt32(sHora.Trim().Substring(3, 2)) >= 0) && (Convert.ToInt32(sHora.Trim().Substring(3, 2)) <= 59))
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static void Controle_Desabilitar(System.Web.UI.WebControls.WebControl obj, Boolean bDesabilitar)
        {
            obj.Attributes.Remove("disabled");

            if (bDesabilitar)
            {
                obj.Attributes.Add("disabled", "disabled");
            }
        }

        public static string SoNumero(string sValor)
        {
            int iCont;
            string sAux = "";
            for (iCont = 1; (iCont <= sValor.Length); iCont++)
            {
                if (IsNumeric(sValor.Substring((iCont - 1), 1)))
                {
                    sAux = (sAux + sValor.Substring((iCont - 1), 1));
                }

            }

            return sAux;
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static void ComboBoxUF_Validar(System.Web.UI.WebControls.DropDownList oComboUF, System.Web.UI.WebControls.DropDownList oComboCidade)
        {
            if (oComboUF.SelectedIndex == -1)
            {
                oComboCidade.DataSource = null;
            }
            else
            {
                if (clsFuncao.IsNumeric(oComboUF.SelectedValue))
                {
                    if (Convert.ToInt32(oComboUF.SelectedValue) > 0)
                    {
                        clsBancoDados oDB = new clsBancoDados();

                        oDB.DBConectar();
                        oDB.DBComboBox_Carregar_Cidade(oComboCidade,
                                                       Convert.ToInt32(oComboUF.SelectedValue), true);
                        oDB.DBDesconectar();
                    }
                }
            }
        }

        public static string CPFCNPJ_Formatar(string sCPFCNPJ)
        {
            if (sCPFCNPJ.Length <= 11)
            {
                MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00");
                mtpCpf.Set(ZerosEsquerda(sCPFCNPJ, 11));
                return mtpCpf.ToString();
            }
            else
            {
                MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00");
                mtpCnpj.Set(ZerosEsquerda(sCPFCNPJ, 11));
                return mtpCnpj.ToString();
            }
        }

        public static string ZerosEsquerda(string strString, int intTamanho)
        {
            string strResult = "";
            for (int intCont = 1; intCont <= (intTamanho - strString.Length); intCont++)
            {
                strResult += "0";
            }
            return strResult + strString;
        }

        public static DateTime ToDateTime(this string s, string format = "ddMMyyyy", string cultureString = "pt-BR")
        {
            try
            {
                var r = DateTime.ParseExact(
                    s: s,
                    format: format,
                    provider: CultureInfo.GetCultureInfo(cultureString));
                return r;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (CultureNotFoundException)
            {
                throw; // Given Culture is not supported culture
            }
        }

        public static DateTime ConvertToDateTime(object value)
        {
            DateTime convertedDate = new DateTime( 1900, 1, 1);

            try
            {
                convertedDate = Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
            }
            catch (InvalidCastException)
            {
            }

            return convertedDate;
        }


        public static void ComboBox_Possicionar(System.Web.UI.WebControls.DropDownList oCombo, string sValor)
        {
            try
            {
                oCombo.SelectedValue = sValor;
            }
            catch (Exception ex)
            {
            }
        }

        public static Boolean ComboBox_Selecionado(System.Web.UI.WebControls.DropDownList oCombo)
        {
            Boolean bRet = false;

            if (oCombo.SelectedIndex > -1)
            {
                if (oCombo.SelectedValue.Trim() !=  "")
                {
                    if (Convert.ToInt32(oCombo.SelectedValue) > 0)
                    {
                        bRet = true;
                    }
                }
            }

            return bRet;
        }

        public static void Str_Adicionar(ref string vVariavel, string sValor, string sSeparador)
        {
            if ((sValor.Trim() != ""))
            {
                if ((vVariavel.Trim() != ""))
                {
                    vVariavel = (vVariavel + sSeparador);
                }

                vVariavel = (vVariavel + sValor);
            }

        }

        public static string SQL_FormatarLike(string sCampo)
        {
            while (true)
            {
                if (((sCampo.IndexOf(" ") + 1)
                            > 0))
                {
                    sCampo = (sCampo.Substring(0, ((sCampo.IndexOf(" ") + 1)
                                    - 1)) + ("%" + sCampo.Substring((sCampo.IndexOf(" ") + 1))));
                }
                else
                {
                    break;
                }

            }

            //return (QuotedStr(("%" + (sCampo.ToUpper().Replace("\'", "\'\'") + "%"))) + " COLLATE utf8_bin");
            return (QuotedStr(("%" + (sCampo.ToUpper().Replace("\'", "\'\'") + "%"))));
        }

        public static string QuotedStr(string vValor)
        {
            return ("\'" + (Check_Aspas(vValor) + "\'"));
        }

        public static string Check_Aspas(string texto)
        {
            int cont;
            string retorno = "";
            cont = 1;
            do
            {
                if ((texto.Substring((cont - 1), 1) == "\'"))
                {
                    retorno = (retorno + "\'\'");
                }
                else
                {
                    retorno = (retorno + texto.Substring((cont - 1), 1));
                }

                cont = (cont + 1);
            } while ((cont <= texto.Length));

            return retorno;
        }

        public static void Alert(HttpResponse oResponse, string sMensagem)
        {
            oResponse.Write("<script LANGUAGE='JavaScript' >alert('" + sMensagem + "')</script>");
        }
    }
}