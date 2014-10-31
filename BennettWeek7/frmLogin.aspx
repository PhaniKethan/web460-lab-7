<!--Steven Bennett Week 7 Lab-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 7 Lab | Steven Bennett</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <a class="navbar-brand" href="#">Week 7 Lab | Steven Bennett</a>
        </div>
      </div>
    </div>

    <div class="container">
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-sm-5 col-sm-offset-4">
        <div class="panel panel-primary">
            <div class="panel-heading">Login</div>
            <div class="panel-body">
                <div class="form-group">
        <asp:Label ID="lblUserID" runat="server" Text="User ID" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtUserID" CSSClass="form-control" runat="server"></asp:TextBox>
                 </div>

                <div class="form-group">
        <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtPassword" CSSClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Button ID="btnLogin" CSSClass="btn btn-default btn-block" runat ="server" Text="Login" OnClick="btnLogin_Click" /><br />

        <asp:Label ID="lblStatus" runat="server" Text="Status Message Goes Here"></asp:Label>
                </div><!--end panel-body-->
        </div><!--end panel panel-primary-->
            </div><!--end col-sm-5-->
    </div><!--end row-->
    </form>
    </div><!--end containter-->

    <script src="Scripts/jquery-1.9.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
