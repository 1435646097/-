<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MianForm.Master" AutoEventWireup="true" CodeBehind="CartInfo.aspx.cs" Inherits="BookShop.Web.CartInfo" %>

<%@ Import Namespace="BookShop.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script src="/js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        function changeBar(operator, Id, bookid) {
            var countControl = $('#' + bookid);
            var count = parseInt(countControl.val());
            if (count <= 0) {
                alert('商品数量不能为0');
                return;
            }
            if (count>=1000) {
                alert('商品数量不能大于1000');
                return;
            }
            if (operator == '+') {
                count += 1;
            } else {
                count -= 1;
            }
            $.post("/ashx/CartEdit.ashx", { 'action': 'edit', 'id': Id, 'count': count }, function (data) {
                if (data == 'ok') {
                    countControl.val(count);
                } else {
                    alert('更新异常');
                }
            })
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td colspan="2">
                    <img height="27"
                        src="images/shop-cart-header-blue.gif" width="206" /><img alt=""
                            src="Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server"
                                NavigateUrl="~/myorder.aspx">我的订单</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" width="98%">

                    <table cellpadding='0' cellspacing='0' width='100%'>
                        <tr class='align_Center Thead'>
                            <td width='7%' style='height: 30px'>图片</td>
                            <td>图书名称</td>
                            <td width='14%'>单价</td>
                            <td width='11%'>购买数量</td>
                            <td width='7%'>删除图书</td>
                        </tr>
                        <!--一行数据的开始 -->
                        <%foreach (Cart model in this.CartList)
                            {
                        %>
                        <tr class='align_Center'>
                            <td style='padding: 5px 0 5px 0;'>
                                <img src='images/bookcovers/<%=model.Book.ISBN %>.jpg' width="40" height="50" border="0" /></td>
                            <td class='align_Left'><%=model.Book.Title %></td>
                            <td>
                                <span class='price'><%=model.Book.UnitPrice %></span>
                            </td>
                            <td><a href='#none' title='减一' onclick="changeBar('-','<%=model.Id %>','<%=model.Book.Id %>')" style='margin-right: 2px;'>
                                <img src="Images/bag_close.gif" width="9" height="9" border='none' style='display: inline' /></a>
                                <input type='text' id='<%=model.Book.Id %>' name='<%=model.Book.Id %>' maxlength='3' style='width: 30px' onkeydown='if(event.keyCode == 13) event.returnValue = false' value='<%=model.Count %>' onfocus='changeTxtOnFocus();' onblur="changeTextOnBlur();" />
                                <a href='#none' title='加一' onclick="changeBar('+','<%=model.Id %>','<%=model.Book.Id %>')" style='margin-left: 2px;'>
                                    <img src='/images/bag_open.gif' width="9" height="9" border='none' style='display: inline' /></a>   </td>
                            <td>
                                <a href='#none' id='btn_del_1000357315' onclick="removeProductOnShoppingCart()">删除</a></td>
                        </tr>
                        <!--一行数据的结束 -->
                        <%} %>
                        <tr>
                            <td class='align_Right Tfoot' colspan='5' style='height: 30px'>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">&nbsp;&nbsp;&nbsp; 商品金额总计：<span id="totleMoney">0</span>元</td>
                <td>&nbsp;
               <a href="booklist.aspx">
                   <img alt="" src="Images/gobuy.jpg" width="103" height="36" border="0" />
               </a><a href="OrderConfirm.aspx">
                   <img src="images/balance.gif"
                       border="0" /></a>

                </td>
            </tr>
        </table>
    </div>

</asp:Content>
