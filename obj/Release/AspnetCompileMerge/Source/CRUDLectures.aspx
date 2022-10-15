<%@ Page MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="CRUDLectures.aspx.cs" Inherits="My_English_Training_Application_Web_Form_.CRUDLectures" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView class="table table-striped" runat="server" ID="grid" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowEditing="grid_RowEditing" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Lecture Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblLectureName" Text='<%#Eval("LectureName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="txtLectureName" Text='<%#Eval("LectureName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="txtDescription" Text='<%#Eval("Description") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="URL">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblURL" Text='<%#Eval("VideoURL") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="txtURL" Text='<%#Eval("VideoURL") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Commands">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure want to delete?')" CommandName="Delete" Text="Delete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" OnClientClick="return confirm('Are you sure want to Update?')" CommandName="Update" Text="Update" />
                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="row">
        <asp:Button runat="server" ID="btnNext" CssClass="float-left col-md-1  btn btn-outline-primary" Text="<-Prev" OnClick="btnPrev_Click"></asp:Button>
        <div class="col-md-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="drpTake" OnSelectedIndexChanged="drpTake_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="5" Value="5" Selected="True"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                <asp:ListItem Text="200" Value="200"></asp:ListItem>
                <asp:ListItem Text="500" Value="500"></asp:ListItem>
                <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button runat="server" ID="btnPrev" CssClass="float-right col-md-1  btn btn-outline-primary" Text="Next->" OnClick="btnNext_Click"></asp:Button>
    </div>

</asp:Content>
