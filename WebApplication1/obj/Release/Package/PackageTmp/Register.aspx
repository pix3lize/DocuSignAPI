<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Membership registration</h3>
    <br />
    <br /> 
        <div class="form-group">
            <label for="exampleFormControlInput1">Full Name</label>
            <asp:TextBox ID="TxtName" type="text" runat="server" class="form-control" placeholder="Full name"></asp:TextBox>
            <label for="exampleFormControlInput1">Email address</label>
            <asp:TextBox ID="TxtEmail" type="email" runat="server" class="form-control" placeholder="name@example.com"></asp:TextBox>
            <label for="exampleFormControlInput1">Date of Birth</label>
            <asp:TextBox ID="TxtDOB" type="date" runat="server" class="form-control" placeholder="DD/MM/YYYY 01/04/1990"></asp:TextBox>
            <label for="exampleFormControlInput1">Gender</label><br />
            <asp:RadioButton ID="RbMale"  type="radio" runat="server" GroupName="gender" checked />Male
            <asp:RadioButton ID="RbFemale"  type="radio" runat="server" GroupName="gender" />Female
        </div>
        <div class="form-group">
            <label for="exampleFormControlInput1">Phone Number</label>
            <asp:TextBox ID="TxtPhone" type="tel" runat="server" class="form-control" placeholder="+65XXXXXXX"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="exampleFormControlTextarea1">Address</label>
             <asp:TextBox ID="TxtAddress" TextMode="MultiLine" type="tel" runat="server" class="form-control" placeholder="Address"></asp:TextBox>           
        </div>
        <div class="form-group">
            <label for="exampleFormControlTextarea1">Membership selection</label>
            <asp:DropDownList ID="DropMember" runat="server" class="form-control">
                <asp:ListItem>Platinum Membership</asp:ListItem>
                <asp:ListItem>Gold Membership</asp:ListItem>
                <asp:ListItem>Silver Membership</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="exampleFormControlTextarea1">Submit</label>
            <asp:Button ID="Button1" type="button" class="form-control btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>  
</asp:Content>
