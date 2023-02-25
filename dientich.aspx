<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dientich.aspx.cs" Inherits="dientich" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
@font-face {
  src: url(resource\font\vnitimes.ttf);
}
.content{font-family:VNI-Times,VNI-Helve}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>Chi tiết mía nhập</h3>

    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    ondatabound="GridView1_DataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:TemplateField HeaderText="STT">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="STT" />
            <asp:BoundField DataField="VuMia" HeaderText="Vụ mía" />
            <asp:BoundField DataField="Ma_cmia" HeaderText="Chủ mía" />
            <asp:BoundField DataField="Ma_vmia" HeaderText="Vùng mía" />
            <asp:BoundField DataField="SoHDong" HeaderText="Hợp đồng" />
            <asp:BoundField DataField="UserLog" HeaderText="UserLog" />
            <asp:BoundField DataField="DT_DoDac1" HeaderText="Diện tích đo đạt" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#FFF" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>