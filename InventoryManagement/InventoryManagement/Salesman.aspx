<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salesman.aspx.cs" Inherits="InventoryManagement.Salesman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server">
        <ContentTemplate>
            <h2>Welcome to Salesman Page!!</h2>
            <br />

            <h2><span class="badge badge-info btn-lg btn-block">Enter a New Salesman</span></h2>
            <br />
            <div class="form-group row">
                <label for="salesmanNo" class="col-sm-2 col-form-label" style="left: 0px; top: 0px">Salesman Id</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtID" runat="server" placeholder="id"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="salesmanName" class="col-sm-2 col-form-label">Salesman Name</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtSalesmanName" runat="server" placeholder="salesmanName"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="city" class="col-sm-2 col-form-label">City</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtCity" runat="server" placeholder="city"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="commission" class="col-sm-2 col-form-label">Commission</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtCommission" runat="server" placeholder="Commission"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Enter Salesman"></asp:Button>
                    &nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-primary" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    &nbsp;<br />
                    <br />
                    Salesman Id &nbsp;<asp:TextBox ID="txtDeleteId" runat="server" Height="18px"></asp:TextBox>
                    &nbsp;
                    <asp:Button CssClass="btn btn-primary" ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                    <br />
                    &nbsp;
                </div>
            </div>


            <h1><span class="badge badge-success btn-lg btn-block">Existing Salesman</span></h1>

            <br />

            <asp:GridView ID="gvSalesman" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [salesman]"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
