<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsuarioGestiona.aspx.cs" Inherits="UsuarioGestiona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuario Gestiona</title>
    <style resource="/Content/Personal.css"></style>
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="/Content/Personal.css" />
</head>
<body">
    <form runat="server">
        <div class="cont">
            <asp:Label runat="server" Text="Nombre"/>
            <asp:TextBox ID="Nombre" runat="server" AutoPostBack="True"  />
            <br/>
            <asp:Label runat="server" Text="Fecha de nacimiento"/>
            <asp:Calendar ID="Fecha" runat="server" AutoPostBack="True"></asp:Calendar>
            <br/>
            <asp:Label runat="server" Text="Sexo"/>
            <asp:DropDownList ID="Sexo" runat="server" AutoPostBack="True">
                <asp:ListItem Text="Femenino" Value="F" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
            </asp:DropDownList>
            <br/>
            <asp:Button CssClass="button1" ID="Confirmar" runat="server" Text="Confirmar" OnClick="Confimar_Click" />
        </div>
    </form>


</body>
</html>
