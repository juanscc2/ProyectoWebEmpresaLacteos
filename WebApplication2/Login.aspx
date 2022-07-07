<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Empresa Lacteos</title>
    <style type="text/css">
        .style5
        {
            height: 26px;
        }
        .style6
        {
            width: 128px;
            height: 90px;
        }
        .style7
        {
            width: 289px;
            height: 11px;
        }
        .auto-style1 {
            height: 33px;
        }
    </style>
</head>
<body style="font-family: Calibri;">
    <table align="center" style="width: 40%;">
        <tr>
            <td align="center">
                <form id="hfrmLogin" runat="server">
                <fieldset>
                    <legend>Empresa Lacteos AntiPlanos S.A.S</legend>
                    <table align="left" style="width: 100%">
                        <tr>
                            <td align="left" rowspan="4">
                                <img alt="" class="style6" src="Imagenes/Recurso%203@4x.png" />
                            </td>
                            <td align="left">
                                <b>Usuario</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <b>Contraseña</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style5">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="left">
                                    <asp:Button ID="btnIngresar" runat="server" Text="Login" Font-Bold="True" OnClick="btnIngresar_Click" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:TextBox ID="txtCnt" runat="server" TabIndex="4" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"
                                    ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblLogin" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"
                                    ForeColor="Red" Visible="False"></asp:Label>
                                <asp:Label ID="lblTipoFecha" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"
                                    ForeColor="Red" Visible="False"></asp:Label>
                                <br />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="auto-style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
                </form>
            </td>
        </tr>
    </table>
</body>
</html>
