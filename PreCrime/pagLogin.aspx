<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagLogin.aspx.cs" Inherits="PreCrime.pagLogin" %>
<!DOCTYPE html>
<html>
<head>
    <title>Sistema de Acesso</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="Content/Bootstrap v3.3.4.min.css" rel="stylesheet" />
    <link href="Content/signin.css" rel="stylesheet" />
    <link title="standard" href="Styles.css" type="text/css" rel="stylesheet">

    <style type="text/css">
        * { margin: 0; padding: 0; font-family:Tahoma; font-size:9pt;}
        #divCenter { 
                width: 300px; 
                height: 150px; 
                left: 50%; 
                margin: -130px 0 0 -210px; 
                padding:10px;
                position: absolute; 
                top: 50%; }
    </style>
</head>
<body>
    <div class="container">
        <form id="frmlogin" class="form-signin" method="post" runat="server">
            <h1 class="form-signin-heading text-center">Acesse</h1>
            <label for="inputEmail" class="control-label" style="font-size: medium">Usuário</label>
            <asp:textbox id="txtUsuario" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:textbox>
            <label for="inputEmail" style="font-size: medium; padding-top: 5px;">Senha</label>
            <asp:textbox id="txtSenha" class="form-control" runat="server" textmode="Password"></asp:textbox>
		 	<asp:button id="cmdSubmit" runat="server" class="btn btn-lg btn-primary btn-block" text="Acessar" OnClick="CmdSubmit_Click"></asp:button>
        </form>
        <asp:label id="lblMessage" runat="server" width="288px" forecolor="#C00000" font-size="Medium" font-italic="True" font-bold="True"></asp:label>
    </div>
</body>
</html>