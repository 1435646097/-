<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MianForm.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="BookShop.Web.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
        .txtInput {
            height: 26px;
            line-height: 26px;
            border: 1px #ccc solid;
            margin-bottom: 5px;
            width: 200px;
        }

        .regnow {
            width: 300px;
            margin-left: 30px;
            height: 40px;
            background: #db2f2f;
            border: none;
            color: #FFF;
            font-size: 15px;
            font-weight: 700;
            cursor: pointer;
        }
    </style>
    <script src="/js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //验证用户木是否合法对码
            $('#userName').blur(function () {
                validateUserName(this);
            });
            //验证邮箱是否合法
            $('#userEmail').blur(function () {
                validateEmail(this);
            });
            //切换验证码
            $("#vCode").click(function () {
                $("#imgCode").attr("src", $("#imgCode").attr("src") + 1);
            });
            $('#txtVcode').blur(function () {
                validateCode(this);
            });
            //验证真实姓名
            $('#txtRealName').blur(function () {
                validateRealName(this);
            });
            //注册用户
            $('#btnReg').click(function () {
                var param = $('#aspnetForm').serializeArray();
                $.post('/ashx/validete.ashx?type=register', param, function (data) {
                    //alert(data.ok);
                    //alert(data.no);
                    //if (data.ok != '') {
                    //    window.location="/Login.aspx"
                    //} else {
                    //    alert(data.no);
                    //}
                    var msg = data.split(':');
                    if (msg[0] == 'ok') {
                        window.location = "/Login.aspx";
                    } else {
                        alert(msg[1]);
                    }
                });
            });
        });
        //验证邮箱是否合法
        function validateEmail(control) {
            if ($(control).val() == '') {
                $('#email').text('邮箱不能为空');
            }
            else {
                var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                if (regex.test($(control).val())) {
                    $.post('/ashx/validete.ashx?type=userEmail', { 'userEmail': $(control).val() }, function (data) {
                        if (data == 'ok') {
                            $('#email').text('邮箱已被占用');
                        } else {
                            $('#email').text('邮箱可用');
                        }
                    })
                }
                else {
                    $('#email').text('请输入正确的邮箱');
                }
            }
        }
        //验证用户名是否合法
        function validateUserName(control) {
            if ($(control).val() == '') {
                $('#valideteUserName').text('用户名不能为空');
            }
            else {
                var regex = /^[a-zA-Z0-9_\u4e00-\u9fa5]{4,20}$/;
                if (regex.test($(control).val())) {
                    $.post('/ashx/validete.ashx?type=userName', { 'userName': $(control).val() }, function (data) {
                        if (data == 'ok') {
                            $('#valideteUserName').text('用户名已被占用');
                        } else {
                            $('#valideteUserName').text('可用');
                        }
                    })
                }
                else {
                    $('#valideteUserName').text('用户名只能是数字，汉字与英文字母');
                }
            }
        }
        //判断验证码是否正确
        function validateCode(control) {
            var text = $(control).val();
            if (text == '') {
                $('#valideteCode').text('验证码不能为空');
            }
            else {
                var regex = /^\d{5}$/;
                if (regex.test(text)) {
                    $.post('/ashx/validete.ashx?type=vCode', { 'vCode': text }, function (data) {
                        if (data == 'ok') {
                            $('#valideteCode').text('验证码正确');
                        } else {
                            $('#valideteCode').text('验证码错误');
                        }
                    })
                }
                else {
                    $('#valideteCode').text('验证码格式错误');
                }
            }
        }
        //验证真实姓名
        function validateRealName(control) {
            var text = $(control).val();
            if (text != '') {
                var regex = /^[\u4e00-\u9fa5]+$/
                if (regex.test(text)) {
                    $('#RealName').text('可用');
                } else {
                    $('#RealName').text('请输入真实姓名');
                }
            } else {
                $('#RealName').text('真实姓名不能为空');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: small">
        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 10px">
                    <img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
                <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
                <td width="10">
                    <img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
            </tr>
        </table>


        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
                <td>
                    <div align="center">
                        <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
                            <tr>
                                <td height="33" colspan="6">
                                    <p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
                                <td valign="top" width="37%" align="left" style="height: 26px">
                                    <input id="userName" class="txtInput" type="text" name="txtUserName" placeholder="用户名" />
                                    <span id="valideteUserName" style="font-size: 14px; color: red"></span></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
                                <td valign="top" width="37%" align="left">
                                    <input id="txtRealName" class="txtInput" type="text" name="txtRealName" placeholder="真实姓名" />
                                    <span id="RealName" style="font-size: 14px; color: red"></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input class="txtInput" type="text" name="txtPwd" placeholder="密码" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">确认密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input class="txtInput" type="text" name="txtConfirmPwd" placeholder="确认密码" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">Email：</td>
                                <td valign="top" width="37%" align="left">
                                    <input id="userEmail" class="txtInput" type="text" name="txtEmail" placeholder="邮箱" /><span id="email" style="font-size: 14px; color: red"></span></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">地址：</td>
                                <td valign="top" width="37%" align="left">
                                    <input class="txtInput" type="text" name="txtAddress" placeholder="地址" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">手机：</td>
                                <td valign="top" width="37%" align="left">
                                    <input class="txtInput" type="text" name="txtPhone" placeholder="手机" /></td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">验证码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input id="txtVcode" class="txtInput" type="text" name="txtVcode" placeholder="不区分大小" />
                                    <span id="valideteCode" style="font-size: 14px; color: red"></span></td>
                                <td>
                                    <a href="javascript:void(0)" id="vCode">
                                        <img src="/ashx/ValidateCode.ashx?id=1" id="imgCode" /></a>
                                    <span id="vcodeMsg" style="font-size: 14px; color: red"></span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <input type="button" value="同意协议并注册" id="btnReg" class="regnow" /></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">&nbsp;</td>
                            </tr>
                        </table>
                        <div class="STYLE5">---------------------------------------------------------</div>
                    </div>
                </td>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
            </tr>
        </table>

        <table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3" bgcolor="#DDDDCC">
                    <img src="../Images/touming.gif" width="27" height="9" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
