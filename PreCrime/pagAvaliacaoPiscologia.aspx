<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagAvaliacaoPiscologia.aspx.cs" Inherits="PreCrime.pagAvaliacaoPiscologia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Avaliação Psicológicas</asp:Label>
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblPessoa" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                    <br />
                </div>
            </div>
            <div class="col-lg-4">
                <label class="control-label" for="cboStatus">Status</label>
                <asp:DropDownList runat="server" class="form-control col-lg-2" ID="cboStatus" DataTextField="DS" DataValueField="ID">
                    <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-12">
                <label class="control-label" for="txtComentario">Comentário</label><br />
                <asp:TextBox ID="txtComentario" TextMode="MultiLine" runat="server" Rows="10" CssClass="form-control col-lg-12"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col-sm-10">
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:button id="cmdGravar" runat="server" text="Gravar" OnClick="cmdGravar_Click" style="vertical-align:bottom;" class="btn btn-lg btn-primary btn-block"></asp:button>
                </div>
            </div>
            <div class="col-lg-12">
                <asp:Label runat="server" class="control-label" ID="lblStatus"></asp:Label>
            </div>
        </div>
    </form>
</asp:Content>