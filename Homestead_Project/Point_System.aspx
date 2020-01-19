<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Point_System.aspx.cs" Inherits="Homestead_Project.Point_System" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Points</title>
   <meta name="viewport" content="width=device-width, initial-scale=1"/>
	     <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
        <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="JS_FILE.js"></script>
</head>
<body  style="background: url(leaf-background2.png) fixed;">
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
			<h1 class="heading">Points System</h1>
        </div>
        <form id="form1" runat="server">
            <div class="point-box">
                <!-- View Child History Section-->
                <asp:Button runat="server" Text="View Points History" ID="ViewHistory" CssClass="submitButton" OnClick="ViewHistory_Click" />
                <div id="gridViewData" runat="server" visible="false" class="container" >
                    <h1>View Child Points History</h1>

                    <div id="wrapper">

                    <div id="SearchHistoryByFileNumber" runat="server" class="searchHistory">
                        <h6>Enter Child File Number:</h6>
                        <asp:TextBox ID="SearchBoxId" runat="server" CssClass="input-text" BorderWidth="1px" />
                        <asp:Button runat="server" Text="Search" ID="Button1" OnClick="Search_Click" CssClass="buttons" BorderWidth="1px" Height="35px" Width="150px"/>
                         <asp:Button runat="server" Text="Reset Search" ID="btnReset" OnClick="btnReset_Click" BorderWidth="1px" CssClass="buttons" Height="35px" Width="150px"/>
                    </div>
                                             
                        <div id="dropDownListHistoryFacilityOrdering" runat="server" class="combo-box" visible ="false" overflow>
                            <asp:Label ID="sortByFacilityHistory" runat="server" text="Sort By Facility: "/>         
                            <asp:DropDownList ID="DropDownOrderbyCriteria" runat="server" OnSelectedIndexChanged="DropDownOrderbyCriteria_SelectedIndexChanged" CssClass="combobox" AutoPostBack="true"/>                       
                       </div>
                     </div>
                    
                    <hr style="width: 800px; height: -12px;" title="dsf" />
                    <div overflow: auto;"> 
                    <asp:GridView ID="PointsSystemGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." AllowSorting="True" allowpaging="True" >
                        <Columns>
                            <asp:BoundField DataField="fileNumber" HeaderText="File Number" />
                            <asp:BoundField DataField="childName" HeaderText="Name" />
                            <asp:BoundField DataField="childSurname" HeaderText="Surname" />
                            <asp:BoundField DataField="activityDate" HeaderText="Activity Date" />
                            <asp:BoundField DataField="activityDescription" HeaderText="Activity Name" />
                            <asp:BoundField DataField="allocatedPointValue" HeaderText="Point Change" />
                            <asp:BoundField DataField="reasonForPoints" HeaderText="Point Change Reason" />
                        </Columns>
                    </asp:GridView>
                               </div>         
                    <hr style="width: 800px;" title="dsf" />
                </div>
                <!--Search for child total points section-->
                 <br />
                <br />
                <br />
                <asp:Button ID="ModifyPoints" runat="server" Text="View Total Points" OnClick="ModifyPoints_Click" CssClass="submitButton"/>

                <div id="ViewTotalPoints" runat="server" visible="false" class="container">
                    <h1>View Child Total Points</h1>
                    <asp:Label ID="TotalPointsLbl" runat="server" Text="Enter File Number"></asp:Label>
                    <asp:TextBox ID="TotalPointsTxtBox" runat="server" CssClass="input-text" BorderWidth="1px" />
                    <asp:Button ID="SearchForChildTotalPoints" runat="server" Text="Search" OnClick="SearchForChildTotalPoints_Click" CssClass="button"/>
                      <br />              
                <br />
                <br />
                    <hr style="width: 800px; height: -12px;" title="dsf" />
                    <asp:GridView ID="TotalPointsGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:BoundField DataField="fileNumber" HeaderText="File Number" />
                            <asp:BoundField DataField="childName" HeaderText="Child Name" />
                            <asp:BoundField DataField="childSurname" HeaderText="Child Surname" />
                            <asp:BoundField HeaderText="Total Points" DataField="Total Points" />
                        </Columns>
                    </asp:GridView>
                    <hr style="width: 800px;" title="dsf" />
                </div>

                <!--Modify child points-->
                <br />
                <br />
                <br />
                <asp:Button ID="modifyPointsBtn" runat="server" Text="Modify Child Points" OnClick="ModifyPointsBtn_Click" CssClass="submitButton" />
                <div id="ModifyChildPoints" runat="server" visible="false" class="container">
                    <h1>Modify Child Points</h1>
                    <!--Modify child points headers-->
                    <asp:Label ID="lableModifyPointsfileNumber" runat="server" Text="Enter File Number"></asp:Label>
                    <asp:TextBox ID="TextBoxModifyPoints" runat="server" CssClass="input-text" BorderWidth="1px" />
                    <asp:Button ID="btnModifyPointsSeachChild" runat="server" Text="Search" OnClick="btnModifyPointsSeachChild_Click" CssClass="button"/>
                    <hr style="width: 800px; height: -12px;" title="dsf" />

                    <!--Modify child points GridView-->
                    <asp:GridView ID="GridViewModifyChildPoints" runat="server" 
                        OnRowCancelingEdit="GridViewModifyChildPoints_RowCancelingEdit" 
                        OnRowEditing="GridViewModifyChildPoints_RowEditing" 
                        OnRowUpdating="GridViewModifyChildPoints_RowUpdating" AutoGenerateColumns="False">

                        <Columns>  
                            
                            <asp:TemplateField HeaderText="PointNumber">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("pointsID") %>' runat ="server" ID="apointNumber"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="File Number">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("fileNumber") %>' runat ="server" ID="allabelfileNumber"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childName") %>' runat ="server" ID="labelchildName"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Surname">
                            <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("childSurname") %>' runat ="server" ID="LabelSurname"/>
                            </ItemTemplate>
                                </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Activity Date">
                            <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("activityDate") %>' runat ="server" ID="LabelActivityDate"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Points">
                                <ItemTemplate >
                                    <asp:Label ID="labelPoints" Text='<%# Eval("allocatedPointValue") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxPoints" Text= '<%# Eval("allocatedPointValue") %>' runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modify Options">
                                <ItemTemplate>
                                <asp:Button ID="btnModifyPointsEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="buttons" Height="30px" Width="80px"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnModifyPointsSave" runat="server" Text="Update" CommandName="Update" CssClass="buttons" Height="30px" Width="80px"/>
                                    <asp:Button ID="btnModifyPointsCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="buttons" Height="30px" Width="80px"/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                    <hr style="width: 800px;" title="dsf" />
                </div>

            </div>
            <div>
            </div>
        </form>
 </div>
    
</body>
</html>

