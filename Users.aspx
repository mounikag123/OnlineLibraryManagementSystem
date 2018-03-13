<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .myddls {
            align-items: center;
            background-color: rgb(255, 255, 255);
            border-bottom-color: rgb(204, 204, 204);
            border-bottom-left-radius: 4px;
            border-bottom-right-radius: 0px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-collapse: collapse;
            border-image-outset: 0px;
            border-image-repeat: stretch;
            border-image-slice: 100%;
            border-image-source: none;
            border-image-width: 1;
            border-left-color: rgb(204, 204, 204);
            border-left-style: solid;
            border-left-width: 1px;
            border-right-color: rgb(204, 204, 204);
            border-right-style: solid;
            border-right-width: 1px;
            border-top-color: rgb(204, 204, 204);
            border-top-left-radius: 4px;
            border-top-right-radius: 0px;
            border-top-style: solid;
            border-top-width: 1px;
            box-shadow: rgba(0, 0, 0, 0.0745098) 0px 1px 1px 0px inset;
            box-sizing: border-box;
            color: rgb(85, 85, 85);
            cursor: default;
            display: inline-block;
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 14px;
            font-stretch: normal;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            height: 34px;
            letter-spacing: normal;
            line-height: normal;
            margin-bottom: 0px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            max-width: 280px;
            overflow-x: visible;
            overflow-y: visible;
            padding-bottom: 6px;
            padding-left: 12px;
            padding-right: 12px;
            padding-top: 6px;
            text-align: start;
            text-indent: 0px;
            text-rendering: auto;
            text-shadow: none;
            text-transform: none;
            transition-delay: 0s, 0s;
            transition-duration: 0.15s, 0.15s;
            transition-property: border-color, box-shadow;
            transition-timing-function: ease-in-out, ease-in-out;
            vertical-align: middle;
            white-space: pre;
            width: 48px;
            word-spacing: 0px;
            writing-mode: horizontal-tb;
            -webkit-appearance: menulist-button;
            -webkit-rtl-ordering: logical;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div>
            <br />
            <br />
            
            <div class="input-group">
                <div class="form-inline">              
                    <table border="0" cellpadding="5" cellspacing="5" class="table bg-success ">
                        <tr>
                            <td>
                                <span>Student Id</span>
                            </td>
                            <td>
                                <span>Student Name </span>
                            </td>
                             <td>
                                <span>Year </span>
                            </td>
                             <td>
                                <span>Branch </span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txtStudentId" class="form-control" placeholder="Student Id" required  CssClass="form-control"/>
                            </td>
                            <td>
                                 <asp:TextBox runat="server" ID="txtStudentName" class="form-control" placeholder="Student Name" required CssClass="form-control"/>
                            </td>
                             <td>
                                <asp:DropDownList runat="server" ID="ddlyear"  class="form-control">
                                     <asp:ListItem Text="1st year" Selected="True"></asp:ListItem>
                                      <asp:ListItem Text="2nd year"></asp:ListItem>
                                      <asp:ListItem Text="3rd year"></asp:ListItem>
                                      <asp:ListItem Text="4th year"></asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                             <td>
                                 <asp:DropDownList runat="server" ID="ddlBranch"  class="form-control" >
                                       <asp:ListItem Text="ECE" Selected="True"></asp:ListItem>
                                       <asp:ListItem Text="CSE"></asp:ListItem>
                                       <asp:ListItem Text="IT"></asp:ListItem>
                                       <asp:ListItem Text="EIE"></asp:ListItem>
                                      <asp:ListItem Text="MBA"></asp:ListItem>
                                      <asp:ListItem Text="Others"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button Text="Add User" runat="server" ID="btnAdd" 
                                    class="btn btn-sm btn-primary" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            <br />
          <asp:GridView ID="GridView1" runat="server" 
                CssClass="table table-responsive table-striped" AutoGenerateColumns="False" 
                DataKeyNames="studentid" DataSourceID="LibraryDb">
              <Columns>
                  <asp:BoundField DataField="studentid" HeaderText="Student Id" 
                      SortExpression="studentid" ReadOnly="True"  />
                  <asp:BoundField DataField="studentname" HeaderText="Name" 
                      SortExpression="studentname" />
                  <asp:BoundField DataField="studentbranch" HeaderText="Branch" 
                      SortExpression="studentbranch" />
                  <asp:BoundField DataField="studentyear" HeaderText="Year" 
                      SortExpression="studentyear" />
                    <asp:CommandField ShowEditButton="True" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="LibraryDb" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LIBRARYConnectionString %>" 
                SelectCommand="SELECT * FROM [Student] ORDER BY id" 
                DeleteCommand="DELETE FROM [Student] WHERE [studentid] = @studentid" 
                InsertCommand="INSERT INTO [Student] ([studentid], [studentname], [studentbranch], [studentyear]) VALUES (@studentid, @studentname, @studentbranch, @studentyear)" 
                UpdateCommand="UPDATE [Student] SET [studentname] = @studentname, [studentbranch] = @studentbranch, [studentyear] = @studentyear WHERE [studentid] = @studentid">
                <DeleteParameters>
                    <asp:Parameter Name="studentid" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="studentid" Type="String" />
                    <asp:Parameter Name="studentname" Type="String" />
                    <asp:Parameter Name="studentbranch" Type="String" />
                    <asp:Parameter Name="studentyear" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="studentname" Type="String" />
                    <asp:Parameter Name="studentbranch" Type="String" />
                    <asp:Parameter Name="studentyear" Type="String" />
                    <asp:Parameter Name="studentid" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </center>
</asp:Content>

