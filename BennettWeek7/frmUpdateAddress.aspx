<!--Stevn Bennett Week 7 Lab-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmUpdateAddress.aspx.cs" Inherits="frmUpdateAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Week 6 Lab | Steven Bennett</title>
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
                <div class="col-sm-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Add Record</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtFirstName" CSSClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtLastName" CSSClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtEmail" CSSClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtPhoneNumber" CSSClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnAdd" runat="server" CSSClass="btn btn-default" Text="Add" OnClick="btnAdd_Click" />
                            </div><!--end panel-body-->
                    </div><!--end panel panel-primary-->
                </div><!--end col-sm-6-->

                <div class="col-sm-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Address ID Search and Update</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="lblAddressId" runat="server" Text="Address ID" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="txtAddressId" CSSClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <asp:Label ID="lblStatus" runat="server" Text="Status Message Goes Here"></asp:Label><br />
                            <asp:Button ID="cmdFind" runat="server" CSSClass="btn btn-default" Text="Find Address" OnClick="cmdFind_Click" />
                            <asp:Button ID="cmdUpdate" runat="server" CSSClass="btn btn-default" Text="Update Address" OnClick="cmdUpdate_Click" />
                        </div><!--end panel-body-->
                    </div><!--end panel-primary-->
                </div><!--end col-sm-6-->
            </div><!--end row-->

            <br />
            <br />
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvAddresses" runat="server" CellPadding="4" GridLines="None" CssClass="table" AlternatingRowStyle-Wrap="False" ShowHeader="True">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <HeaderStyle Font-Bold="True"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

                        <RowStyle BackColor="#E3EAEB"></RowStyle>

                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div><!--end col-sm-12-->
            </div><!--end row-->
        </form>
    </div>

    <script src="Scripts/jquery-1.9.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
