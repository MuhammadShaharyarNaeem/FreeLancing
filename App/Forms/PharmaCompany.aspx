<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="PharmaCompany.aspx.cs" Inherits="FYP_Pharmacy.Forms.PharmaCompany" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <h3 class="page-header">
        <asp:Label runat="server" ID="lbl_title" CssClass="jumbotron" Width="100%" Text="Admin PharmaCompany Panel" Font-Bold="true"></asp:Label>
    </h3>
    <h4>
        <asp:Label runat="server" ID="lbl_err" Visible="False" Style="color: #ff0000" CssClass="form-label" Font-Bold="true" />
    </h4>
        <asp:Panel runat="server" ID="pnl_front" Visible="true">
        <div class="container">
            <table style="width: 100%; border-spacing:0 5px; border-collapse:separate " >
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
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" 
                            CssClass="table table-hover table-striped" CellSpacing="0" Visible="true" BorderColor="White" OnRowCommand="gridView_RowCommand"
                            AllowPaging="false" ShowHeader="true" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField runat="server" DataField="ID" HeaderText="ID" Visible="false"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="Name" HeaderText="Name"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="Email" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="ContactNumber" HeaderText="ContactNumber"></asp:BoundField>
                                <asp:BoundField runat="server" DataField="Description" HeaderText="Description"></asp:BoundField>
                                <asp:ButtonField runat="server" ButtonType="Button" Text="Edit" ControlStyle-CssClass="btn btn-primary" CommandName="EditRow" ItemStyle-Width="10%"/>
                                <asp:ButtonField runat="server" ButtonType="Button" Text="delete" ControlStyle-CssClass="btn btn-primary" CommandName="DeleteRow" ItemStyle-Width="10%"/>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_back" Visible="false">
        <div class="container">
            <table style="width: 100%; border-spacing:0 5px; border-collapse:separate " >
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
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="ID" CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_id" CssClass="form-control" Enabled="false" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="Name " CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_name" CssClass="form-control"/>
                    </td>
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="ContactNumber" CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_cnumber" CssClass="form-control"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="Email" CssClass="form-label" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_email" CssClass="form-control"/>
                    </td>
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="Description" CssClass="form-label" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txt_desc" CssClass="form-control"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label runat="server" Text ="Address" CssClass="form-label" />
                    </td>
                    <td colspan="2" rowspan="2">
                        <asp:TextBox runat="server" ID="txt_addr" TextMode="MultiLine" CssClass="form-control"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="8"></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btn_SaveUpdDel" CssClass="btn btn-primary" OnClick="btn_SaveUpdDel_Click" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btn_cancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btn_cancel_Click"/>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
