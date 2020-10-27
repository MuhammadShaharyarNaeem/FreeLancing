<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Users.aspx.cs" Inherits="FYP_Pharmacy.Forms.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <h3 class="page-header">
        <asp:Label runat="server" ID="lbl_title" CssClass="jumbotron" Width="100%" Text="Admin Users Panel" Font-Bold="true"></asp:Label>
    </h3>
    <asp:Panel runat="server" ID="pnl_front">
        <div class="container">
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
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btn_AddNew" Text="Add New" CssClass="btn btn-primary" OnClick="AddNew_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:GridView ID="gridPharmacy" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed" Visible="true"
                                EmptyDataText = "No Records Found" AllowPaging = "true" PagerStyle-HorizontalAlign = "Right" ShowHeader="true">
                        <Columns>
                            <asp:BoundField runat="server" DataField="ID" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="Name" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="Description" HeaderText="Description"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
