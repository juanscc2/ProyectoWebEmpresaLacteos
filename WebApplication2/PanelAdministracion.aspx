<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdministracion.aspx.cs" Inherits="WebApplication2.PanelAdministracion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
            <asp:Panel runat="server" ID="panelUsuarios">
                    <h1 runat="server" id="labelLista" visible="true">
                <center>Lista Usuarios</center>
                &nbsp;<h1></h1>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="AgregarBtn" runat="server" ImageUrl="~/Imagenes/btnAgregar.png" OnClick="AgregarBtn_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server">Cantidad</asp:TextBox>
                                    <asp:GridView ID="gvUsuarios" runat="server" CellPadding="4" Font-Names="Calibri" Font-Size="12pt" ForeColor="#333333" OnRowCommand="gvUsuarios_RowCommand" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </h1>
            
                </asp:Panel>
            <asp:Panel runat="server" ID="panelAgregarUser" Visible="false">                    
                    <table align="center">
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label runat="server" id="labelTitulo" Font-Bold="True" Font-Size="20pt"></asp:Label>
                            </td>                            
                        </tr>
                        <tr runat="server" visible="false" id="filaID">
                            <td>Id</td>
                            <td>
                                <asp:TextBox ID="TextBoxId" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:TextBox ID="TextBoxUsuario" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Apellido</td>
                            <td>
                                <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>User</td>
                            <td>
                                <asp:TextBox ID="TextBoxuser" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Password</td>
                            <td>
                                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Correo Electronico</td>
                            <td>
                                <asp:TextBox ID="TextBoxCorreo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Nombre Empresa</td>
                            <td>
                                <asp:TextBox ID="TextBoxEmpresa" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButtonGuardar" runat="server" ImageUrl="~/Imagenes/btnGuardar.png" OnClick="ImageButtonGuardar_Click" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButtonCancelar" runat="server" ImageUrl="~/Imagenes/btnCancelar.png" OnClick="ImageButtonCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </h1>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
