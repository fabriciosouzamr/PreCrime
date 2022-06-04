﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagPessoaListagem.aspx.cs" Inherits="PreCrime.pagPessoaListagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <fieldset>
            <asp:HiddenField ID="txtTipoGravacao" runat="server" />
            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Listagem de Pessoa</asp:Label>
                        <br />
                    </div>
                </div>
                <div class="row">
                  <div class="col-lg-2">
                    <label class="control-label" for="txtCodigoUnico">C.P.F.</label>
                    <asp:TextBox ID="txtCPF" runat="server" AutoCompleteType="Disabled" class="form-control"
                                                                                        OnKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)"
                                                                                        AutoPostBack="true"></asp:TextBox>
                  </div>
                  <div class="col-lg-2">
                    <label class="control-label" for="txtRG">R.G.</label>
                    <asp:TextBox ID="txtRG" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                  </div>
                  <div class="col-lg-8">
                    <label class="control-label" for="txtNome">Nome Completo</label>
                    <asp:TextBox ID="txtNome" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                  </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <label class="control-label" for="txtApelido">Apelido</label>
                        <asp:TextBox ID="txtApelido" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <label class="control-label" for="txtMae">Mãe</label>
                        <asp:TextBox ID="txtMae" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboUF">U.F.</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-1" ID="cboUF" OnSelectedIndexChanged="cboUF_SelectedIndexChanged"
                                                                                                                    DataTextField="DS"
                                                                                                                    DataValueField="ID"
                                                                                                                    AutoPostBack="true">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboCidade">Cidade</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-1" ID="cboCidade" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2">
                        <label class="control-label" for="txtBairro">Bairro</label>
                        <asp:TextBox ID="txtBairro" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboOcupacao">Ocupação</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-2" ID="cboOcupacao" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="txtDataNascimento">Dt. Nascimento</label>
                        <asp:TextBox ID="txtDataNascimento" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboEstadoCivil">Estado Civil</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-2" ID="cboEstadoCivil" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboSexo">Sexo</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-2" ID="cboSexo" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label class="control-label" for="cboRaca">Raça</label>
                        <asp:DropDownList runat="server" class="form-control col-lg-2" ID="cboRaca" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="padding-top: 20px">
                    <div class="col-lg-8">
                    </div>
                    <div class="col-lg-2">
                        <asp:button id="cmdNovo" runat="server" text="Novo" style="vertical-align:bottom;" OnClick="cmdNovo_Click" class="btn btn-lg btn-primary btn-block"></asp:button>
                    </div>
                    <div class="col-lg-2">
                        <asp:button id="cmdPesquisar" runat="server" text="Pesquisar" style="vertical-align:bottom;" OnClick="cmdPesquisar_Click" class="btn btn-lg btn-primary btn-block"></asp:button>
                    </div>
                </div>
            </div>
        </fieldset>
        <div class="row" runat="server" style="padding-top: 10px">
            <div class="table-responsive col-md-12" runat="server">
                <asp:GridView ID="grdItens"
                                class="table table-striped"
                                runat="server"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                OnPageIndexChanging="grdItens_PageIndexChanging"
                                BorderWidth="0">
                    <Columns>
                        <asp:BoundField DataField="cd_cpfcnpj" HeaderText="C.P.F." ItemStyle-Width="80px" />
                        <asp:BoundField DataField="no_pessoa" HeaderText="Nome da Pessoa" ItemStyle-Width="250px" />
                        <asp:BoundField DataField="no_mae" HeaderText="Nome da Pessoa" ItemStyle-Width="250px" />
                        <asp:BoundField DataField="no_reduzido" HeaderText="Apelido/Nome Reduzido" ItemStyle-Width="250px" />
                        <asp:BoundField DataField="dt_cadastro" HeaderText="Data" ItemStyle-Width="50px" />
                        <asp:TemplateField HeaderText="Ação" ItemStyle-Width="190px">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-success btn-xs" />
                                <asp:Button ID="btnOcorrencias" runat="server" CommandName="Ocorrências" Text="Ocorrências" OnClick="btnOcorrencias_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-success btn-xs" />
                                <asp:Button ID="btnEntrevistas" runat="server" CommandName="Entrevitas" Text="Entrevistas" OnClick="btnEntrevistas_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-success btn-xs" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="Smaller" />
                    <PagerStyle Font-Size="Smaller" />
                    <RowStyle Font-Size="Smaller" />
                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                                    PreviousPageText="<img src='img/seta-esquerda.png' border='0' title='Página Anterior'/>"
                                    NextPageText="<img src='img/seta-direita.png' border='0' title='Próxima Página'/>"
                                    FirstPageText="<img src='img/seta-esquerda-ultima.png' border='0' title='Primeira Página'/>"
                                    LastPageText="<img src='img/seta-direita-ultima.png' border='0' title='Última Página'/>" PageButtonCount="15" />
                </asp:GridView>
            </div>
        </div>
    </Form>

    <script type="text/javascript">    
       function ConfirmarExclusao() {
        if (confirm("Voçê quer realmente excluir?") == true)
            return true;
        else
            return false;
       }
    </script>
</asp:Content>