<%@ Page MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback="true" Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="My_English_Training_Application_Web_Form_.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="UPPER">
        <div class="input-group mb-3 input-group-sm">
            <div class="input-group-prepend">
                <span class="input-group-text text-white bg-info">Lecture Name</span>
            </div>
            <asp:TextBox type="text" ID="txtLectureName" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="upperValidation" CssClass="alert-danger" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLectureName" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="input-group mb-3 input-group-sm">
            <div class="input-group-prepend">
                <span class="input-group-text  text-white bg-info text-white bg-info">Description</span>
            </div>
            <asp:TextBox type="text" ID="txtLectureDescription" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="upperValidation" CssClass="alert-danger" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLectureDescription" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="input-group mb-3 input-group-sm">
            <div class="input-group-prepend">
                <span class="input-group-text text-white bg-info">URL</span>
            </div>
            <asp:TextBox type="text" ID="txtURL" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="upperValidation" CssClass="alert-danger" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtURL" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button runat="server" ID="btnSetLecture" ValidationGroup="upperValidation" OnClick="btnSetLecture_Click" type="button" class="btn btn-info btn-block" Text="Click to set the Lecture"></asp:Button>

    </div>
    <div class="LOWER">
        <div class="input-group mb-3 input-group-sm">
            <div class="input-group-prepend">
                <span class="input-group-text text-white bg-info">Phrase/Word</span>
            </div>
            <asp:TextBox type="text" ID="txtPhraseOrWord" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="lowerValidation" CssClass="alert-danger" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhraseOrWord" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="input-group mb-3 input-group-sm">
            <div class="input-group-prepend">
                <span class="input-group-text text-white bg-info">Description</span>
            </div>
            <asp:TextBox TextMode="MultiLine" Rows="8" type="text" ID="txtPhraseDescription" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="lowerValidation" CssClass="alert-danger" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhraseDescription" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="input-group mb-3 input-group-sm">
                <label for="comment">Enter the examples below(Each one on new line):</label>
                <div class="input-group-append">
                </div>
                <%--<asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="lowerValidation" CssClass="alert-danger" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtExamples" ErrorMessage="Required Field"></asp:RequiredFieldValidator>--%>
            </div>
            <asp:TextBox TextMode="MultiLine" class="form-control" ID="txtExamples" runat="server" Rows="5"></asp:TextBox>

        </div>
        <asp:Button runat="server" ID="btnAddPhrase" ValidationGroup="lowerValidation" CssClass="btn btn-info btn-block" OnClick="btnAddPhrase_Click" Text="Add Phrase/Word with Examples"></asp:Button>
        <asp:Panel ID="test" runat="server" class="alert">
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>


