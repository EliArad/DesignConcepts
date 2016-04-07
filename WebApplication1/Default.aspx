<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="row">
        <div class="col-md-4">
            
             <script type="text/javascript">  
                $(function () {              
                    $.ajax({
                        type: "POST",
                        data:"1",
                        contentType: "application/json; charset=utf-8",  
                        url: 'http://localhost/Service1.svc/GetData',
                        success: function (data) {  
                            alert(data);
                        },  
                        error: function (result) {  
                            alert(result);  
                        }  
                    });  
                });  
         </script>


        </div>
        <div class="col-md-4">
            
        </div>
         
    </div>

</asp:Content>
