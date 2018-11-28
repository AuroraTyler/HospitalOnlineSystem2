<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="view_appointments_patient.aspx.cs" Inherits="Appointments_view_appointments" %>

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
        <asp:Label ID="selectedAppointmentLabel" runat="server" Text="No Appointment Currently Selected"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="deleteAppointmentButton" runat="server" OnClick="deleteAppointmentButton_Click" Text="Delete Appointment" />
    </p>
    <h2>
        Other Appointment Options</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Appointments/make_appointments.aspx">Create New Appointment</asp:HyperLink>
    </p>
    <p>
        <asp:HyperLink ID="editAppointment" runat="server" NavigateUrl="~/Appointments/edit_appointments.aspx">Edit Upcoming Appointment</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

