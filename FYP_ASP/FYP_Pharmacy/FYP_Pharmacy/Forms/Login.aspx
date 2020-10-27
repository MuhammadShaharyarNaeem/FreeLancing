<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="FYP_Pharmacy.Forms.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="content/bootstrap.min.css" rel="stylesheet" type="text/css" />  
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
                <td colspan="6" class="text-center">
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
