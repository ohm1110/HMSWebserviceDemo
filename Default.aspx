<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
            <td>
                 <asp:Label ID="Label1" runat="server" Text="USENAME"></asp:Label>
            </td>
                <td>
                    <asp:TextBox ID="txtuname" runat="server"></asp:TextBox>
                </td>
            </tr>
           <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="PASSWORD"></asp:Label>
            </td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick ="btnlogin_Click" />
                </td>
                <td>
 
                    <asp:Button ID="btnregister" runat="server" Text="Register now" OnClick ="btnregister_Click" />
                </td>
             
            </tr>
        </table>
       
    </div>
    </form>
</body>
</html>
