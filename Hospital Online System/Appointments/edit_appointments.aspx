<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="edit_appointments.aspx.cs" Inherits="Appointments_view_appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Appointments</h1>
    <h2>
        Upcoming appointments:</h2>
    <p>
        <asp:GridView ID="UpcomingAppointmentsGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="UpcomingAppointmentsGridView_SelectedIndexChanged" DataKeyNames="AppointmentId,DoctorId,PatientId">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="AppointmentDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Appointment Date" />
                <asp:BoundField DataField="AppointmentTime" HeaderText="Appointment Time" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
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
    </p>
    <p>
        &nbsp;</p>
    <h2>
        Selected appointment:</h2>
    <p>
        Date:&nbsp;
        <asp:Label ID="selectedAptDateLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:Calendar ID="appointmentDateCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
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
        <asp:Label ID="selectedAptTimeLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="hourDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem Value="9">9am</asp:ListItem>
            <asp:ListItem Value="10">10am</asp:ListItem>
            <asp:ListItem Value="11">11am</asp:ListItem>
            <asp:ListItem Value="12">12pm</asp:ListItem>
            <asp:ListItem Value="13">1pm</asp:ListItem>
            <asp:ListItem Value="14">2pm</asp:ListItem>
            <asp:ListItem Value="15">3pm</asp:ListItem>
            <asp:ListItem Value="16">4pm</asp:ListItem>
        </asp:DropDownList>
&nbsp;hour&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="minuteDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList>
&nbsp;minutes</p>
    <p>
        Location:&nbsp;
        <asp:Label ID="selectedAptLocationLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="hospitalDropDownList" runat="server" AutoPostBack="True" DataSourceID="HospitalTableSqlDataSource" DataTextField="Name" DataValueField="HospitalId" OnSelectedIndexChanged="hospitalDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="HospitalTableSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [HospitalTable]"></asp:SqlDataSource>
    </p>
    <p>
        Department:&nbsp;
        <asp:Label ID="selectedAptDepartmentLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="departmentDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        Doctor:&nbsp;
        <asp:Label ID="selectedAptDoctorLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="doctorDropDownList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        Reason:&nbsp;
        <asp:Label ID="selectedAptReasonLabel" runat="server" Text="--select appointment--"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="reasonTextBox" runat="server" Height="110px" Width="398px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="updateAppointmentButton" runat="server" OnClick="updateAppointmentButton_Click" Text="Update Appointment" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancelButton" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
    </p>
    <p>
        <asp:Label ID="confirmationLabel" runat="server" Text="."></asp:Label>
    </p>
    <p>
        <asp:Label ID="confirmationLabel2" runat="server" Text="."></asp:Label>
    </p>
    <h2>
        Other Appointment Options</h2>
    <p>
        <asp:HyperLink ID="makeAppointmentsHyperlink" runat="server" NavigateUrl="~/Appointments/make_appointments.aspx">Create New Appointment</asp:HyperLink>
    </p>
    <p>
        <asp:HyperLink ID="viewAppointments" runat="server" NavigateUrl="~/Appointments/appointments_redirect.aspx">View Upcoming Appointments</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

