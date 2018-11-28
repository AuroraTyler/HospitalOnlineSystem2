<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MessagesMain.aspx.cs" Inherits="MyWork_MessagesMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <h2>
        <span style="font-size: x-large">Message Inbox
        <asp:Image ID="Image1" runat="server" Height="53px" ImageUrl="~/MyWork/email.gif" Width="53px" />
        </span>
    </h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MyWork/SendMessage.aspx">Create New Message</asp:HyperLink>
        &nbsp;&nbsp;&nbsp; &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MyWork/SentMessages.aspx">View Sent Messages</asp:HyperLink>
    </p>

<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="459px" DataKeyNames="EmailText,EmailId">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="SenderUserName" HeaderText="From" />
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
    &nbsp;&nbsp;
    </p>
    <p>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="View Message" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp; 
        <asp:Button ID="Button2" runat="server" Text="Delete Message" OnClick="Button2_Click1" />
    </p>
<p>
    &nbsp;</p>
<p>
</p>
</asp:Content>

