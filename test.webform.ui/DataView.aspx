<%@ Page Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="test.webform.ui.DataView" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>DataView</h1>
        <p class="lead">This is a test dataview page.</p>
        <p><asp:ListBox ID="ListBox1" runat="server"></asp:ListBox></p>
    </div>

</asp:Content>
