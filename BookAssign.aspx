<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="BookAssign.aspx.cs" Inherits="BookAssign" %>

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
  .txtbox
  {
      width:200px;
      padding:3px;
  }
   .btn
  {
      background:#6699cc;
      border:1px solid #6699cc;
      padding:5px 10px 5px 10px;
      color:#ffffff;
  }
  .btn:hover
  {
      background:#ea6153;
      border:1px solid #ea6153;
      padding:5px 10px 5px 10px;
      color:#ffffff;
  }
  
  .td_b_11
  {
      width:200px;
      padding:3px 15px 3px 3px;
      text-align:right;
      border-left:1px solid #a4a4a4;
  }
  .td_b_22
  {
      width:250px;
      padding:3px;
      border-right:1px solid #a4a4a4;
  }
  .td_b_11_last
  {
      width:200px;
      padding:3px 15px 3px 3px;
      text-align:right;
      border-left:1px solid #a4a4a4;
      border-bottom:1px solid #a4a4a4;
  }
   .td_b_22_last
  {
      width:250px;
      padding:3px;
      border-right:1px solid #a4a4a4;
      border-bottom:1px solid #a4a4a4;
  }
  
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="margin-top: -15px; height: 500px; padding: 35px 25px 50px 25px;background-image: url('Images/mybg.jpg')" >
 <div style="padding:10px;" align="center">
 <caption> <h5 class="alert alert-info">Book Assignment</h5></caption>
  <table class="table_BS">
    <tr>
        <td class="td_1">Book ID :</td>
        <td class="td_2">
            <asp:TextBox ID="txt_assign_bookid" CssClass="txtbox" runat="server" 
                AutoPostBack="True" ontextchanged="txt_assign_bookid_TextChanged"></asp:TextBox></td>
        <td class="td_1">Student ID :</td>
        <td class="td_2">
            <asp:TextBox ID="txt_assign_studentid" CssClass="txtbox" runat="server" 
                AutoPostBack="True" ontextchanged="txt_assign_studentid_TextChanged"></asp:TextBox></td>
   </tr>
   <tr>
        <td class="td_b_11">Book Name :</td>
        <td class="td_b_22"><asp:TextBox ID="txt_assign_bookname" ReadOnly="true" BackColor="#dddddd"  CssClass="txtbox" runat="server"></asp:TextBox></td>
        <td class="td_b_11">Student Name :</td>
        <td class="td_b_22"><asp:TextBox ID="txt_assign_studentname" ReadOnly="true" BackColor="#dddddd"  CssClass="txtbox" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="td_b_11">Book Quantity :</td>
        <td class="td_b_22"><asp:TextBox ID="txt_assign_bookqty" ReadOnly="true" BackColor="#dddddd"  CssClass="txtbox" runat="server"></asp:TextBox></td>
        <td class="td_b_11">Student Branch :</td>
        <td class="td_b_22"><asp:TextBox ID="txt_assign_studentbranch" ReadOnly="true" BackColor="#dddddd"  CssClass="txtbox" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="td_b_11_last">Assigning Date :</td>
        <td class="td_b_22_last"><asp:TextBox ID="txt_assign_bookdate" CssClass="txtbox" ReadOnly="true" BackColor="#dddddd" runat="server"></asp:TextBox></td>
        <td class="td_b_11_last">Student Year :</td>
        <td class="td_b_22_last"><asp:TextBox ID="txt_assign_studentyear" ReadOnly="true" BackColor="#dddddd"  CssClass="txtbox" runat="server"></asp:TextBox></td>
      </tr>
  </table>
  </div>
  <br />
  <div align="center">
   <asp:Button ID="btn_Assign" runat="server" CssClass="btn" Text="Assign" 
          onclick="btn_Assign_Click" />
    <asp:Button ID="btn_Reset" runat="server" CssClass="btn" Text="RESET" />
    <asp:Button ID="btn_Cancel" runat="server" CssClass="btn" Text="CANCEL" />
  </div>
  <br />
  <asp:Label ID="lblresult_bookassign" runat="server"></asp:Label>
 </div>
</asp:Content>

