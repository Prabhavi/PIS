<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetCheck.aspx.cs" Inherits="PaymentInquiry.GetCheck" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
      <table class="auto-style1">
        <tr>
            <td colspan="4" align="left" style="font-family: Calibri; font-size: 12pt; font-weight: bold; color: #87181D;">Complained Payment Details
             
                   </td>
        </tr>
   
        <tr>
           
            <td colspan="4">
                <asp:GridView ID="getcheck" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="11pt" ForeColor="#87181D" DataKeyNames="id,status1"  Width="150%" >
                    <Columns>
                      
                        <asp:BoundField DataField="acct_number" HeaderText="Account No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="counter_num" HeaderText="Counter No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="stub_num" HeaderText="Stub No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="amount" DataFormatString="{0:C2}" HeaderText="Amount" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paydate" DataFormatString="{0:MM-dd-yyyy}" HeaderText="Pay Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paymode" HeaderText="Payment Mode" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="agent" HeaderText="Agent" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="center" HeaderText="Center" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="area_code" HeaderText="Area Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tans_code" HeaderText="Transaction Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="comment" HeaderText="Comment" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ref_no" HeaderText="Reference No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_no" HeaderText="Journal No" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_type" HeaderText="Journal Type" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="jnl_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Journal Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="set_off_to" HeaderText="Set off Acc" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="status1" HeaderText="Status" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                <asp:ImageButton ShowSelectButton="True" ID="Button2" runat="server" ImageUrl="~/image/correct.png" CommandArgument='<%# Eval("id") %>' OnClick="btnTick_Click" OnClientClick="return confirm('Are you sure?');" CausesValidation="false" />
                             </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/image/undo.png" CommandArgument='<%# Eval("id") %>' OnClick="btnDisagree_Click" OnClientClick="return confirm('Are you sure?');"   CausesValidation="false" />
                             </ItemTemplate>
                       </asp:TemplateField>
                                          
                        
                    </Columns>
                    <HeaderStyle BackColor="#87181D" BorderColor="" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FFFFFF" />
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="False" ForeColor="#87181D" Font-Names="Calibri" Font-Size=" 14pt"></asp:Label>
               
            </td>
            
        </tr>
          <!--
        <tr>
            <td colspan="4" align="center"> <asp:Label ID="lblMessage0" runat="server" Text="Status A - Approved C - Checked E - Entered" ForeColor="#87181D" Font-Names="Calibri" Font-Size="14pt"></asp:Label></td>
        </tr>
              !-->
    </table>

</asp:Content>
