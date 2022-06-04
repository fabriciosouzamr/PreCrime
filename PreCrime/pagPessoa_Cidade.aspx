<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagPessoa_Cidade.aspx.cs" Inherits="PreCrime.pagPessoa_Cidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <Form runat="server">
        <div class="col-sm-9" style="padding-bottom: 15px">
            <label class="control-label" for="cboCidade">Usuário</label>
            <div class="row">
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="DropDownList1" Width="173px" DataTextField="DS" DataValueField="ID">
                        <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <hr />
        </div>
        <div>
            <div class="col-sm-9">
                <label class="control-label" for="cboUF">U.F.</label>
                <div class="row">
                    <div class="col-xs-4">
                        <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboUF" Width="173px" OnSelectedIndexChanged="cboUF_SelectedIndexChanged"
                                                                                                                    DataTextField="DS"
                                                                                                                    DataValueField="ID"
                                                                                                                    AutoPostBack="true">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-sm-9">
                <label class="control-label" for="cboCidade">Cidade</label>
                <div class="row">
                    <div class="col-xs-4">
                        <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboCidade" Width="173px" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-md-1">
                <asp:button id="cmdGravar" runat="server" class="btn btn-lg1 btn-primary btn-block" text="Gravar" OnClick="cmdGravar_Click"></asp:button>
                <asp:button id="cmdNovo" runat="server" class="btn btn-lg1 btn-primary btn-block" text="Novo" OnClick="cmdNovo_Click"></asp:button>
            </div>
        </div>
        <br /><br />
        <div class="row" runat="server" style="padding-top: 10px">
            <div class="table-responsive col-md-12" runat="server">
                <asp:GridView ID="grdItens"
                                class="table table-striped"
                                runat="server"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                OnPageIndexChanging="grdItens_PageIndexChanging"
                                Width="400px"
                                BorderWidth="0">
                    <Columns>        
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ControlStyle-Width="200px" />
                        <asp:TemplateField ControlStyle-Width="70px" HeaderText="Ação" ItemStyle-Width="170px">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar" OnClick="btnEditar_Click"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-warning btn-xs" />
                                <asp:Button ID="btnExcluir" runat="server" CommandName="Editar" Text="Excluir" OnClick="btnExcluir_Click"
                                    OnClientClick="return ConfirmarExclusao();"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-danger btn-xs" />
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