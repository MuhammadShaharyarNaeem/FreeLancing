<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="FYP_Pharmacy.Forms.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">

    <div class="container" style="padding-top: 200px">
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
                <td colspan="6">
                    <asp:Label runat="server" ID="lbl_err" Visible="false" Style="color: red" CssClass="form-label"/>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                
                <td>
                    <asp:Label runat="server" Text="Login Name" CssClass="form-label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txt_login" CssClass="form-control"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Label runat="server" Text="Password" CssClass="form-label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txt_password" TextMode="Password" CssClass="form-control"></asp:TextBox>
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
                    <asp:Button runat="server" Text="Submit" OnClick="OnSubmit_Click" CssClass="btn btn-primary" />
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
