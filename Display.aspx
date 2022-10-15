<%@ Page MasterPageFile="~/Site1.Master" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Display.aspx.cs" Inherits="My_English_Training_Application_Web_Form_.Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('[data-toggle="popover"]').popover({ html: true, trigger: "hover" });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h1>English Trainer</h1>
            <p>Get ready to be a fluent english speaker with our dataset having huge amount of words along with the description,usages and examples.</p>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtFilter" OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
            <asp:Repeater runat="server" ID="rptLectures" OnItemDataBound="rptLectures_ItemDataBound">
                <ItemTemplate>
                    <div class=" bg-info p-2 text-white rounded border border-white">
                        <div class="row">
                            <div class="col-md-7" style="cursor: context-menu" data-toggle="collapse" data-target="#outerCollapse_<%# DataBinder.Eval(Container,"ItemIndex") %>">
                                <asp:Label CssClass="" runat="server" Text='<%#Eval("LectureName") %>'></asp:Label>
                            </div>
                            <div class="col-md-1">
                                <a href="#" data-toggle="popover" class="text-white badge badge-pill badge-dark" title="Description" data-content='<%#Eval("Description") %>' data-placement="left">Description</a>
                            </div>
                            <div class="col-md-4">
                                <asp:HyperLink CssClass="text-white" runat="server" Text='<%#Eval("VideoURL") %>' NavigateUrl='<%#Eval("VideoURL") %>'></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                    <div id="outerCollapse_<%# DataBinder.Eval(Container,"ItemIndex") %>" class="collapse">
                        <asp:Repeater runat="server" ID="rptWords" OnItemDataBound="rptWords_ItemDataBound">
                            <ItemTemplate>
                                <div class=" bg-dark p-2  text-white rounded border border-white">
                                    <div class="row">
                                        <div class="col-md-7 pl-4" style="cursor: context-menu" data-toggle="collapse" data-target="#innerCollapse_<%# DataBinder.Eval(Container.Parent.Parent,"ItemIndex") %><%# DataBinder.Eval(Container,"ItemIndex") %>">
                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("PhraseOrWord") %>'></asp:Label>
                                        </div>
                                        <div class="col-md-5">
                                            <a href="#" data-toggle="popover" class="text-white badge badge-pill badge-secondary" title="Description" data-content='<%#Eval("Description") %>' data-placement="left">Description</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="innerCollapse_<%# DataBinder.Eval(Container.Parent.Parent,"ItemIndex") %><%# DataBinder.Eval(Container,"ItemIndex") %>" class="collapse">
                                    <asp:Repeater runat="server" ID="rptExamples">
                                        <ItemTemplate>
                                            <li class="bg-secondary  p-2 pl-4 text-white  rounded border border-white">
                                                <asp:Label contenteditable="true" runat="server" Text='<%#Eval("Example") %>'></asp:Label></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="row" style="margin-left: 0px; margin-right: 0px;">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




