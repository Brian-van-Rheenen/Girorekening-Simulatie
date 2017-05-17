<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankRekeningen.aspx.cs" Inherits="SamengesteldObject.BankRekeningen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Gegevens uit de database halen en opslaan<br /></strong>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="LoadData" runat="server" OnClick="LoadData_Click" Text="Laad Data" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SaveData" runat="server" OnClick="SaveData_Click" Text="Save Data" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxMessage" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <strong><asp:Label ID="Label1" runat="server" Text="Nieuwe Rekening:"></asp:Label></strong>
        </div>
        <p style="margin-left: 40px">
        <asp:Label ID="Label2" runat="server" Text="naam rekeninghouder"></asp:Label>
        </p>
        <div style="margin-left: 40px">
            <asp:TextBox ID="rekeninghouder" runat="server"></asp:TextBox>
        </div>
        <p style="margin-left: 40px">
        <asp:Label ID="Label3" runat="server" Text="gironummer"></asp:Label>
        </p>
        <div style="margin-left: 40px">
            <asp:TextBox ID="gironummer" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonOpslaan" runat="server" Text="opslaan" OnClick="ButtonOpslaan_Click" Width="128px" />
        </div>
        <p>
            &nbsp;</p>
        <p>
        <strong><asp:Label ID="Label4" runat="server" Text="Overzicht bestaande rekeningen"></asp:Label></strong>
        </p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="rekeningenBox" runat="server" Height="172px" Width="232px" AutoPostBack="True" OnSelectedIndexChanged="rekeningenBox_SelectedIndexChanged"></asp:ListBox>
        <p>
        <strong>Overzicht rekening&nbsp;&nbsp;</strong>
        <p style="margin-left: 40px">
        <asp:Label ID="Label9" runat="server" Text="naam rekeninghouder"></asp:Label>
        </p>
        <div style="margin-left: 40px">
            <asp:TextBox ID="TextBoxNaam" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        <p style="margin-left: 40px">
        <asp:Label ID="Label10" runat="server" Text="gironummer"></asp:Label>
        </p>
        <div style="margin-left: 40px">
            <asp:TextBox ID="TextBoxNummer" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            saldo<br />
            <br />
            <asp:TextBox ID="TextBoxSaldo" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
        </div>
            <strong><asp:Label ID="Label5" runat="server" Text="Zoek Rekening op naam:"></asp:Label></strong>
        </p>
        <div style="margin-left: 40px">
            <asp:Label ID="Label6" runat="server" Text="naam/nummer rekeninghouder:"></asp:Label>
            <br />
        </div>
        <div style="margin-left: 40px">
            <asp:TextBox ID="naamRekeninghouder" runat="server" Width="178px"></asp:TextBox>
            <br />
            <br />
        </div>
        <div style="margin-left: 40px">
            <asp:Button ID="Zoek" runat="server" OnClick="Zoek_Click" Text="Zoek" Width="181px" />
            <br />
            <br />
        </div>
        <div style="margin-left: 40px">
            <asp:Label ID="Label7" runat="server" Text="resultaten:"></asp:Label>
            <br />
        </div>
        <div style="margin-left: 40px">
            <asp:ListBox ID="resultatenBox" runat="server" Height="147px" Width="186px"></asp:ListBox>
            <br />
        </div>
        <p>
            <strong>Storten - Opnemen - Overmaken</p></strong>
        <p style="margin-left: 40px">
            Bedrag</p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBoxBedrag" runat="server"></asp:TextBox>
            </p>
        <p style="margin-left: 40px">
            van Gironummer</p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBoxVanGironummer" runat="server"></asp:TextBox>
            </p>
        <p style="margin-left: 40px">
            naar Gironummer</p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBoxNaarGironummer" runat="server"></asp:TextBox>
            </p>
        <asp:Button ID="Stort" runat="server" Text="Stort" OnClick="Stort_Click"/>
&nbsp;
        <asp:Button ID="NeemOp" runat="server" Text="Neem Op" OnClick="NeemOp_Click"/>
&nbsp;
        <asp:Button ID="MaakOver" runat="server" Text="Maak Over" OnClick="MaakOver_Click"/>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Totaal in de kluis<br />
        <div style="margin-left: 40px">
            <asp:TextBox ID="TextBoxKluis" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        <br />
    </form>
</body>
</html>
