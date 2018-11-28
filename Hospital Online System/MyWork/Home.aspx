<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="MyWork_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>
        <span style="font-size: x-large"><strong>Welcome to the Hospital Online System!</strong></span></h1>
<p>
    <span style="font-size: large">
    <asp:Image ID="Image1" runat="server" Height="245px" ImageUrl="~/MyWork/clipart.png" Width="323px" />
    </span></p>
<h4><span style="font-size: large"><strong>Would you like to...&nbsp;</strong> </span></h4>
    <p>
        &nbsp; View or Edit:&nbsp;&nbsp;
    </p>
    <ul>
        <li class="text-left"><span style="font-size: medium">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyWork/Email.aspx">Messages</asp:HyperLink>
        </li>
        <li class="text-left"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Appointments/appointments_redirect.aspx">Appointments</asp:HyperLink>
            </span></li>
        <li>
            <p class="text-left" style="font-size: medium">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MyWork/UnderConstruction.aspx">Medical Records</asp:HyperLink>
            </p>
        </li>
    </ul>
    <p class="text-left" style="font-size: medium">
&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Or, You Can:" Visible="False"></asp:Label>
    </p>
    <p class="text-left" style="font-size: medium">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/MyWork/PatientSearch.aspx" Visible="False">•  Search for a Patient</asp:HyperLink>
    </p>
    <p class="text-left" style="font-size: medium">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Account/Register.aspx" Visible="False">•  Register a Patient</asp:HyperLink>
    </p>
<p class="text-left">
    &nbsp;</p>
    <p class="text-right">
        <span style="font-size: small">Click twice to&nbsp; </span> <asp:Button ID="Button1" runat="server" Text="Log Out" OnClick="Button1_Click" BackColor="#6699FF" BorderColor="#3333CC" BorderStyle="Ridge" ForeColor="White" style="font-size: small" />
</p>
</asp:Content>

