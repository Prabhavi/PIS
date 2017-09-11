<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnlinePayments.aspx.cs" Inherits="PaymentInquiry.OnlinePayments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <asp:MultiView ID="OnlinePaymentsMultiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="OnlinePaymentsView" runat="server">
            <table class="auto-style1">
                <tr>
                    <td colspan="4" align="left" style="font-family: Calibri; font-size: 16pt; font-weight: bold; color: #87181D;">Online Payments</td>
                </tr>
                <tr>
                    <td width="20%" colspan="4" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;" class="auto-style1">&nbsp;</td>
                </tr>                
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Area</td>
                    <td width="80%" colspan="3">
                        <asp:DropDownList ID="cmbArea" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">From Date</td>
                    <td width="20%">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy" />
                    </td>
                    <td width="10%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">To Date</td>
                    <td width="50%">
                        <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Amount</td>
                    <td width="80%" colspan="3">
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Account Number</td>
                    <td width="80%" colspan="3">
                        <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Counter Number</td>
                    <td width="80%" colspan="3">
                        <asp:TextBox ID="txtCounterNum" runat="server" MaxLength="2" Style="text-transform: uppercase;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="20%" align="right" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Stub Number</td>
                    <td width="80%" colspan="3">
                        <asp:TextBox ID="txtStubNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:ImageButton ID="btnSearch" runat="server" CausesValidation="False" Font-Bold="True" ImageUrl="~/image/Search.jpg" OnClick="btnSearch__Click" TabIndex="2" />
                        &nbsp;<asp:ImageButton ID="btnClear" runat="server" CausesValidation="False" Font-Bold="True" ImageUrl="~/image/Clear.jpg" OnClick="btnClear_Click" TabIndex="2" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdSearchDetails" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" Width="100%" AllowSorting="True" OnSorting="grdSearchDetails_Sorting" OnSelectedIndexChanged="grdSearchDetails_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:CommandField>
                                <asp:BoundField DataField="acc_no" HeaderText="Account No" SortExpression="acc_no">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="count_no" HeaderText="Counter No" SortExpression="count_no">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="stub_no" HeaderText="Stub No" SortExpression="stub_no">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trans_amt" HeaderText="Amount" DataFormatString="{0:N2}" SortExpression="trans_amt">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="trans_date" HeaderText="Pay Date" SortExpression="trans_date" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pay_mode" HeaderText="Payment Mode" SortExpression="pay_mode">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="agent" HeaderText="Agent" SortExpression="agent">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="center" HeaderText="Center" SortExpression="center">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                
                            </Columns>
                            <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
