<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagUsuario.aspx.cs" Inherits="PreCrime.pagUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /*
        FUNÇÃO DE FORMATAÇÃO DE CAMPO
        PARA CHAMÁ-LA, TEM-SE Q PASSAR 3 PARÂMETROS: CAMPO, MÁSCARA, EVENTO
        OS PARÂMETROS TÊM QUE SER PASSADOS ATRAVÉS DO EVENTO onKeyPress
    
        EX:  <input type="text" name="cep" id="telefone" onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)"> // formata o campo para cep
    
        O CARACTER '§' DEFINE QUE SÓ SERÁ PERMITIDO NÚMEROS
        O CARACTER '!' DEFINE QUE É PERMITIDO QUALQUER CARACTER
    
        OBS: COM ESSA FUNÇÃO, NÃO É NECESSÁRIO COLOCAR A PROPRIEDADE 'MAXLENGTH' NO CAMPO
    
        PRODUZIDO POR Tales<tales_augusto@hotmail.com>
        */
        function formata(campo, mask, evt) {

            if (document.all) { // Internet Explorer 
                key = evt.keyCode;
            }
            else { // Nestcape 
                key = evt.which;
            }

            string = campo.value;
            i = string.length;

            if (i < mask.length) {
                if (mask.charAt(i) == '§') {
                    return (key > 47 && key < 58);
                } else {
                    if (mask.charAt(i) == '!') { return true; }
                    for (c = i; c < mask.length; c++) {
                        if (mask.charAt(c) != '§' && mask.charAt(c) != '!')
                            campo.value = campo.value + mask.charAt(c);
                        else if (mask.charAt(c) == '!') {
                            return true;
                        } else {
                            return (key > 47 && key < 58);
                        }
                    }
                }
            } else return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <fieldset>
            <asp:HiddenField ID="txtTipoGravacao" runat="server" />
            <div class="form-group">
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Size="Large">Usuário</asp:Label>
                        <h5>C.P.F. + Nome</h5>
                        <asp:Label class="control-label" ID="lblEntrevistado" runat="server">750.221.335-04 Fabrício Souza Moreira</asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="txtCPF">C.P.F.</label>
                        <asp:TextBox ID="txtCPF" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtRG">R.G.</label>
                        <asp:TextBox ID="txtRG" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="col-sm-8">
                        <label class="control-label" for="txtNome">Nome Completo</label>
                        <asp:TextBox ID="txtNome" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <label class="control-label" for="txtLogradouro">Logradouro</label>
                        <asp:TextBox ID="txtLogradouro" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="txtBairro">Bairro</label>
                        <asp:TextBox ID="txtBairro" runat="server" AutoCompleteType="Disabled" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboUF">U.F.</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-2" ID="cboUF" OnSelectedIndexChanged="cboUF_SelectedIndexChanged"
                                                                                                                    DataTextField="DS"
                                                                                                                    DataValueField="ID"
                                                                                                                    AutoPostBack="true">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboCidade">Cidade</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-2" ID="cboCidade" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtCEP">C.E.P.</label>
                        <asp:TextBox ID="txtCEP" runat="server" class="form-control col-sm-2" AutoCompleteType="Disabled" OnKeyPress="return formata(this, '§§.§§§-§§§', event)"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <label class="control-label" for="txtLogradouro">Complemento Logradouro</label>
                        <asp:TextBox ID="txtLogradouroComplemento" class="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="txtTelefoneFixo">Telefone Fixo</label>
                        <asp:TextBox ID="txtTelefoneFixo" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtTelefoneCelular">Telefone Celular</label>
                        <asp:TextBox ID="txtTelefoneCelular" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtDataNascimento">Dt. Nascimento</label>
                        <asp:TextBox ID="txtDataNascimento" runat="server" class="form-control" OnKeyPress="return formata(this, '§§/§§/§§§§', event)"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboEstadoCivil">Estado Civil</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-2" ID="cboEstadoCivil" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboSexo">Sexo</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-2" ID="cboSexo" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboRaca">Raça</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-2" ID="cboRaca" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="cboGrauInstrucao">Grau de Instrução</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboGrauInstrucao" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="cboReligiao">Religião</label>
                        <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboReligiao" DataTextField="DS" DataValueField="ID">
                            <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-sm-2">
                        <label class="control-label" for="txtUsuario">Usuário</label>
                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label" for="txtSenha">Senha</label>
                        <asp:TextBox ID="txtSenha" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <asp:button id="cmdGravar" runat="server" text="Gravar" OnClick="CmdGravar_Click" class="btn btn-lg btn-primary btn-block"></asp:button>
                    </div>
                </div>
            </div>
        </fieldset>
    </form>

    <script>
      $(document).ready(function () {
        $('#exemplo').datepicker({
            format: "dd/mm/yyyy",
            language: "pt-BR"
        });
      });
    </script>
</asp:Content>
