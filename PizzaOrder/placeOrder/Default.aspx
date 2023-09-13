<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaOrder.placeOrder.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body class="bg-dark text-light py-5">
    <form id="form1" runat="server" class="border border-light rounded-1 mx-5 py-5">
        <div class="container">
            <div class="row gap-5">
                <div class="col-12 text-center">
                    <h1 class="text-danger">Pizzeria Dal Pirata</h1>
                    <h3 class="mt-3" id="title" runat="server"></h3>
                </div>
                <div class="col-12">
                    <asp:DropDownList CssClass="form-select" ID="PizzaSelectionList" runat="server">
                        <asp:ListItem Value="0" Text="Margherita"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Napoli"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Capricciosa"></asp:ListItem>
                        <asp:ListItem Value="3" Text="4 Formaggi"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Marinara"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Boscaiola"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-12 text-center">
                    <h3 class="text-center">Seleziona degli ingredienti extra...</h3>
                </div>
                <div class="col-12 border rounded-1 d-flex justify-content-center py-4">
                    <asp:CheckBoxList ID="IngredientBoxList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Text="Mozz. Bufala"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Funghi"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Salame Piccante"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Olive"></asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="col-12 d-flex justify-content-center gap-3">
                    <asp:Button ID="Button1" runat="server" Text="Aggiungi" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Conferma Ordine" CssClass="btn btn-success" OnClick="Button2_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-12 d-flex justify-content-center mt-3">

                    <div id="box1" runat="server" class="alert alert-primary w-75 " role="alert">
                        <h4>Attualmente nel tuo ordine:</h4>
                        <p id="current" runat="server"></p>
                    </div>
                    <div id="box2" runat="server" class="alert alert-info w-75" role="alert">
                        <h4>Ecco il totale:</h4>
                        <p id="total" runat="server"></p>
                        <p id="finalPrice" runat="server"></p>
                    </div>

                </div>
                <div class="col-12 text-center">
                    <asp:Button ID="Button3" runat="server" Text="Log-Out" CssClass="btn btn-outline-danger w-50" OnClick="Button3_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
