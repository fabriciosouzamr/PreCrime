<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagPesquisa.aspx.cs" Inherits="PreCrime.pagPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form class="form-horizontal" role="form" runat="server">
        <fieldset>
            <asp:HiddenField ID="txtTipoGravacao" runat="server" />
            <div class="form-group">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblNomePesquisa" runat="server" Font-Bold="true" Font-Size="Large">Pesquisa Genérica</asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 20px">
                    <div class="col-sm-12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true">Entrevistado: </asp:Label>
                        <asp:Label ID="lblEntrevistado" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta01">1- Falo as coisas como quero, mesmo que os outros se danem.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta01">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="1">Não</asp:ListItem>
                                <asp:ListItem Value="2">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="3">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta02">2- Fui infeliz em minha infância.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta02">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="4">Não</asp:ListItem>
                                <asp:ListItem Value="5">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="6">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta03" for="cboPergunta03" style="font-size: smaller;">3- Não controlo bem meus atos.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta03">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="7">Não</asp:ListItem>
                                <asp:ListItem Value="8">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="9">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta04" for="cboPergunta04" style="font-size: smaller;">4- Necessito de amor e atenção.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta04">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="10">Não</asp:ListItem>
                                <asp:ListItem Value="11">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="12">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta05" for="cboPergunta05" style="font-size: smaller;">5- Estou satisfeito comigo mesmo</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta05">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="13">Não</asp:ListItem>
                                <asp:ListItem Value="14">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="15">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta06" for="cboPergunta06" style="font-size: smaller;">6- Posso agredir fisicamente as pessoas quando fico muito irritado.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta06">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="16">Não</asp:ListItem>
                                <asp:ListItem Value="17">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="18">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta07" for="cboPergunta07" style="font-size: smaller;">7- Quase sempre me sinto desanimado.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta07">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="19">Não</asp:ListItem>
                                <asp:ListItem Value="20">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="21">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta08" for="cboPergunta08" style="font-size: smaller;">8- Acho que minha vida é vazia e sem emoção.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta08">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="22">Não</asp:ListItem>
                                <asp:ListItem Value="23">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="24">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta09" for="cboPergunta09" style="font-size: smaller;">9- Antes de agir, penso no que pode acontecer.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta09">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="25">Não</asp:ListItem>
                                <asp:ListItem Value="26">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="27">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta10" for="cboPergunta10" style="font-size: smaller;">10- Meu humor varia constantemente.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta10">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="28">Não</asp:ListItem>
                                <asp:ListItem Value="29">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="30">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta11" for="cboPergunta11" style="font-size: smaller;">11- Tenho muita dificuldade em tomar decisões em minha vida.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta11">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="31">Não</asp:ListItem>
                                <asp:ListItem Value="32">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="33">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta12" for="cboPergunta12" style="font-size: smaller;">12-Tenho muita dificuldade para dormir.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta12">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="34">Não</asp:ListItem>
                                <asp:ListItem Value="35">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="36">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta13" for="cboPergunta13" style="font-size: smaller;">13- Constantemente, tenho pesadelo.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta13">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="37">Não</asp:ListItem>
                                <asp:ListItem Value="38">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="39">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta14" for="cboPergunta14" style="font-size: smaller;">14- Sinto uma vontade de fugir de tudo.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta14">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="40">Não</asp:ListItem>
                                <asp:ListItem Value="41">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="42">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="input-group-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" class="control-label" id="lblPergunta15" for="cboPergunta15" style="font-size: smaller;">15- Tenho um bom relacionamento com minha família.</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" class="form-control col-sm-12" ID="cboPergunta15">
                                <asp:ListItem Value="0" Selected="True">Selecione resposta</asp:ListItem>
                                <asp:ListItem Value="43">Não</asp:ListItem>
                                <asp:ListItem Value="44">Quase sempre</asp:ListItem>
                                <asp:ListItem Value="45">Sim, muitas vezes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row text-right">
                <div class="col-sm-2">
                    <br />
                    <asp:button id="cmdGravar" runat="server" text="Gravar" OnClick="CmdGravar_Click" style="vertical-align:bottom;" class="btn btn-lg btn-primary btn-block"></asp:button>
                </div>
            </div>
        </fieldset>
    </form>
</asp:Content>