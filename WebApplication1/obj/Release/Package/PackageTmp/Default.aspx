<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style >
        .jumbotron
        {
            background-image: url("Singapore.png");
            background-size :auto;
            color: white;
        }
        .centerpl
        {
            text-align:center;
        }
    </style>
    <div class="jumbotron">
        <h1>No1 Property Listing in Singapore</h1>
        <p class="lead">Join our membership to get full benefit from website service from as low as S$10/Month. </p>
        <p class="lead">&nbsp;</p>
        <p><a href="Register.aspx" class="btn btn-primary btn-lg">Register Now &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Platinum Membership</h2>
            <p >
                Platinum membership unlock all the premium features. <br />100 Concurrent Listings <br />35,000 Ad Credits <br />100 Floor Plans /mth<br /> Auto-Repost <br />Commercial Listings <br />Agent Profile<br /> MyWeb         </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Gold Membership</h2>
            <p>
                Gold membership unlock three(3) the premium features. <br />60 Concurrent Listings <br />9,000 Ad Credits <br />60 Floor Plans /mth<br /> Auto-Repost <br />Commercial Listings <br />Agent Profile<br /> MyWeb
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Silver Membership</h2>
            <p>
                Silver membership unlock one(1) the premium features. <br />25 Concurrent Listings <br />3,000 Ad Credits <br />25 Floor Plans /mth<br /> Auto-Repost <br />Commercial Listings <br />Agent Profile<br /> MyWeb
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
