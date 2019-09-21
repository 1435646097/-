<%@ Page Title="" Language="C#" MasterPageFile="~/Master/UserManagement.Master" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="BookShop.Web.UserCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Css/default.css" rel="stylesheet" />
    <script src="/js/handlers.js" type="text/javascript"></script>
    <script src="/js/swfupload.js" type="text/javascript"></script>
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/ashx/SWFUpLoad.ashx",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg",
                file_types_description: "JPG Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: showImage,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "/Images/SWFUpLoda/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">Select Images <span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: "/js/swfupload.swf",	// Relative to this file
                flash9_url: "/js/swfupload_FP9.swf",	// Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }
        function showImage(file, serverData) {
            var data = serverData.split(':');
            if (data[0] == "ok") {
                //$("#divContent").css("backgroundImage","url("+data[1]+")").css("width",data[2]+"px").css("height",data[3]+"px");
                $('#completeImg').attr('src', data[1]);
            } else {
                alert(data[1]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="header">
        <h1 id="logo"><a href="../">SWFUpload</a></h1>
        <div id="version">v2.5.0</div>
    </div>


    <div id="content">
        <h2>Application Demo (ASP.Net 2.0)</h2>

        <div id="swfu_container" style="margin: 0px 10px;">
            <div>
                <span id="spanButtonPlaceholder"></span>
            </div>
            <div id="divFileProgressContainer" style="height: 75px;"></div>
            <div id="thumbnails"></div>
        </div>
        <div id="background">
            <div id="photo"></div>
        </div>
</asp:Content>
