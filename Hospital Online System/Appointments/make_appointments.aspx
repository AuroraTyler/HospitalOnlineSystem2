<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="make_appointments.aspx.cs" Inherits="Appointments_make_appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Appointments</h1>
    <p>
        <asp:Calendar ID="dateSelectionCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
    </p>
    <p>
        Time:&nbsp;
        <asp:DropDownList ID="hourDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem Value="9">9 am</asp:ListItem>
            <asp:ListItem Value="10">10 am</asp:ListItem>
            <asp:ListItem Value="11">11 am</asp:ListItem>
            <asp:ListItem Value="12">12 pm</asp:ListItem>
            <asp:ListItem Value="13">1 pm</asp:ListItem>
            <asp:ListItem Value="14">2 pm</asp:ListItem>
            <asp:ListItem Value="15">3 pm</asp:ListItem>
            <asp:ListItem Value="16">4 pm</asp:ListItem>
        </asp:DropDownList>
&nbsp;hour
        <asp:DropDownList ID="minuteDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList>
&nbsp;minutes</p>
    <p>
        Location:
        <asp:DropDownList ID="hospitalDropDownList" runat="server" DataSourceID="SqlDataSource4" DataTextField="Name" DataValueField="HospitalId" OnSelectedIndexChanged="hospitalDropDownList_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [HospitalTable]"></asp:SqlDataSource>
    </p>
    <p>
        Department:
        <asp:DropDownList ID="departmentDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;</p>
    <p>
        Preferred Doctor:
        <asp:DropDownList ID="doctorDropDownList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        Reason for Appointment:
        <asp:TextBox ID="reasonTextBox" runat="server" Height="78px" Width="314px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="makeAppointmentButton" runat="server" OnClick="makeAppointmentButton_Click" Text="Make Appointment" />
    </p>
    <p>
        <asp:Label ID="confirmationLabel" runat="server" Text="."></asp:Label>
    </p>
<p>
        <asp:Label ID="confirmationLabel2" runat="server" Text="."></asp:Label>
    </p>
</asp:Content>

