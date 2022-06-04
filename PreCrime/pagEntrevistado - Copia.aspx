<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagEntrevistado.aspx.cs" Inherits="PreCrime.pagEntrevistado" %>
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
<!--
Telefone: <input type="text" name="telefone" id="telefone" onKeyPress="return formata(this, '(0§§) §§§§-!§§§', event)"><br>
CPF: <input type="text" name="telefone" id="telefone" onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)"><br>
Data: <input type="text" name="telefone" id="telefone" onKeyPress="return formata(this, '§§/§§/§§§§', event)"><br>
-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div class="well">
        <h3 id="panels">Entrevistado</h3>

        <div class="rowx">
            <div>
                <form class="form-horizontal" role="form" runat="server">
                    <fieldset>
                        <asp:HiddenField ID="txtTipoGravacao" runat="server" />
                        <div class="form-groupx">
                            <table style="width: 100%">
                                <tr><td style="padding-bottom: 30px">
                                <h5>Código + Nome</h5>
                                <asp:Label class="control-label" ID="lblEntrevistado" runat="server">750.221.335-04 Fabrício Souza Moreira</asp:Label>
                                </td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtCodigoUnico">Código Unico</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtCodigoUnico" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                </td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtRG">R.G.</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtRG" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                </td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtNome">Nome Completo</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtNome" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtApelido">Apelido</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtApelido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
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
                                </div></td></tr><tr><td>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboCidade">Cidade</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboCidade" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtLogradouro">Logradouro</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtLogradouro" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtBairro">Bairro</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtBairro" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtCEP">C.E.P.</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtCEP" runat="server" AutoCompleteType="Disabled" OnKeyPress="return formata(this, '§§.§§§-§§§', event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtLogradouro">Complemento Logradouro</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtLogradouroComplemento" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtTelefone">Telefone</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtDataNascimento">Dt. Nascimento</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtDataNascimento" runat="server" OnKeyPress="return formata(this, '§§/§§/§§§§', event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboEstadoCivil">Estado Civil</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboEstadoCivil" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboSexo">Sexo</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboSexo" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboRaca">Raça</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboRaca" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboGrauInstrucao">Grau de Instrução</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboGrauInstrucao" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboReligiao">Religião</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboReligiao" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="cboOcupacao">Ocupação</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:DropDownList runat="server" class="form-control col-sm-1x" ID="cboOcupacao" Width="173px" DataTextField="DS" DataValueField="ID">
                                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr><td>
                                <div class="col-sm-9">
                                    <label class="control-label" for="txtLocalOupacao">Local de Ocupação</label>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="txtLocalOupacao" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div></td></tr>
                                <tr style="text-align: right"><td>
                                    <div style="padding-top: 30px; ">
                                        <asp:button id="cmdGravar" CssClass="btn" runat="server" borderstyle="Solid" text="Gravar" OnClick="CmdGravar_Click"></asp:button>
                                    </div>
                                </td></tr>
                            </table>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>

    <script>
      $(document).ready(function () {
        $('#exemplo').datepicker({
            format: "dd/mm/yyyy",
            language: "pt-BR"
        });
      });
    </script>
</asp:Content>
