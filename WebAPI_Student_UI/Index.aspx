<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebAPI_Student_UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="ms-3">
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-6">
                        <h2>Add Marks</h2>
                        <div>
                            <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green" BackColor="Yellow" ></asp:Label> 
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" BackColor="Yellow"></asp:Label>
                        </div>
                        <form method="post" action="">
                            <div style="text-align:center;">
                                <label>Search id</label>
                                <asp:TextBox ID="txt_search" runat="server" ></asp:TextBox>
                                <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btn_search_Click" />
                            </div>
                            <div class="form-group">
                                <label>Student Name</label>
                                <asp:TextBox ID="txt_Name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Tamil</label>
                                <asp:TextBox ID="txt_Tamil" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>English</label>
                                <asp:TextBox ID="txt_English" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Maths</label>
                                <asp:TextBox ID="txt_Maths" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Science</label>
                                <asp:TextBox ID="txt_Science" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>SocialScience</label>
                                <asp:TextBox ID="txt_SS" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btn_Insert" runat="server" Text="Insert" CssClass="btn btn-info my-2" OnClick="btn_Insert_Click" />
                                <asp:Button ID="btn_Update" runat="server" Text="Update" CssClass="btn btn-info my-2" OnClick="Button1_Click" />
                                <asp:Button ID="btn_Delete" runat="server" Text="Delete" CssClass="btn btn-info my-2" OnClick="btn_Delete_Click" />
                                
                            </div>
                        </form>
                        <h3>Mark Details</h3>
                        <div>
                            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Height="300px" Width="700px" >
                                <HeaderStyle BackColor="#3366FF" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
