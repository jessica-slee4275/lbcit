<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>lbcit - Jessica Lee</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
  
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <table id="mytable" class="table table-condensed">
            <thead>
                <tr>
                    <th>Month</th>
                    <%foreach (var s in Series) {%> 
                        <th><%= s.Key %></th>
                    <%} %>
                </tr>
            </thead>
            <tbody>
                <%foreach (string month in Categories) {%>
                    <tr>
                        <td><%= month %></td>
                        <td id ="country"></td>
                    </tr>
                <%  } %>

               
            </tbody>
        </table>
        </div>
    </form>
    <script src="//code.jquery.com/jquery.min.js"></script>
    <script>

       <%-- <%foreach (var s in Series) {%> 
            <%foreach (var data in s.Value) {%> 
                $('#country > td:last').append('<td><%= data %></td>');
            <%  } %>
        <%  } %>--%>
    </script>
</body>
</html>
