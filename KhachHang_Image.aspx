<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KhachHang_Image.aspx.cs" Inherits="KhachHang_Image" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.content{background-color: #e8f3ed;}
table{border-collapse: collapse;width:100%; }
table td{width: 33%;}
<%--table,th,td{border:1px solid black;}--%>
table th {font-size: 20px;}
.center {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 90%;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<table>
<tr>
<th>Ảnh thu hoạch</th>
<th>Ảnh bốc</th>
<th>Ảnh vận chuyển</th>
</tr>
<tr>
<td><asp:Image ID="imgTH" runat="server" CssClass="center" /></td>
<td><asp:Image ID="imgBoc" runat="server" CssClass="center" /></td>
<td><asp:Image ID="imgVC" runat="server" CssClass="center" /></td>
</tr>
</table>
</asp:Content>