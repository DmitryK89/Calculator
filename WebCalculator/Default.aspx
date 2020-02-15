<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Font-Strikeout="False" Text="Web Calculator"></asp:Label>
        </div>
        <p style="width: 1103px">
            Введите выражение:
            <asp:TextBox ID="TextBoxInput" runat="server" OnTextChanged="TextBox1_TextChanged" Width="489px"></asp:TextBox>
        </p>
        <p>
&nbsp;Результат:&nbsp;
            <asp:TextBox ID="TextBoxResult" runat="server" ReadOnly="True" Width="551px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="ButtonCalc" runat="server" Text="Calculate" OnClick="ButtonCalc_Click" />
        </p>
        <p>
            <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset" />
        </p>
    </form>
</body>
</html>
