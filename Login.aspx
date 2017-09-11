<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PaymentInquiry.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function CloseWindow() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Login ID="LoginU" runat="server" BackColor="#B75432" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="Medium" ForeColor="#ffffff" Height="132px" OnAuthenticate="LoginU_Authenticate" Width="300px">
                <InstructionTextStyle Font-Italic="True" ForeColor="#87181D" />
                <LoginButtonStyle BackColor="#87181D" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#ffffff" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#87181D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>

        </div>
    </form>
</body>
</html>
