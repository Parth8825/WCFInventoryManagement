<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="InventoryManagement.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server">
        <ContentTemplate>
            <h2 style="text-align: center;">Welcome to Inventory Management Solutions!!</h2>
            <br />
            <br />
            <h1><span class="badge bg-info btn-lg btn-block">Eenter New Order</span></h1>

            <div class="form-group row">
                <label for="salesmanNo" class="col-sm-2 col-form-label">Order No</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtOrderNo" runat="server" placeholder="order no"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="salesmanName" class="col-sm-2 col-form-label">Purchase Amount</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtPurchAmt" runat="server" placeholder="Amount"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="city" class="col-sm-2 col-form-label">Order Date</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" ID="txtOrderDate" TextMode="Date" runat="server" placeholder="date"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="commission" class="col-sm-2 col-form-label">Customer Id</label>
                <div class="col-sm-10">
                    <asp:DropDownList class="form-control" ID="dlCustId" runat="server" DataSourceID="SqlDataSource2" DataTextField="customer_id" DataValueField="customer_id" AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="Please Select ID"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT [customer_id] FROM [customer]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group row">
                <label for="commission" class="col-sm-2 col-form-label">Salesman Id</label>
                <div class="col-sm-10">
                    <asp:DropDownList class="form-control" ID="dlSalesmanId" runat="server" DataSourceID="SqlDataSource3" DataTextField="salesman_id" DataValueField="salesman_id" AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="Please Select ID"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT [salesman_id] FROM [salesman]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Enter Order"></asp:Button>
                    &nbsp;&nbsp;
                    <asp:Button CssClass="btn btn-primary" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    &nbsp;<br />
                    <br />
                    Orde Id &nbsp;<asp:TextBox ID="txtDeleteId" runat="server" Height="18px"></asp:TextBox>
                    &nbsp;
                    <asp:Button CssClass="btn btn-primary" ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                    <br />
                    &nbsp;
                </div>
            </div>
            <h1><span class="badge bg-success btn-lg btn-block">Existing Orders</span></h1>

            <div class="text-center">

                <asp:GridView ID="gvOrder" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [orders]"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
