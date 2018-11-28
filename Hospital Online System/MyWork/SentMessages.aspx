<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SentMessages.aspx.cs" Inherits="MyWork_SentMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Sent Messages</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="459px" DataKeyNames="EmailText,EmailId">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="RecipientUserName" HeaderText="Sent To" />
            <asp:BoundField DataField="EmailDate" DataFormatString="{0:f}" HeaderText="Date &amp; Time" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:TextBox ID="TextBox1" runat="server" Height="120px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="459px"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Please Select Message to View" Visible="False"></asp:Label>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyWork/MessagesMain.aspx">Back to Inbox</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="View Message" />
    </p>
</asp:Content>

