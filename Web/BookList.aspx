<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MianForm.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="BookShop.Web.BookList" %>

<%@ Import Namespace="BookShop.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%foreach (Book book in list)
        {

    %>
    <table>
        <tbody>
            <tr>
                <td rowspan="2"><a
                    onclick="window.location='BookDetail.aspx?bid=4939'">
                    <img
                        style="cursor: help" height="121"
                        alt="<%=book.Title %>" hspace="4 "
                        src="/Images/BookCovers/<%=book.ISBN %>.jpg" width="95"></a>
                </td>
                <td style="font-size: small; color: red" width="650"><a
                    class="booktitle" id="link_prd_name"
                    href="BookDetail.aspx?bid=4939" target="_blank"
                    name="link_prd_name"><%=book.Title %></a> </td>
            </tr>
            <tr>
                <td align="left"><span
                    style="font-size: 12px; line-height: 20px"><%=book.Author %></span><br>
                    <br>
                    <span
                        style="font-size: 12px; line-height: 20px"><%=CutContent(book.AurhorDescription,150) %></span>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2"><span
                    style="font-weight: bold; font-size: 13px; line-height: 20px">&yen; 
                        99.0000</span> </td>
            </tr>
        </tbody>
    </table>
    <hr />
    <%} %>
</asp:Content>
