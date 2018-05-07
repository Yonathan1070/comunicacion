<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controlador/Usuario/Inicio.aspx.cs" Inherits="Vista_Usuario_Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Publicaciones | Fotos-UdeC</title>
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

    <script type="text/javascript">
        function uploadImage() {
            $('#linkSeleccionar').click()
        }
        function selectFile() {
            $('#FUImagen').click();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="navbar-header">
                <asp:Label ID="Label3" runat="server" class="navbar-brand">
                        <i class="fa fa-comments-o"></i>  Fotos-UdeC
                </asp:Label>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav navbar-right navbar-user">
                    <li class="dropdown user-dropdown">
                        <asp:LinkButton ID="linkUsername" runat="server" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-user-o"></i>
                            <asp:Label ID="lblUsername" runat="server"></asp:Label>
                            <asp:Label ID="lblDocumento" runat="server" Visible="false"></asp:Label>
                            <b class="caret"></b>
                        </asp:LinkButton>
                        <ul class="dropdown-menu">
                            <li>
                                <asp:LinkButton ID="linkPerfil" runat="server" OnClick="linkPerfil_Click">
                                    <i class="fa fa-user"></i>
                                    Perfil
                                </asp:LinkButton>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <asp:LinkButton ID="linkCerrarSesion" runat="server" OnClick="linkCerrarSesion_Click">
                                    <i class="fa fa-power-off"></i>
                                    Cerrar Sesión
                                </asp:LinkButton>
                            </li>

                        </ul>
                    </li>
                    <li class="divider-vertical"></li>
                </ul>
            </div>
        </nav>
        <div id="page-wrapper">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading"></div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="lblMensaje" runat="server" Visible="true"></asp:Label><br />
                                <i class="fa fa-plus-square-o"></i>
                                <asp:Label ID="Label1" runat="server" Text="Subir Imagen"></asp:Label>
                                <asp:FileUpload ID="FUImagen" onChange="uploadImage()" runat="server" class="hidden" />
                                <asp:TextBox ID="txtComentario" runat="server" CssClass="form-group form-control" Style="resize: none;" TextMode="MultiLine" placeholder="Realiza un Comentario..."></asp:TextBox>
                                <asp:LinkButton ID="linkSeleccionar" CssClass="btn btn-default" runat="server" OnClientClick="selectFile(); return false;">
                                    <i class="fa fa-image"></i>
                                </asp:LinkButton>
                                <asp:Button ID="btnPublicar" CssClass="btn btn-primary" runat="server" Text="Publicar" OnClick="btnPublicar_Click" />
                            </div>
                            <section id="no-more-tables">
                                <asp:DataList ID="DataList1" runat="server" DataSourceID="ODSFotos" OnItemCommand="DataList1_ItemCommand">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("id_foto") %>' Visible="False"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("nombres_persona") %>'></asp:Label>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("apellidos_persona") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("comentario_foto") %>'></asp:Label>
                                        <br />
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("dir_foto") %>' Width="100%" />
                                        <br />
                                        <br />
                                        <asp:DataList ID="DataList2" runat="server" DataSourceID="ODSComentarios">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("nombres_persona") %>'></asp:Label>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("apellidos_persona") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("comentario_a_foto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:ObjectDataSource ID="ODSComentarios" runat="server" SelectMethod="comentariosFoto" TypeName="DAOUsersConsultar">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="Label7" Name="user" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <br />
                                        <asp:TextBox ID="txtComentarioFoto" runat="server" Style="resize: none;" CssClass="form-control" TextMode="MultiLine" placeholder="Comentar..." CausesValidation="True"></asp:TextBox>
                                        <asp:LinkButton ID="linkComentarFoto" CssClass="btn btn-primary" CommandName="comentarFoto" CommandArgument='<% #Eval("id_foto") %>' runat="server">Comentar</asp:LinkButton>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:ObjectDataSource ID="ODSFotos" runat="server" SelectMethod="fotos" TypeName="DAOUsersConsultar"></asp:ObjectDataSource>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
