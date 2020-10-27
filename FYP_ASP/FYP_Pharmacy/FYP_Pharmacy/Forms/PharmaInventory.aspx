<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PharmaInventory.aspx.cs" Inherits="FYP_Pharmacy.Forms.PharmaInventory" MasterPageFile="~/Master_Admin.Master" %>

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
                <td colspan="6">
                    <asp:Label runat="server" ID="lbl_err" Visible="false" Style="color: red" CssClass="form-label" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Search :" runat="server" CssClass="form-label" />
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" name="medicineQRcode" ID="medicineQRcode" OnTextChanged="medicineQRcode_TextChanged" CssClass="form-control" AutoPostBack="true"/>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:GridView ID="gridPharmacy" runat="server" AutoGenerateColumns="false" Visible="true" CssClass="table table-condensed">
                        <Columns>
                            <asp:BoundField runat="server" DataField="name"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="expiry_date"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="mfg_date"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="batch_no"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="registration_no"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="registrant"></asp:BoundField>
                            <asp:BoundField runat="server" DataField="price"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
