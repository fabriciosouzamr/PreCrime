<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="pagPesquisas.aspx.cs" Inherits="PreCrime.pagPesquisas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
                <div class="tabbable tabs-left">
              <ul class="nav nav-tabs">
                <li class="active"><a href="#lA" data-toggle="tab">Pesquisa Genérica</a></li>
                <li><a href="#lB" data-toggle="tab">Pesquisa 2</a></li>
                <li><a href="#lC" data-toggle="tab">Pesquisa 3</a></li>
              </ul>
              <div class="tab-content">
                <div class="tab-pane active" id="lA">
                  <p>Pesquisa Genérica</p>
                  <p>Nessa pesquisa teremos perguntas genéricas</p>
                  <a href="pagPesquisa.aspx">Ir para a pesquisa</a>
                </div>
                <div class="tab-pane" id="lB">
                  <p>Olá, Estou na seção B</p>
                </div>
                <div class="tab-pane" id="lC">
                  <p>E ai garota, estou na Seção C</p>
                </div>
              </div>
            </div> <!-- /tabbable -->
</asp:Content>
