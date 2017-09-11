<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendToledger.aspx.cs" Inherits="PaymentInquiry.SendToledger" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="auto-style1">
        <tr>
            <td colspan="4" align="center" style="font-family: Calibri; font-size: 16pt; font-weight: bold; color: #87181D;">Payment Corrections</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="left" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Complained Payment Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grdSearchDetailsC" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AccNo" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AreaCode" HeaderText="Area" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CounterNo" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StubNo" HeaderText="Stub No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayDate" HeaderText="Pay Date" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TransactionCode" HeaderText="Transacton Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
                <asp:GridView ID="grdSearchDetailsP" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AccNo" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AreaCode" HeaderText="Area" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CounterNo" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StubNo" HeaderText="Stub No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Pay Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TransactionCode" HeaderText="Transacton Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
                <asp:GridView ID="grdSearchDetailsOff" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AccNo" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CounterNo" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StubNo" HeaderText="Stub No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayDate" HeaderText="Pay Date" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayMode" HeaderText="Payment Mode" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Agent" HeaderText="Agent" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center" HeaderText="Center" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
                <asp:GridView ID="grdSearchDetailsOn" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AccNo" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CounterNo" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StubNo" HeaderText="Stub No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Pay Date">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PayMode" HeaderText="Payment Mode">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="agent" HeaderText="Agent">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="center" HeaderText="Center">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td width ="25%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Reference No</td>
            <td width ="20%">
                <asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox></td>
            <td width ="15%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Set off Account</td>
            <td>
                <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                <asp:Label ID="lblHidden" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width ="25%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Comment</td>
            <td width ="20%">
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td width ="15%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Journal No</td>
            <td>
                <asp:TextBox ID="txtJnlNo" runat="server"></asp:TextBox>
                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width ="25%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Journal Type</td>
            <td width ="20%">
                <asp:DropDownList ID="cmbJourneleTy" runat="server">
                    <asp:ListItem>-SELECT-</asp:ListItem>
                    <asp:ListItem>Adjustment-A to A</asp:ListItem>
                    <asp:ListItem>Adjustment- S to A</asp:ListItem>
                    <asp:ListItem>Refund Active</asp:ListItem>
                    <asp:ListItem>Refund Suspense</asp:ListItem>
                </asp:DropDownList></td>
            <td width ="15%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Journal Date</td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:ImageButton ID="btnEnter" runat="server" CausesValidation="False" Font-Bold="True" ImageUrl="~/image/Enter.jpg" OnClick="btnEnter__Click" TabIndex="2" Visible="False" />
                <asp:ImageButton ID="btnCheck" runat="server" CausesValidation="False" Font-Bold="True" ImageUrl="~/image/Check.jpg" OnClick="btnCheck__Click" TabIndex="2" Visible="False" />
                <asp:ImageButton ID="btnApprove" runat="server" CausesValidation="False" Font-Bold="True" ImageUrl="~/image/Approve.jpg" OnClick="btnApprove__Click" TabIndex="2" Visible="False" />
                <asp:Label ID="lblErrMessage" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="14pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Settled Payment Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grdSearchFromCorrection" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%" DataKeyNames="id,status1" OnSelectedIndexChanged="grdSearchFromCorrection_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:CommandField>
                        <asp:BoundField DataField="acct_number" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="counter_num" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="stub_num" HeaderText="Stub No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="amount" HeaderText="Amount" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paydate" DataFormatString="{0:MM-dd-yyyy}" HeaderText="Pay Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paymode" HeaderText="Payment Mode" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="agent" HeaderText="Agent" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="center" HeaderText="Center" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="area_code" HeaderText="Area Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tans_code" HeaderText="Transaction Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="comment" HeaderText="Comment" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ref_no" HeaderText="Reference No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_no" HeaderText="Journal No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_type" HeaderText="Journal Type" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Journal Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="set_off_to" HeaderText="Set off Acc" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="status1" HeaderText="Status" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="False" ForeColor="#87181D" Font-Names="Calibri" Font-Size=" 14pt"></asp:Label>
               
            </td>

        </tr>
        <tr>
            <td colspan="4" align="center"> <asp:Label ID="lblMessage0" runat="server" Text="Status A - Approved C - Checked E - Entered" ForeColor="#87181D" Font-Names="Calibri" Font-Size="14pt"></asp:Label></td>
        </tr>
    </table>

</asp:Content>
