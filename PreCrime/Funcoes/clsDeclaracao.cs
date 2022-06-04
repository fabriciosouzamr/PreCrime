using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreCrime.Funcoes
{
    static class Constantes
    {
        public const int cons_TipoCadastro_Sexo = 1;
        public const int cons_TipoCadastro_Raca = 2;
        public const int cons_TipoCadastro_EstadoCivil = 3;
        public const int cons_TipoCadastro_GrauInstrucao = 4;
        public const int cons_TipoCadastro_Religiao = 5;
        public const int cons_TipoCadastro_BloqueioPesquisa = 6;
        public const int cons_TipoCadastro_Ocupacao = 7;
        public const int cons_TipoCadastro_OrigemOcorrencia = 8;
        public const int cons_TipoCadastro_ClassificacaoOcorrencia = 9;
        public const int cons_TipoCadastro_StatusAcompanhamento = 10;
        public const int cons_TipoCadastro_StatusAvaliacaoPsicologica = 11;

        public const int cons_TipoUsuario_Administrador = 1;
        public const int cons_TipoUsuario_Gerente = 2;
        public const int cons_TipoUsuario_Entrevistador = 3;
        public const int cons_TipoUsuario_Supervisao = 4;
        public const int cons_TipoUsuario_Psicologo = 5;

        public const string cons_TpoChamadorPessoa_Entrevista = "1";
        public const string cons_TpoChamadorPessoa_Ocorrencia = "2";

        public const string cons_SqlCombo_Sexo = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 1";
        public const string cons_SqlCombo_Raca = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 2";
        public const string cons_SqlCombo_EstadoCivil = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 3";
        public const string cons_SqlCombo_GrauInstrucao = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 4";
        public const string cons_SqlCombo_Religiao = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 5";
        public const string cons_SqlCombo_BloqueioPesquisa = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 6";
        public const string cons_SqlCombo_Ocupacao = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 7";
        public const string cons_SqlCombo_OrigemOcorrencia = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 8";
        public const string cons_SqlCombo_ClassificacaoOcorrencia = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 9";
        public const string cons_SqlCombo_StatusAcompanhamento = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 10";
        public const string cons_SqlCombo_StatusAvaliacaoPsicologica = "select id_cadastro ID, ds_cadastro DS from prjpc.tb_cadastro where id_tipocadastro = 11";

        public const string cons_SqlCombo_UF = "select id_UF ID, no_UF DS from prjpc.tb_uf";
        public const string cons_SqlCombo_Cidade = "select id_Cidade ID, no_Cidade DS from prjpc.tb_cidade where id_UF = [id_UF]";

        public const string cons_Sql_Pessoa_Descricao = "SELECT CONCAT(cd_cpfcnpj, ' ', no_pessoa) FROM prjpc.tb_pessoa where id_pessoa = [id_Pessoa]";

        public const string cons_Acao_Visualizar = "VI";
        public const string cons_Acao_Editar_Listagem = "EL";
        public const string cons_Acao_Editar_Cadastro = "EC";

        public const string cons_Sessao_Sistema_IdUsuario = "Sistema_IdUsuario";
        public const string cons_Sessao_Sistema_IdTipoUsuario = "Sistema_IdTipoUsuario";

        public const string cons_Sessao_Cadastro_ID = "Cadastro_ID";
        public const string cons_Sessao_Cadastro_Tipo = "Cadastro_Tipo";
        public const string cons_Sessao_Cadastro_Acao = "Acao";

        public const string cons_Sessao_Pessoa_ID = "Pessoa_ID";
        public const string cons_Sessao_Pessoa_Gravado_ID = "Pessoa_Gravado_ID";
        public const string cons_Sessao_Pessoa_Filtrar_ID = "Pessoa_Filtrar_ID";
        public const string cons_Sessao_Pessoa_RequestPessoa = "Pessoa_RequestPessoa";

        public const string cons_Sessao_PessoaPesquisa_ID = "PessoaPesquisa_ID";
        public const string cons_Sessao_Pessoa_RequestPessoaPesquisa = "Pessoa_RequestPessoaPesquisa";

        public const string cons_Sessao_AvaliacaoPsicologica_ID = "AvaliacaoPsicologica_ID";
        public const string cons_Sessao_AvaliacaoPsicologica_IDResposta = "AvaliacaoPsicologica_IDPessoa";

        public const string cons_Sessao_Pesquisa_ID = "Pesquisa_ID";

        public const string cons_Sessao_Ocorrencia_ID = "Ocorrencia_ID";
    }
}