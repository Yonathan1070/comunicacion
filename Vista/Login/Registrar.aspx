<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controlador/Login/Registrar.aspx.cs" Inherits="Vista_Login_Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Registrar | Fotos-UdeC</title>
    <link rel="icon" type="image/png" href="../../Estilo/Imagenes/favicon.ico" />

    <link href="../../Estilo/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Estilo/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Estilo/css/local.css" rel="stylesheet" />

    <script src="../../Estilo/js/jquery-1.10.2.min.js"></script>
    <script src="../../Estilo/bootstrap/js/bootstrap.min.js"></script>

    <!-- you need to include the shieldui css and js assets in order for the charts to work -->
    <link rel="stylesheet" type="text/css" href="http://www.shieldui.com/shared/components/latest/css/light-bootstrap/all.min.css" />
    <link id="gridcss" rel="stylesheet" type="text/css" href="http://www.shieldui.com/shared/components/latest/css/dark-bootstrap/all.min.css" />

    <script type="text/javascript" src="http://www.shieldui.com/shared/components/latest/js/shieldui-all.min.js"></script>
    <script type="text/javascript" src="http://www.prepbootstrap.com/Content/js/gridData.js"></script>
</head>
<body>
    <div id="wrapper">
        <form id="form1" runat="server">
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="navbar-header">
                    <asp:Label ID="Label3" runat="server" class="navbar-brand">
                        <i class="fa fa-comments-o"></i>  Fotos-UdeC
                    </asp:Label>
                </div>
            </nav>

            <div id="page-wrapper">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-expeditedssl"></i>  Registrar Usuario Fotos-UdeC</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group text-center">
                                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-center" Text="Campos Obligatorios (*)" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Documento"></asp:Label>
                                    <asp:TextBox ID="txtDocumento" runat="server" class="form-control" placeholder="* Documento"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Nombres"></asp:Label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="* Nombres"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Apellidos"></asp:Label>
                                    <asp:TextBox ID="txtApellido" runat="server" class="form-control" placeholder="* Apellidos"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario"></asp:Label>
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="* Nombre de Usuario"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                                    <asp:TextBox ID="txtClave" runat="server" class="form-control" TextMode="Password" placeholder="* Contraseña"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnEntrar" runat="server" class="btn btn-primary" Text="Registrar" OnClick="btnEntrar_Click" /><br />
                                    ¿Ya Estas Registrado? Entra <asp:LinkButton ID="linkLogin" runat="server" OnClick="linkLogin_Click">Aquí</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
