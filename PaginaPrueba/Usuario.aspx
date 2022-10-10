<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Usuario.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link id="Link1" rel="stylesheet" runat="server" media="screen" href="/Content/Personal.css" />

    <div>
        <asp:Button CssClass="button1" ID="Adicionar" runat="server" Text="Adicionar" OnClick="Adicionar_Click"/>
        <asp:Button CssClass="button2" ID="Modificar" runat="server" Text="Modificar" OnClick="Modificar_Click"/>
        <asp:Button CssClass="button3" ID="Eliminar" runat="server" Text="Eliminar" OnClick="Eliminar_Click"/>
        <asp:Button CssClass="button5" ID="Descargar" runat="server" Text="Descargar" OnClick="Descargar_Click"/>
    <br />
            <asp:DataGrid ID="Grid" runat="server" PageSize="10" AllowPaging="True" DataKeyField="id" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Width="100%" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
                <Columns>
                    <asp:BoundColumn HeaderText="NOMBRE" DataField="nombre" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="50" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="50"> </asp:BoundColumn>  
                    <asp:BoundColumn HeaderText="FECHA DE NACIMIENTO" DataField="fecha" DataFormatString="{0:dd/MM/yyyy}"> </asp:BoundColumn>  
                    <asp:BoundColumn HeaderText="SEXO" DataField="sexo"> </asp:BoundColumn>
                    <asp:ButtonColumn HeaderText="SELECCIONAR" ButtonType="PushButton" Text="Seleccionar" CommandName="Select"/>
                </Columns>
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="50" />
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Height="50"/>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="25"/>  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" Font-Size="Large"/>
                    <AlternatingItemStyle BackColor="White" />
            </asp:DataGrid>
        <asp:label ID="Pagina" runat="server" >Página 1</asp:label>
    </div>
    <div id="sMensaje" runat="server" style="height:50px;background:DarkGrey;border-radius: 10px;text-align:center;"><asp:label ID="lblMensaje" runat="server" ForeColor="White" Font-Size="Large">Mensaje</asp:label></div>
        

</asp:Content>
