<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagOcorrenciaListagem.aspx.cs" Inherits="PreCrime.pagOcorrenciaListagem" %>
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
                <div class="row" style="padding-top: 20px">
                    <div class="col-lg-8">
                    </div>
                    <div class="col-lg-2">
                        <asp:button id="cmdNovo" runat="server" text="Novo" style="vertical-align:bottom;" OnClick="cmdNovoItem_Click" class="btn btn-lg btn-primary btn-block"></asp:button>
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
                        <asp:BoundField DataField="ds_OrigemOcorrencia" HeaderText="Origem" ItemStyle-Width="80px" />
                        <asp:BoundField DataField="ds_ClassificacaoOcorrencia" HeaderText="Classificação" ItemStyle-Width="100px" />
                        <asp:BoundField DataField="ds_LocalOcorrencia" HeaderText="Logradouro" ItemStyle-Width="100px" />
                        <asp:BoundField DataField="no_BairroOcorrencia" HeaderText="Bairro" ItemStyle-Width="100px" />
                        <asp:BoundField DataField="dt_Registro" HeaderText="Data Registro" ItemStyle-Width="60px" />
                        <asp:BoundField DataField="dt_Ocorrencia" HeaderText="Data Ocorrência" ItemStyle-Width="60px" />
                        <asp:BoundField DataField="hr_Ocorrencia" HeaderText="Hora Ocorrência" ItemStyle-Width="20px" />
                        <asp:BoundField DataField="ds_Individuo" HeaderText="Nome Reduzido" ItemStyle-Width="250px" />
                        <asp:TemplateField HeaderText="Ação" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-success btn-xs" />
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