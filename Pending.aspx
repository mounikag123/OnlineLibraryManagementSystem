<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Pending.aspx.cs" Inherits="Pending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
 .table_BS
 {
   border-collapse:collapse;
   width:100%;
 }
 .td_book, .td_student
 {
     border:1px solid #a4a4a4;
 }
 .td_1
  {
      width:200px;
      padding:3px 15px 3px 3px;
      background:#fafafa;
      text-align:right;
      border:1px solid #a4a4a4;
      
  }
  .td_2
  {
      width:250px;
      padding:3px;
      background:#fafafa;
      border:1px solid #a4a4a4;
  }
  
  /*  Table for gridview  */
   .table_gridview
   {
       width:100%;
       border-collapse:collapse;
   }
   .table_gd_th
   {       
       background:green; 
       border-right:1px solid #dddddd;
       padding:5px 8px 5px 8px;
       color:#ffffff;
   }
   .table_gd_td
   {   
       border:1px solid #dddddd;
       padding:5px 8px 5px 8px;
   }
   .header_th
   {
       background:#4A3C8C;
       font-weight:bold;
       color:#0a0abd;
   }
   .row_td
   {
       text-align:center;
   }
   </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-top: -15px; height: 500px; padding: 35px 25px 50px 25px;background-image: url('Images/mybg.jpg')" >
  <div style="padding:10px;" align="center">
   <caption><h5 class="alert alert-info">Over Due Books</h5></caption>
   <table class="table_BS">
    <tr>
        <td class="td_1">Book ID :</td>
        <td class="td_2"><asp:TextBox ID="txt_bookid" CssClass="txtbox" runat="server" 
                AutoPostBack="True" ontextchanged="txt_bookid_TextChanged"></asp:TextBox></td>
        <td class="td_1">Student ID :</td>
        <td class="td_2">
            <asp:TextBox ID="txt_studentid" CssClass="txtbox" runat="server" 
                AutoPostBack="True" ontextchanged="txt_studentid_TextChanged"></asp:TextBox></td>
   </tr>
   </table>
  </div>
  <br />
  <div align="center">  
   <asp:GridView ID="Grd_Pending_Status" AutoGenerateColumns="False" 
          HeaderStyle-CssClass="headerstyle" runat="server" BackColor="White" 
          BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
          CellSpacing="1" GridLines="None" DataKeyNames="bookid,studentid" 
          onrowdatabound="Grd_Pending_Status_RowDataBound" CssClass="table table-responsive table-condensed table-striped " >
    <Columns>
       <asp:TemplateField HeaderText="Book ID">
         <ItemTemplate>
         <asp:Label ID="lblbookid" runat="server" Text='<%# Eval("bookid") %>' />
         </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Student (ID / Name)">
         <ItemTemplate>
         <asp:Label ID="lblstudentid" runat="server" Text='<%# Eval("studentname") %>'/>
         </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Start Date">
         <ItemTemplate>
         <asp:Label ID="lblstartdate" runat="server" Text='<%# Eval("assigneddate") %>'/>
         </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="End Date">
         <ItemTemplate>
         <asp:Label ID="lblenddate" runat="server" Text='<%# Eval("returndate") %>'/>
         </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Penality">
         <ItemTemplate>
         <asp:Label ID="lblpenality" runat="server" Text='<%# Eval("penality") %>' />
         </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Status">
         <ItemTemplate>
           <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status") %>' Visible = "false" />
          <asp:DropDownList ID="ddl_status" Width="120px" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_status_SelectedIndexChanged"></asp:DropDownList>
         </ItemTemplate>
        </asp:TemplateField>
    </Columns>
       <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />

<HeaderStyle CssClass="header_th"></HeaderStyle>
       <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
       <RowStyle BackColor="#DEDFDE" ForeColor="Black" CssClass="row_td" />
       <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
       <SortedAscendingCellStyle BackColor="#F1F1F1" />
       <SortedAscendingHeaderStyle BackColor="#594B9C" />
       <SortedDescendingCellStyle BackColor="#CAC9C9" />
       <SortedDescendingHeaderStyle BackColor="#33276A" />
</asp:GridView> 
</div>
<div align="center">
<br />
 <asp:Label ID="lblresult" runat="server"></asp:Label>
</div>
 </div>
</asp:Content>

