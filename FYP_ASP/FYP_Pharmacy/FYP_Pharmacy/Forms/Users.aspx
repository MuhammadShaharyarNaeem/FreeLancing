<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Users.aspx.cs" Inherits="FYP_Pharmacy.Forms.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <div style="margin-top: 100px" class="container">
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
                <td colspan="8" class="page-header">
                    <h1>
                        <asp:Label runat="server" ID="lbl_title" CssClass=""></asp:Label>
                    </h1>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btn_AddNew" Text="Add New" CssClass="btn btn-primary" OnClick="AddNew_Click"/>
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>
