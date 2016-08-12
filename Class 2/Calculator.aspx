<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td colspan="2">
                <asp:TextBox ID="SubtotalTextBox" runat="server" ReadOnly="True">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="DisplayTextBox" runat="server">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table align="left">
                    <tr>
                        <td>
                            <asp:Button ID="Button2" runat="server" OnClick="DigitButton_Click" Text="1" Width="26px" />
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="2" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="3" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="4" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button6" runat="server" Text="5" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button7" runat="server" Text="6" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button8" runat="server" Text="7" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button9" runat="server" Text="8" Width="26px" OnClick="DigitButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button10" runat="server" OnClick="DigitButton_Click" Text="9" Width="26px" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Button13" runat="server" OnClick="DigitButton_Click" Text="0" Width="26px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                <table align="right">
                    <tr>
                        <td>
                            <asp:Button ID="Button11" runat="server" OnClick="OperatorButton_Click" Text="+" Width="26px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button12" runat="server" Text="-" Width="26px" OnClick="OperatorButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="LastOperatorHiddenField" runat="server" Value="+" Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="=" OnClick="Button1_Click" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Content>

