<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PharmacyPOS.aspx.cs" Inherits="FYP_Pharmacy.Forms.PharmacyPOS" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <h3 class="page-header">
        <asp:Label runat="server" ID="lbl_title" CssClass="jumbotron" Width="100%" Text="" Font-Bold="true"></asp:Label>
    </h3>
    <h4>
        <asp:Label runat="server" ID="lbl_err" Visible="False" Style="color: #ff0000" CssClass="form-label" Font-Bold="true" />
    </h4>
    <asp:Panel runat="server" ID="pnl_front" Visible="true">
        <div class="container">
            <table style="width: 100%; border-spacing: 0 5px; border-collapse: separate">
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
                    <td style="text-align: center">
                        <asp:Label runat="server" Text="QR/BarCode" CssClass="form-label" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txt_qrcode" Width="100%" CssClass="form-control" OnTextChanged="txt_qrcode_TextChanged" AutoPostBack="true"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover table-striped" CellSpacing="0" Visible="true" BorderColor="White" OnRowCommand="gridView_RowCommand"
                            AllowPaging="false" ShowHeader="true" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField runat="server" DataField="ID" HeaderText="ID" Visible="false"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="Name" HeaderText="Name"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="BatchNo" HeaderText="BatchNo"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="ExpiryDate" HeaderText="ExpiryDate"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="MfgDate" HeaderText="MfgDate"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="Price" HeaderText="Price"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="QRCode" HeaderText="QRCode"></asp:BoundField>
                                <asp:ButtonField runat="server" ButtonType="Button" Text="delete" ControlStyle-CssClass="btn btn-primary" CommandName="DeleteRow" ItemStyle-Width="10%" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="text-align: center">
                        <asp:Label runat="server" Text="Grand Total" CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_total" Enabled="false" Width="100%" CssClass="form-control" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: center">
                        <asp:Label runat="server" Text="Customer Name" CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_cust" CssClass="form-control" />
                    </td>
                    <td></td>
                    <td></td>

                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btn_Save" CssClass="btn btn-primary" OnClick="btn_Save_Click" Text="Save"/>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btn_cancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btn_cancel_Click" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
