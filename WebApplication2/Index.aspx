<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>easwdev@gmail.com - Eli Arad</title>
    <base href="/" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <script type="text/javascript" src="Scripts/jquery-2.2.2.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css"/>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui-router.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-cookies.min.js"></script>
    <script type="text/javascript" src="Client/app.js"></script>
    <script type="text/javascript" src="Client/routing.js"></script>
    <script type="text/javascript" src="Client/Controllers/homeController.js"></script>
        
    <script type="text/javascript" src="Client/Services/api.js"></script>

    <script type="text/javascript" src="Client/Directives/tableviewer.js"></script>
    <script type="text/javascript" src="Client/Directives/schema/uiengine.js"></script>
    <script type="text/javascript" src="Client/Directives/schema/employeeinfo.js"></script>



</head>
<body data-ng-app="app">
    <form id="form1" runat="server">
     <div data-ui-view="">

     </div>
    </form>
</body>
</html>
