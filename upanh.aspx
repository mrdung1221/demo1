<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upanh.aspx.cs" Inherits="upanh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtEName" runat="server"></asp:TextBox>
        <asp:FileUpload ID="imgUpload" runat="server" />
        <asp:Image ID="Image1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </form>
</body>
</html>
