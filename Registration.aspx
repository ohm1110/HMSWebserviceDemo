<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td> <asp:Label ID="Label1" runat="server" Text="HotelName"></asp:Label></td>
             <td> <asp:TextBox ID="txtHotelName" runat="server"></asp:TextBox> </td>
        </tr>
          <tr>
            <td> <asp:Label ID="Label2" runat="server" Text="UserName"></asp:Label></td>
             <td> <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> </td>
        </tr>
          <tr>
            <td> <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label></td>
             <td> <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> </td>
        </tr>
          <tr>
            <td> <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick ="btnsubmit_Click" /></td>
             <td>  </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
