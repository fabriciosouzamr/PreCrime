<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagOcorrencia.aspx.cs" Inherits="PreCrime.pagOcorrencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <fieldset>
            <asp:HiddenField ID="txtTipoGravacao" runat="server" />
            <div class="form-group">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Ocorrência</asp:Label><br />
                        <asp:Label class="control-label" ID="Label1" runat="server">Código da Ocorrência: </asp:Label>
                        <asp:Label class="control-label" ID="lblCodigoOcorrencia" runat="server">00000001</asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="cboOrigem">Origem</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1" ID="cboOrigem"
                                                                                       DataTextField="DS"
                                                                                       DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboClassificacao">Classificação</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1" ID="cboClassificacao"
                                                                                       DataTextField="DS"
                                                                                       DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtDataOcorrencia">Dt. Ocorrência</label>
                        <asp:TextBox ID="txtDataOcorrencia" runat="server" OnKeyPress="return formata(this, '§§/§§/§§§§', event)" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtHoraOcorrencia">Hr. Ocorrência</label>
                        <asp:TextBox ID="txtHoraOcorrencia" runat="server" OnKeyPress="return formata(this, '§§:§§', event)" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <label class="control-label" for="txtNomeIndividuo">Nome Completo do Indivíduo</label>
                        <asp:TextBox ID="txtNomeIndividuo" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="cboUF">U.F.</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1" ID="cboUF" OnSelectedIndexChanged="cboUF_SelectedIndexChanged"
                                                                                                  AutoPostBack="true"
                                                                                                  DataTextField="DS"
                                                                                                  DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboCidade">Cidade</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1" ID="cboCidade"
                                                                                       DataTextField="DS"
                                                                                       DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtBairro">Bairro</label>
                        <asp:TextBox ID="txtBairro" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <label class="control-label" for="txtLogradouro">Logradouro</label>
                        <asp:TextBox ID="txtLogradouro" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <label class="control-label" for="txtDescricaoOcorrencia">Descrição da Ocorrência</label>
                        <asp:TextBox TextMode="MultiLine" ID="txtDescricaoOcorrencia" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-10">
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <asp:button id="cmdGravar" runat="server" text="Gravar" OnClick="cmdGravar_Click" style="vertical-align:bottom;" class="btn btn-lg btn-primary btn-block"></asp:button>
                    </div>
                </div>
            </div>
        </fieldset>
    </form>

    <script>
      $(document).ready(function () {
          $('txtDataNascimento').datepicker({
            format: "dd/mm/yyyy",
            language: "pt-BR"
        });
      });
    </script>
</asp:Content>

