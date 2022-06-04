<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagCadastro.aspx.cs" Inherits="PreCrime.pagCadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- Modal -->
    <div class="modal fade" id="delete-modal" tabindex="-1" role="dialog" aria-labelledby="modalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Fechar"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="modalLabel">Excluir Item</h4>
          </div>
          <div class="modal-body">
            Deseja realmente excluir este item?
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-primary">Sim</button>
            <button type="button" class="btn btn-default" data-dismiss="modal">Não</button>
          </div>
        </div>
      </div>
    </div> <!-- /.modal -->

    <form class="form-horizontal" role="form" runat="server" id="frmCadastro">
        <fieldset>
            <div class="form-group">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Novo Item</asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="false">Nome</asp:Label><br />
                        <asp:TextBox class="form-control disabled" ID="txtNomeCadastro" runat="server" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Button class="btn btn-primary" ID="cmdSalvar" Text="Salvar" runat="server" OnClick="cmdSalvar_Click" />
                        <asp:Button class="btn btn-default" ID="cmdCancelar" Text="Cancelar" runat="server" OnClick="cmdCancelar_Click" />
                        <asp:Button class="btn btn-primary" ID="cmdVoltar" Text="Voltar" runat="server" OnClick="cmdVoltar_Click" />
                        <asp:Button class="btn btn-default" ID="cmdEditar" Text="Editar" runat="server" OnClick="cmdEditar_Click" />
                        <asp:Button class="btn btn-default" ID="cmdExcluir" Text="Excluir" runat="server" OnClick="cmdExcluir_Click" />
                    </div>
                </div>
            </div>
        </fieldset>
    </form>
</asp:Content>
