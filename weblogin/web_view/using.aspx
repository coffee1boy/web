<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="using.aspx.cs" Inherits="WebApplication2._using" %>

<!DOCTYPE html>
<!-- saved from url=(0052)http://172.16.13.32/dkl/sign_in/html/all_detail.html -->
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <title></title>
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <div id="listBox">
        
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;"><tbody><tr>
                        <th class="t1">序号</th>
                        <th class="t2">用户名</th>
                        <th class="t3">密码</th>
                        <th class="t3">学号</th>
                        <th class="t3">姓名</th>
                        <th class="t5">身份证</th>
                        <th class="t3">删除</th></tr><tr>
                        
                            <%for (int i = tables.Rows.Count - 1 ; i > -1;  --i)
          {
              
              string timeusername = tables.Rows[i]["Name"].ToString();
              if (timeusername == name)
              {
                  continue;
              }
              else
              { %>
                            
                        <td><%= i%></td>
                        <td><%=tables.Rows[i]["Name"].ToString()%></td>
                        <td><%=tables.Rows[i]["Mima"].ToString()%></td>
                        <td><%=tables.Rows[i]["Xuehao"].ToString()%></td>
                        <td><%=tables.Rows[i]["Xingming"].ToString()%></td>
                        <td><%=tables.Rows[i]["Shenfengzhen"].ToString()%></td>
                        </tr><tr>
                             <%} %>
        <%} %>
                       <th class="t3">个人信息</th>
                       </tr><tr>
                       <th class="t1">序号</th>
                       <th class="t2">用户名</th>
                       <th class="t3">密码</th>
                       <th class="t3">学号</th>
                       <th class="t3">姓名</th>
                       <th class="t5">身份证</th></tr><tr>
                       <td>1</td>
                       <td><%=name%></td>
                        <td><%=mima%></td>
                        <td><%=xuehao%></td>
                        <td><%=xingming%></td>
                        <td><%=shenfengzhen%></td>
                        
                            </tbody></table>
           <div style="clear:both;"></div>  
        </div>
    </div>
    <script>
        var week = 0;
        function next(week) {
            $.ajax({
                url: '../handler/info.ashx?info=All&week=' + week,
                type: 'post',
                success: function (re) {
                    table_left.innerHTML = re;
                }
            })
        }
        next(week);
    </script>
    <br>
    <br>
    <br>


</body></html>

