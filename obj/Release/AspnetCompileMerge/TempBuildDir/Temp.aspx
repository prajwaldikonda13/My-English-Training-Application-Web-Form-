<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Temp.aspx.cs" Inherits="My_English_Training_Application_Web_Form_.Temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater runat="server" ID="rptLectures" OnItemDataBound="rptLectures_ItemDataBound">
            <ItemTemplate>
                <div id="accordion">
                    <dl>
                        <dt>Lecture Name<span>URL</span></dt>
                        <dd>
                            <dl>
                                <dt>Lecture Description</dt>
                                <dd>
                                    <dl>
                                        <dt>PhraseOrWord</dt>
                                        <dd>
                                            <dl>
                                                <dt>Word Description</dt>
                                                <dd>
                                                    <ul>
                                                        <li>Examples</li>
                                                    </ul>
                                                </dd>
                                            </dl>
                                        </dd>
                                    </dl>
                                </dd>
                            </dl>
                        </dd>
                    </dl>
                    <div class="card">
                        <div class="card-header  bg-primary">
                            <a class="card-link" data-toggle="collapse" href="#collapseOne">
                                <asp:Label CssClass="text-white" runat="server" Text='<%#Eval("LectureName") %>'></asp:Label>
                            </a>
                        </div>
                        <div id="collapseOne" class="collapse show" data-parent="#accordion">
                            <div class="card-body   bg-info">
                                <asp:Label CssClass="text-white" runat="server" Text='<%#Eval("Description") %>'></asp:Label><br />

                                <asp:HyperLink NavigateUrl='<%#Eval("VideoURL") %>' runat="server" Text='<%#Eval("VideoURL") %>'></asp:HyperLink><br />
                                <asp:Repeater runat="server" ID="rptWords" OnItemDataBound="rptWords_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("PhraseOrWord") %>'></asp:Label><br />
                                        <asp:Label runat="server" ID="lblWords" Text='<%#Eval("Description") %>'></asp:Label><br />
                                        <asp:Repeater runat="server" ID="rptExamples">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("Example") %>'></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

         <button type="button" class="btn btn-block btn-primary" data-toggle="collapse" data-target="#demo">LectureName along with URL</button>
        <div id="demo" class="collapse">
            <div class="btn  btn-block btn-primary" data-toggle="collapse" data-target="#demo1">Lecturedescription</div>
            <button type="button" class="btn  btn-block btn-primary" data-toggle="collapse" data-target="#demo2">Phrase or word</button>
            <div id="demo2" class="collapse">
                <button type="button" class="btn btn-block  btn-primary" data-toggle="collapse" data-target="#demo3">Word description</button>
                <button type="button" class="btn btn-block  btn-primary" data-toggle="collapse" data-target="#demo4">Examples</button>
                <div id="demo4" class="collapse">
                    text
                </div>
            </div>
        </div>
    </form>
</body>
</html>
