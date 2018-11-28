<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="MyWork_SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        <br />
        Send New Message</h3>
    <p>
        Patient Username:</p>
    <p>
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="DoctorUserName">
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Message Body:</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="92px" TextMode="MultiLine" Width="361px"></asp:TextBox>
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyWork/MessagesMain.aspx">Back</asp:HyperLink>
&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Send Message" OnClick="Button1_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HospitalDatabaseConnectionString %>" SelectCommand="SELECT * FROM [EmailTable]"></asp:SqlDataSource>
    </p>
</asp:Content>

