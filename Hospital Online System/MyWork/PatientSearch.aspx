<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientSearch.aspx.cs" Inherits="MyWork_PatientSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
        <span style="font-size: x-large">Patient Search</span></p>
    <p>
        Patient UserName:&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" style="color: #FF0000" Text="Patient not found. Try a different username." Visible="False"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>

