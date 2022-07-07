<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="WebApplication2.Catalogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="pnCatalogo" runat="server">
            <div align="center">
                <h1>Catalogo de productos</h1>
            </div>

            <table style="width: 99%">
                <tr>
                    <td style="width: 50%">
                        <asp:GridView ID="gvProductos" runat="server" CellPadding="4" ForeColor="#333333" OnRowCommand="gvProductos_RowCommand" OnRowDataBound="gvProductos_RowDataBound" DataKeyNames="ProductoID" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:ButtonField ButtonType="Button" HeaderText="Agregar" Text="Seleccionar" CommandName="SeleccionarProducto" />
                                <asp:TemplateField HeaderText="Imagen Producto">
                                    <ItemTemplate>
                                        <asp:Image ID="ImagenProducto" runat="server" Height="120px" Width="120px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
                                <asp:BoundField DataField="StockProducto" HeaderText="Stock" />
                                <asp:BoundField DataField="PrecioProducto" DataFormatString="{0:N0}" HeaderText="Precio" />

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
                    <td valign="top" style="width: 50%">
                        <asp:Panel runat="server" ID="pnDetalleProducto" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <p><b>Detalle del producto seleccionado</b></p>
                                        <asp:Label ID="lblIdProducto" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Nombre:</b><asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" ID="imagenProducto" Width="300px" Height="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Stock:</b><asp:Label ID="lblStock" runat="server"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Precio:</b><asp:Label ID="lblPrecio" runat="server"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Ingrese la cantidad que desea agregar al carrito:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCantidad" Height="30px"></asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr style="border-top: 15px">
                                    <td>
                                        <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" BackColor="#3399FF" Font-Bold="True" Font-Size="20px" ForeColor="#000000" OnClick="btnAgregarCarrito_Click" />
                                    </td>
                                </tr>


                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <asp:Panel ID="pnItemsCarritoCompra" runat="server" Visible="false">
             <div align="center">
                <h1>Carrito de compra</h1>
            </div>
            <p>Estos son los productos que se han adicionado al carrito de compra</p>
            <asp:GridView ID="gvCarritoCompra" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ProductoID" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
                                <asp:BoundField DataField="StockProducto" HeaderText="Stock" />
                                <asp:BoundField DataField="PrecioProducto" DataFormatString="{0:N0}" HeaderText="Precio" />
                                <asp:BoundField DataField="CantidadSeleccionada" HeaderText="Cantidad Seleccionada" />

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
        </asp:Panel>
        <asp:Label ID="LabelPrueba" runat="server"></asp:Label>
    </form>
</body>
</html>
