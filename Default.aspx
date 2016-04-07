<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="display: block; text-align: center">
        <div style="display: inline; text-align: left">
            <asp:TextBox runat="server" ID="txtId" Height="20px" Width="100px"></asp:TextBox>
        </div>
        <div style="display: inline; text-align: left">
            <asp:Button runat="server" ID="btnSubmit" Height="30px" Width="100px" Text="Populate Grid"
                OnClick="btnSubmit_Click"></asp:Button>
        </div>
    </div>
    <br />
    <div style="display: block; text-align: center; padding-left: 250px;">
        <asp:GridView runat="server" ID="grdStudentView">
        </asp:GridView>
    </div>
    <div>
    <asp:Label runat="server" ID="lblErrorDisplay" ForeColor="Red" Font-Bold="true" Visible="false" Font-Size="Medium" ></asp:Label>
    </div>
</asp:Content>
