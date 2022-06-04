<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagCadastroListagem.aspx.cs" Inherits="PreCrime.pagCadastroListagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <Form runat="server">
        <div id="top" class="row">
            <div class="col-md-3">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Ocorrências</asp:Label>
                <br />
            </div>
            <div class="col-md-2">
                <asp:button id="cmdNovoItem" runat="server" class="btn btn-lg btn-primary btn-block" text="Novo Item" OnClick="cmdNovoItem_Click"></asp:button>
            </div>
        </div>
        <div class="row" runat="server" style="padding-top: 10px">
            <div class="table-responsive col-md-12" runat="server">
                <asp:GridView ID="grdItens"
                                class="table table-striped"
                                runat="server"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                OnPageIndexChanging="grdItens_PageIndexChanging"
                                Width="500px"
                                BorderWidth="0">
                    <Columns>        
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                        <asp:TemplateField ItemStyle-Width="180px" HeaderText="Ação">
                            <ItemTemplate>
                                <asp:Button ID="btnVisualizar" runat="server" CommandName="Editar" Text="Visualizar" OnClick="btnVisualizar_Click"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' class="btn btn-success btn-xs" />
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

    <!--            <table class="table table-striped" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Header 1</th>
                            <th>Header 2</th>
                            <th>Header 3</th>
                            <th class="actions">Ações</th>
                            </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1001</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing</td>
                            <td>Jes</td>
                            <td>01/01/2015</td>
                            <td class="actions">
                                <a class="btn btn-success btn-xs" href="view.html">Visualizar</a>
                                <a class="btn btn-warning btn-xs" href="edit.html">Editar</a>
                                <a class="btn btn-danger btn-xs"  href="#" data-toggle="modal" data-target="#delete-modal">Excluir</a>
                            </td>
                        </tr>
                        <tr>
                            <td>1001</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing</td>
                            <td>Jes</td>
                            <td>01/01/2015</td>
                            <td class="actions">
                                <a class="btn btn-success btn-xs" href="view.html">Visualizar</a>
                                <a class="btn btn-warning btn-xs" href="edit.html">Editar</a>
                                <a class="btn btn-danger btn-xs"  href="#" data-toggle="modal" data-target="#delete-modal">Excluir</a>
                            </td>
                        </tr>
                        <tr>
                            <td>1001</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing</td>
                            <td>Jes</td>
                            <td>01/01/2015</td>
                            <td class="actions">
                                <a class="btn btn-success btn-xs" href="view.html">Visualizar</a>
                                <a class="btn btn-warning btn-xs" href="edit.html">Editar</a>
                                <a class="btn btn-danger btn-xs"  href="#" data-toggle="modal" data-target="#delete-modal">Excluir</a>
                            </td>
                        </tr>
                    </tbody>
                    </table>    -->
            </div>
        </div>
        <!-- 
        <div id="bottom" class="row">
            <div class="col-md-12">
                <ul class="pagination">
                    <li class="disabled"><a>&lt; Anterior</a></li>
                    <li class="disabled"><a>1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li class="next"><a href="#" rel="next">Próximo &gt;</a></li>
                </ul>
            </div>
        </div>-->
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
