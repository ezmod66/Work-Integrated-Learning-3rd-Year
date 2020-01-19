<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daily_Attendance_Register.aspx.cs" Inherits="Homestead_Project.Daily_Attendance_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="JS_FILE.js"></script>
    <style type="text/css">
        #Detils {
            height: 171px;
        }
    </style>
</head>
<body style="background: url(leaf-background2.png) fixed;">
        <nav class="sidenav" tabindex="0">
        <header class="pic">
            <img src="logo.PNG" />
                <h3>Welcome</h3>
        </header>
        <ul class="mainmenu">
           <li>
                <a href="HOME_PAGE.aspx">Home</a>
           </li>
            <li><a href="#">Children Details</a>
               <ul class="submenu">
                    <li><a href="View_Child_Details.aspx">View Children Details</a></li>
                    <li><a href="Add_Child_Details.aspx">Add New Child</a></li>
                    <li><a href="Update_Child_Details.aspx">Update Child Details</a></li>
               </ul>
            </li>
            <li> <a href="#">Attendance</a>
                  <ul class="submenu">
                    <li><a href="Daily_Attendance_Register.aspx">Record Daily Attendance</a></li>
                    <li><a href="AttendanceRecord_Per_Child.aspx">View Attendance Sheet Per child</a></li>
                    <li><a href="Monthly_Attendance_Report.aspx">View Montly Attendance Sheet</a></li>
                </ul>
            </li>
            <li><a href="Activities.aspx">Activities</a>
                  <ul class="submenu">
                    <li><a href="Activity_Attendance_Register.aspx">View Activity Attendance Report</a></li>
                </ul>
            </li>
            <li><a href="Planner.aspx">Planner</a>
                <ul class="submenu">
                    <li><a href="testing.aspx">View Planner</a></li>
                    <li><a href="testing.aspx">View Birthdays</a></li>
                    <li><a href="testing.aspx">View Notifications</a></li>
                </ul>
            </li>
            <li>
                <a href="Point_System.aspx">Points</a>
           </li>
            <li>
                <a href="Register_New_User.aspx">Register New User</a>
            </li>
            <li>
                <a href="Report.aspx">Report</a>
            </li>
            <li>
                <a href="LOG_IN.aspx">Log Out</a>
            </li>
        </ul>
    </nav>
    <div class="main">
        <div class="hero-image">
            <h1 class="heading">Daily Attendance Register</h1>
        </div>
        <form id="form1" runat="server">
            <div class="point-box">
                <div class="container">
                    <h4>Daily Attendance Register</h4>
                    <hr />

                    <div id="status type">
                    </div>
                    <br />
                    <br />
                    <div id="search">


                        <br />

                        <asp:Label ID="Label1" runat="server" Text="Current date:"> </asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="True" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" Width="1200px">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Update" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="File number">
                                    <ItemTemplate>
                                        <asp:Label ID="fileNumber" Text='<%#Eval("fileNumber") %>' runat="server" />


                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Child Name">
                                    <ItemTemplate>
                                        <asp:Label ID="name" Text='<%#Eval("childName") %>' runat="server" />


                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Child Surname">
                                    <ItemTemplate>
                                        <asp:Label ID="surname" Text='<%#Eval("childSurname") %>' runat="server" />


                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Attandence Status">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="dropAttendace" runat="server">
                                    
                                        </asp:DropDownList>
                                    </EditItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField>
                                     <EditItemTemplate>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button runat="server" Text="SAVE" CssClass="buttons" ID="btnSave" OnClick="btnSave_Click" />
                    </div>
                </div>
        </form>
    </div>

</body>
</html>


