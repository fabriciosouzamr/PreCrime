using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel;
using System.Web.UI.WebControls;
using PreCrime.Funcoes;

namespace PreCrime.Funcoes
{
    public class clsBancoDados
    {
        public HttpResponse oResponse;
        public Boolean bErro;
        public string sErro;
    
        string sBancoDados = "sisma203_pc2020";
        //string sBancoDados = "prjpc";
   
        MySqlConnection connNivelAcesso = new MySqlConnection("Server=192.185.131.70;Port=3306;Database=sisma203_pc2020;Uid=sisma203_pc2020u;Pwd=Pwd#pc_U$20$20;");
        //MySqlConnection connNivelAcesso = new MySqlConnection("Server=50.62.209.46;Port=3306;Database=prjpc;Uid=prjpcusr;Pwd=832285;");
        //MySqlConnection connNivelAcesso = new MySqlConnection("Server=localhost;Port=3306;Database=prjpc;Uid=root;Pwd=832285;");

        public Boolean DBConectar()
        {
            Boolean bOk = false;

            Erro_Limpar();

            try
            {
                connNivelAcesso.Open();

                bOk = true;
            }
            catch (Exception ex)
            {
                oResponse.Write("<script LANGUAGE='JavaScript' >alert('Informe a senha')</script>");
                Erro_Setar(ex.Message);

                bOk = false;
            }

            return bOk;
        }

        public void DBDesconectar()
        {
            connNivelAcesso.Close();
        }

        public DataTable DBQuery(String sSqlText)
        {
            DataTable oRet = new DataTable();

            Erro_Limpar();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sSqlText, connNivelAcesso);

                MySqlDataReader reader = cmd.ExecuteReader();

                oRet.Load(reader);
            }
            catch (MySqlException ex)
            {
                Erro_Setar(ex.Message);
            }

            return oRet;
        }

        public DataRow DBQuery_PrimeiraLinha(String sSqlText)
        {
            DataTable oData = new DataTable();
            DataRow oRow = null;

            oData = DBQuery(sSqlText);

            if (oData != null)
            {
                if (oData.Rows.Count != 0)
                {
                    oRow = oData.Rows[0];
                }
            }

            return oRow;
        }

            public object DBQuery_ValorUnico(String sSqlText, object ValorPadrao = null, object Campos = null)
        {
            DataTable oRet = null;
            object iRet = 0;

            Erro_Limpar();

            try
            {
                oRet = DBQuery(sSqlText);

                if (oRet.Rows.Count > 0)
                {
                    if (Campos == null)
                    {
                        iRet = oRet.Rows[0][Convert.ToInt32(Campos)];
                    }
                }
                else
                {
                    iRet = ValorPadrao;
                }
            }
            catch (MySqlException ex)
            {
                Erro_Setar(ex.Message);
            }

            return iRet;
        }

        public string DBTabela(string sNome)
        {
            string sRet;

            sNome = sNome.ToLower().ToString();

            if (sBancoDados.Trim()=="")
            {
                sRet = sNome;
            }
            else
            {
                sRet = sBancoDados.Trim() + "." + sNome.Trim();
            }

            return sRet;
        }

        private void DBParametro(MySqlCommand cmd, 
                                 string sNome, 
                                 object Valor,
                                 MySqlDbType oTipo = MySqlDbType.VarChar,
                                 ParameterDirection oDirecao = ParameterDirection.Input)
        {
            cmd.Parameters.Add(new MySqlParameter(sNome, oTipo));
            cmd.Parameters[sNome].Direction = oDirecao;
            cmd.Parameters[sNome].Value = Valor;
        }

        public void DBComboBox_Carregar(DropDownList oCombo, string sSqlText, Boolean bLinhaSelecione = false)
        {
            DataTable oData;

            if (bLinhaSelecione)
            {
                sSqlText = sSqlText.Replace("from", ", 1 LS from");

                sSqlText = "select * from(select 0 ID, ' ' DS, 0 LS" +
                                       " union " +
                                         sSqlText + " ) X";

                sSqlText = sSqlText + " order by LS, DS";
            }
            else
            {
                sSqlText = sSqlText + " order by DS";
            }

            oData = DBQuery(sSqlText);

            oCombo.DataSource = oData;
            oCombo.DataBind();
        }

        public void DBComboBox_Carregar_Cidade(DropDownList oCombo, int Id_UF, Boolean bLinhaSelecione = false)
        {
            string sSqlText = Constantes.cons_SqlCombo_Cidade.Replace("[id_UF]", Id_UF.ToString());

            DBComboBox_Carregar(oCombo, sSqlText, bLinhaSelecione);
        }

        private void Erro_Limpar()
        {
            bErro = false;
            sErro = "";
        }

        private void Erro_Setar(string sMensagem)
        {
            bErro = true;
            sErro = sMensagem;
        }

        public Boolean DBSQL_Cadastro_Gravar(ref int iId_Cadastro, 
                                             int iId_TipoCadastro, 
                                             string sDs_Cadastro)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_cadastro_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DBParametro(cmd, "?p_id_cadastro", iId_Cadastro, MySqlDbType.Int32, ParameterDirection.InputOutput);
                DBParametro(cmd, "?p_id_tipocadastro", iId_TipoCadastro, MySqlDbType.Int32);
                DBParametro(cmd, "?p_ds_cadastro", sDs_Cadastro);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                //Get values from the output params
                iId_Cadastro = (int)cmd.Parameters["?p_id_cadastro"].Value;

                bOk = true;
            }
            catch (Exception)
            {
                throw;
            }

            return bOk;
        }

        public Boolean DBSQL_Resposta_Gravar(ref int iId_Resposta,
                                             int iId_Entrevistador,
                                             int iId_Entrevistado,
                                             int iId_Questionario)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_resposta_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DBParametro(cmd, "?p_id_resposta", iId_Resposta, MySqlDbType.Int32, ParameterDirection.InputOutput);
                DBParametro(cmd, "?p_id_entrevistador", iId_Entrevistador, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_entrevistado", iId_Entrevistado, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_questionario", iId_Questionario, MySqlDbType.Int32);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                //Get values from the output params
                iId_Resposta = (int)cmd.Parameters["?p_id_resposta"].Value;

                bOk = true;
            }
            catch (Exception)
            {
                throw;
            }

            return bOk;
        }

        public Boolean DBSQL_Resposta_Avaliacao_Gravar(ref int iId_Resposta_Avaliacao,
                                                       int iId_Resposta,
                                                       int iId_Status,
                                                       string sCm_Avaliacao)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_resposta_avaliacao_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DBParametro(cmd, "?p_id_resposta_avaliacao", iId_Resposta_Avaliacao, MySqlDbType.Int32, ParameterDirection.InputOutput);
                DBParametro(cmd, "?p_id_resposta", iId_Resposta, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_status", iId_Status, MySqlDbType.Int32);
                DBParametro(cmd, "?p_cm_avaliacao", sCm_Avaliacao, MySqlDbType.Text);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                //Get values from the output params
                iId_Resposta_Avaliacao = (int)cmd.Parameters["?p_id_resposta_avaliacao"].Value;

                bOk = true;
            }
            catch (Exception)
            {
                throw;
            }

            return bOk;
        }

        public Boolean DBSQL_Ocorrencia_Gravar(ref int p_id_ocorrencia,
                                               int p_id_OrigemOcorrencia,
                                               int p_id_ClassificacaoOcorrencia,
                                               int p_id_CidadeOcorrencia,
                                               int p_id_pessoa,
                                               DateTime p_dt_Ocorrencia,
                                               string p_hr_ocorrencia,
                                               string p_ds_Individuo,
                                               string p_ds_Ocorrencia,
                                               string p_no_BairroOcorrencia,
                                               string p_ds_LocalOcorrencia)
        {
            Boolean bOk = false;
            String sErro;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_ocorrencia_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DBParametro(cmd, "?p_id_ocorrencia", p_id_ocorrencia, MySqlDbType.Int32, ParameterDirection.InputOutput);
                DBParametro(cmd, "?p_id_OrigemOcorrencia", p_id_OrigemOcorrencia, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_ClassificacaoOcorrencia", p_id_ClassificacaoOcorrencia, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_CidadeOcorrencia", p_id_CidadeOcorrencia, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_pessoa", p_id_pessoa, MySqlDbType.Int32);
                DBParametro(cmd, "?p_dt_Registro", DataMySql(DateTime.Now), MySqlDbType.DateTime);
                DBParametro(cmd, "?p_dt_Ocorrencia", DataMySql(p_dt_Ocorrencia), MySqlDbType.DateTime);
                DBParametro(cmd, "?p_hr_ocorrencia", p_hr_ocorrencia, MySqlDbType.Text);
                DBParametro(cmd, "?p_ds_Individuo", p_ds_Individuo, MySqlDbType.Text);
                DBParametro(cmd, "?p_ds_Ocorrencia", p_ds_Ocorrencia, MySqlDbType.Text);
                DBParametro(cmd, "?p_no_BairroOcorrencia", p_no_BairroOcorrencia, MySqlDbType.Text);
                DBParametro(cmd, "?p_ds_LocalOcorrencia", p_ds_LocalOcorrencia, MySqlDbType.Text);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                //Get values from the output params
                p_id_ocorrencia = (int)cmd.Parameters["?p_id_ocorrencia"].Value;

                bOk = true;
            }
            catch (Exception ex)
            {
                sErro = ex.Message;
                throw;
            }

            return bOk;
        }

        public string DBSQL_CadastroPessoa_Identificacao(int Id_Pessoal)
        {
            string sSqlText = Constantes.cons_Sql_Pessoa_Descricao.Replace("[id_Pessoa]", Id_Pessoal.ToString());

            return DBQuery_ValorUnico(sSqlText).ToString();
        }

        public Boolean DBSQL_Resposta_Pergunta_Gravar(int iId_Resposta,
                                                      int Iid_Questionario_Pergunta,
                                                      int Iid_Questionario_Pergunta_Opcao)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_resposta_pergunta_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Prepare();

                DBParametro(cmd, "?p_id_resposta", iId_Resposta, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_questionario_pergunta", Iid_Questionario_Pergunta, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_questionario_pergunta_opcao", Iid_Questionario_Pergunta_Opcao, MySqlDbType.Int32);
                    
                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                bOk = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return bOk;
        }

        public Boolean DBSQL_Cadastro_Excluir(int iId_Cadastro)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_cadastro_del", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DBParametro(cmd, "?p_id_cadastro", iId_Cadastro, MySqlDbType.Int32, ParameterDirection.InputOutput);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                bOk = true;
            }
            catch (Exception)
            {
                throw;
            }

            return bOk;
        }

        public Boolean DBSQL_Pessoa_Gravar(ref int Iid_pessoa,
                                           object Iid_endereco_cidade,
                                           object Iid_estadocivil,
                                           object Iid_sexo,
                                           object Iid_raca,
                                           object Iid_grauinstrucao,
                                           object Iid_religiao,
                                           object Iid_ocupacao,
								                           string sNo_pessoa,
								                           string sNo_reduzido,
                                           string sNo_mae,
                                           DateTime dDt_nascimento,
                                           string sCd_CPFCNPJ,
                                           string sCd_RG,
                                           string sCd_Telefone_celular,
                                           string sCd_telefone_fixo,
                                           string sCd_telefone_recado,
                                           string sDs_endereco_logradouro,
                                           string sNr_endereco_logradouro,
                                           string sDs_endereco_bairro,
                                           string sDs_endereco_cep,
                                           string sDs_endereco_complemento,
                                           string sDs_localocupacao,
                                           string sIc_ativo)
        {
            Boolean bOk = false;

            try
            {
                //Basic command and connection initialization 
                MySqlCommand cmd = new MySqlCommand("sp_pessoa_cad", connNivelAcesso);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Prepare();

                DBParametro(cmd, "?p_id_pessoa", Iid_pessoa, MySqlDbType.Int32, ParameterDirection.InputOutput);
                DBParametro(cmd, "?p_id_endereco_cidade", Iid_endereco_cidade, MySqlDbType.Int32);
                DBParametro(cmd, "?p_id_estadocivil", Iid_estadocivil);
                DBParametro(cmd, "?p_id_sexo", Iid_sexo);
                DBParametro(cmd, "?p_id_raca", Iid_raca);
                DBParametro(cmd, "?p_id_grauinstrucao", Iid_grauinstrucao);
                DBParametro(cmd, "?p_id_religiao", Iid_religiao);
                DBParametro(cmd, "?p_id_ocupacao", Iid_ocupacao);
                DBParametro(cmd, "?p_no_pessoa", sNo_pessoa);
                DBParametro(cmd, "?p_no_reduzido", sNo_reduzido);
                DBParametro(cmd, "?p_no_mae", sNo_mae);
                DBParametro(cmd, "?p_dt_nascimento", DataMySql(dDt_nascimento));
                DBParametro(cmd, "?p_cd_cpfcnpj", sCd_CPFCNPJ);
                DBParametro(cmd, "?p_cd_rg", sCd_RG);
                DBParametro(cmd, "?p_cd_telefone_celular", sCd_Telefone_celular);
                DBParametro(cmd, "?p_cd_telefone_fixo", sCd_telefone_fixo);
                DBParametro(cmd, "?p_cd_telefone_recado", sCd_telefone_recado);
                DBParametro(cmd, "?p_ds_endereco_logradouro", sDs_endereco_logradouro);
                DBParametro(cmd, "?p_nr_endereco_logradouro", sNr_endereco_logradouro);
                DBParametro(cmd, "?p_ds_endereco_bairro", sDs_endereco_bairro);
                DBParametro(cmd, "?p_cd_endereco_cep", sDs_endereco_cep);
                DBParametro(cmd, "?p_ds_endereco_complemento", sDs_endereco_complemento);
                DBParametro(cmd, "?p_ds_localocupacao", sDs_localocupacao);
                DBParametro(cmd, "?p_ic_ativo", sIc_ativo);

                //Open connection and Execute 
                cmd.ExecuteNonQuery();

                //Get values from the output params
                Iid_pessoa = (int)cmd.Parameters["?p_id_pessoa"].Value;

                bOk = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return bOk;
        }

        public string DataMySql(DateTime Data)
        {
            try
            {
                return Data.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception)
            {

                return null;
            }
        }

        public object DBComboBox_Tratar(DropDownList oCombo)
        {
            object oRet = null;

            if (oCombo.SelectedIndex >-1)
            {
                if (oCombo.SelectedValue.Trim() != "")
                {
                    if (Convert.ToInt32(oCombo.SelectedValue) != 0)
                    {
                        oRet = Convert.ToInt32(oCombo.SelectedValue);
                    }
                }
            }

            return oRet;
        }

        public DateTime DBStringToData(string sData, string sHora = "")
        {
            DateTime dData = new DateTime();

            try
            {
                string sDia = sData.Substring(0, sData.IndexOf("/"));
                string sMes = sData.Substring(sData.IndexOf("/") + 1, sData.IndexOf("/", sData.IndexOf("/") + 1) - sData.IndexOf("/") - 1);
                string sAno = sData.Substring(sData.IndexOf("/", sData.IndexOf("/") + 1) + 1);

                dData = dData.AddDays(Convert.ToInt32(sDia) - 1);
                dData = dData.AddMonths(Convert.ToInt32(sMes) - 1);
                dData = dData.AddYears(Convert.ToInt32(sAno) - 1);

                if (sHora.Trim() != "")
                {
                    dData = dData.AddHours(Convert.ToInt32(sHora.Substring(0, 2)));
                    dData = dData.AddMinutes(Convert.ToInt32(sHora.Substring(3, 2)));
                }
            }
            catch (Exception ex)
            {
            }

            return dData;
        }

        public static string DBDataToString(DateTime dData)
        {
            string sData = "";

            sData = clsFuncao.ZerosEsquerda(dData.Day.ToString().Trim(), 2) + "/" +
                    clsFuncao.ZerosEsquerda(dData.Month.ToString().Trim(), 2) + "/" +
                    clsFuncao.ZerosEsquerda(dData.Year.ToString().Trim(), 4);

            return sData;
        }

        public string DBDataToStringDB(string sData)
        {
            string sDataRet = "";

            try
            {
                sDataRet = sData.Substring(6, 4) + "-" + sData.Substring(3, 2) + "-" + sData.Substring(0, 2);
            }
            catch (Exception)
            {
            }

            return sDataRet;
        }

        public object Session_Valor(System.Web.SessionState.HttpSessionState oSession, string sNome, object ValorPadrao)
        {
            return clsFuncao.Session_Valor(oSession, sNome, ValorPadrao);
        }
    }
}
