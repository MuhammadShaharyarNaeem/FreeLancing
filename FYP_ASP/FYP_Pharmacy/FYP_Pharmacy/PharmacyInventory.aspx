<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PharmacyInventory.aspx.cs" Inherits="FYP_Pharmacy.PharmacyInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Search :" runat="server" /> <asp:TextBox runat="server" name="medicineQRcode" ID="medicineQRcode" OnTextChanged="medicineQRcode_TextChanged"/>
            <asp:GridView ID="gridPharmacy" runat="server">  
                 <Columns>  
                        <asp:BoundField runat="server" DataField="Name"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="Expiry_Date"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="MFG_Date"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="Batch_no"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="Registration_no"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="Registrant"></asp:BoundField>
                        <asp:BoundField runat="server" DataField="price"></asp:BoundField>
                        <asp:CommandField ShowEditButton="True" />  
                    </Columns>  
            </asp:GridView>  
        </div>
    </form>
</body>
</html>
