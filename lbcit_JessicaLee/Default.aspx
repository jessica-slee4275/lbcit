<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>lbcit - Jessica Lee</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <table id="mytable" class="table table-condensed">
            <thead>
                <tr>
                    <th>Month</th>
                    <%foreach (var name in Name) {%> 
                        <th><%= name %></th>
                    <%} %>
                </tr>
            </thead>
            <tbody>
                <%for(int i = 0; i< 12; i++) {%>
                    <tr>
                        <%for(int j = 0; j< 5; j++) {%>
                        <td><%=  ContentArr[i,j] %></td>
                         <%  } %>
                    </tr>
                <%  } %>
            </tbody>
        </table>
        </div>
    </form>
</body>
</html>
