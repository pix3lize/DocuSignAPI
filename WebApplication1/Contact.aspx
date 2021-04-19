<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Steady Way<br />
        Redmond, Singapore 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@steadyproperty.com.sg</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@steadyproperty.com.sg</a>
    </address>
</asp:Content>
