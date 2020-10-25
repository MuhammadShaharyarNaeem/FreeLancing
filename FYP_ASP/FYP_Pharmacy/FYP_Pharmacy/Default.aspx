<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYP_Pharmacy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 50px">
        <table style="width: 100%">
            <tr>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
                <td style="width: 12%"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Label runat="server" Text="Login Name" Style="padding-right: 5px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_login"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Label runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_password" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button runat="server" Text="Submit" OnClick="OnSubmit_Click" />
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
