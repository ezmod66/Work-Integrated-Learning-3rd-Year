<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activity_Attendance_Register.aspx.cs" Inherits="Homestead_Project.Activity_Attendance_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
        <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="JS_FILE.js"></script>
    <style type="text/css">
        #search {
            height: 317px;
            width: 1215px;
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
			<h1 class="heading">WECLOME TO THE ACTIVITY ATTENDANCE PAGE</h1>
        </div>
        <form id="form1" runat="server">
            <div class="point-box">
                <div class="container" >
                
                    <h4>- Create an Attendance List: Add an attendance register for children attending the activity </h4>
                    <h4>- View the Attendance List: view any existing attendance as well as update it</h4>
                   
                    <hr style="width:800px;"/>
                    <br />
                    
                       

                        <asp:Button ID="childrenList" runat="server" Text="Create an Attendance List" OnClick="childrenList_Click" CssClass="buttons" Height="40px" Width="280px"/>
                        <br />
                        <br />
                        <asp:Button ID="childAttendanceList" runat="server" Text="View Attendance List"  OnClick="childAttendanceList_Click" CssClass="buttons" Height="40px" Width="280px"/>
                        <br />
                        <br />
                        <asp:Button ID="exitBtn" runat="server" Text="Exit" OnClick="exitBtn_Click" CssClass="buttons" Height="40px" Width="280px" />

                    
                    <asp:Label runat="server"  ID="aDateLbl" CssClass="labels" Text="Date: " Visible="false"/>
                    <asp:dropdownlist runat="server" CssClass="combo-box" ID="addDateActivityOption" AutoPostBack="True" OnSelectedIndexChanged="addDateActivityOption_SelectedIndexChanged" Visible="false">
                    </asp:dropdownlist>
                        &nbsp;&nbsp;
                    <asp:Label runat="server" ID="aActivityLbl" Text="Activity Name: " CssClass="labels" Visible="false"/>
                    <asp:dropdownlist runat="server" CssClass="combo-box" ID="addActivityOption" AutoPostBack="True" Visible="false">
                    </asp:dropdownlist>
                    <br/>
                    <br/>
                    <br/>
                    <asp:GridView ID="listOfChildren" runat="server" AutoGenerateColumns ="False" 
                        ShowHeaderWhenEmpty = "True" Visible = "False" OnRowDataBound="listOfChildren_RowDataBound" OnRowEditing="listOfChildren_RowEditing" OnRowCancelingEdit="listOfChildren_RowCancelingEdit" OnRowUpdating="listOfChildren_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText ="Child Name">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childName") %>' runat ="server" ID="achildName"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="Child Surname">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childSurname") %>' runat ="server" ID="aChildSurname"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="Attendance">
                                <ItemTemplate>
                                    <asp:Label ID="attendanceTxt" runat="server" ReadOnly="true"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="listOfAttendanceOptions" CssClass="combo-box" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                           </asp:TemplateField>        
                            <asp:TemplateField HeaderText="Enter the attendance">
                                <ItemTemplate>
                                    <asp:Button ID="editBtn" runat="server" Text="Enter" CommandName="Edit" CssClass="buttons" Height="30px" Width="80px"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                <asp:Button ID="saveBtn" runat="server" Text="Save" CommandName="Update" CssClass="buttons" Height="20px" Width="80px"/>
                                    <br />
                                    <br />
                                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CommandName="Cancel" CssClass="buttons" Height="20px" Width="80px"/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                    <br/>
                        <asp:Button ID="saveAttendanceBtn" runat="server" Text="Add Attendance" cssClass="buttons" Visible ="false" OnClick="saveAttendanceBtn_Click" Height="40px" Width="280px"/>
                    <br />
                    <br />
                    <asp:Button ID="btnCancelView" runat="server" Text="Cancel" cssClass="buttons" Visible ="false" OnClick="cancelView_CLICK" Height="40px" Width="280px"/>

                    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectString %>" SelectCommand="[childName], [childSurname] FROM [tbl_Child] ORDER BY [childName]"></asp:SqlDataSource>
                   
             
                   <asp:Label runat="server"  ID="uDateLbl" CssClass="labels" Text="Date: " Visible="false"/>
                   <asp:dropdownlist runat="server" CssClass="combo-box" ID="updateActivityDateOption" AutoPostBack="True" OnSelectedIndexChanged="updateActivityDateOption_SelectedIndexChanged" Visible="false">
                   </asp:dropdownlist>
                   &nbsp;&nbsp;
                   <asp:Label runat="server" ID="uActivityLbl" Text="Activity Name: " CssClass="labels" Visible="false"/>
                   <asp:dropdownlist runat="server" CssClass="combo-box" ID="updateActivityOption" Visible="false">
                   </asp:dropdownlist>
                       <br/>
                    <br />
                       <asp:Button ID="searchAttendanceBtn" runat="server" Text="Search" CssClass="buttons" Visible="false" OnClick="searchAttendanceBtn_Click" Height="40px" Width="280px"/>
                       <br/>
                      
                       <h4><asp:Label ID="AttendanceHeadingLbl" runat="server" Text="Attendance Result" Visible="false"></asp:Label></h4>
                 <h4><asp:Label ID="attendHeadDateLbl" runat="server" Text="Attendance Date:" Visible="false"></asp:Label></h4><h4><asp:Label ID="attendanceDateLbl" runat="server" Text="" Visible="false"></asp:Label></h4><h4><asp:Label ID="attendHeadActivityLbl" runat="server" Text="Activity:" Visible="false"></asp:Label></h4><h4><asp:Label ID="attendanceActivityLbl" runat="server" Text="" Visible="false"></asp:Label></h4> 
                   <br/>
                   <br/>
                   <asp:GridView ID="attendanceList" runat="server" AutoGenerateColumns ="False" 
                        ShowHeaderWhenEmpty = "True" Visible = "False" OnRowCancelingEdit="attendanceList_RowCancelingEdit" OnRowDataBound="attendanceList_RowDataBound" OnRowEditing="attendanceList_RowEditing" OnRowUpdating="attendanceList_RowUpdating">
                       <Columns>
                            <asp:TemplateField HeaderText ="Child Name">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childName") %>' runat ="server" ID="uChildName"/>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText ="Child Surname">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childSurname") %>' runat ="server" ID="uChildSurname"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="Attendance Status">
                                <ItemTemplate>
                                    <asp:Label ID="uAttendanceTxt" runat="server" Text = '<%# Eval("reasonForPoints") %>' ReadOnly="true"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="uListOfAttendanceOptions"  runat="server" CssClass="combo-box">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                           </asp:TemplateField>     
                           <asp:TemplateField HeaderText ="Points been Made">
                                <ItemTemplate>
                                    <asp:Label ID="uPointsTxt" runat="server" Text = '<%# Eval("allocatedPointValue") %>' ReadOnly="true"></asp:Label>
                                 </ItemTemplate>
                           </asp:TemplateField> 
                           <asp:TemplateField HeaderText=" Activity Change(Correct the child's attendance)">
                                <ItemTemplate>
                                    <asp:Label ID="activityUpdateTxt" runat="server" Text="No" ReadOnly="true"></asp:Label>
                                </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Update the attendance">
                                <ItemTemplate>
                                    <asp:Button ID="updateBtn" runat="server" Text="Update" CommandName="Edit"  CssClass="buttons" Height="20px" Width="80px"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                <asp:Button ID="saveUpdateBtn" runat="server" Text="Save" CommandName="Update"  CssClass="buttons" Height="20px" Width="80px"/>
                                <asp:Button ID="Button1" runat="server" Text="Cancel" CommandName="Cancel"  CssClass="buttons" Height="20px" Width="80px"/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                        <br/>
                        <asp:Button ID="updateAttendanceBtn" runat="server" Text="Save Changes" cssClass="submitButton" Visible="false" OnClick="updateAttendanceBtn_Click"/>
                    <br />
                     <asp:Button ID="btnUpdateCancel" runat="server" Text="Cancel" cssClass="buttons" Visible ="false" OnClick="cancelUpdate_Click" Height="40px" Width="280px"/>
                       <asp:SqlDataSource ID="childAttendanceData" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectString %>" SelectCommand="SELECT tbl_Child.childName, tbl_Child.childSurname, tbl_Points.reasonForPoints, tbl_Points.allocatedPointValue FROM tbl_Points INNER JOIN tbl_Child ON tbl_Points.fileNumber = tbl_Child.fileNumber ORDER BY tbl_Child.childName"></asp:SqlDataSource>
                    </div>                        

                                                               
           
          </div>
        </form>
    </div>
    
</body>
</html>
