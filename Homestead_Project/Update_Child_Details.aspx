﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_Child_Details.aspx.cs" Inherits="Homestead_Project.Update_Child_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
     <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="JS_FILE.js"></script>
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
			<h1 class="heading">Update Children Details</h1>
        </div>
        
            <form id="form1" runat="server">
               
        <div class="form">
             <div class="container">
                        <div id="search">
                   
                           	<asp:Label runat="server" Text="Child Name" CssClass="h"/>
								
                                <asp:DropDownList runat="server" CssClass="textInputs" ID="cbChildNames" OnSelectedIndexChanged="cbChildNames_SelectedIndexChanged" AutoPostBack="true"/>
								<asp:Label ID="LblReport" runat="server"></asp:Label>
								<br/>
								<asp:Label runat="server" Text="Choose child name to view their details" CssClass="description" ID="txtTrue"/>
                                <asp:Label runat="server" CssClass="description" ID ="txtUpdatingError"/>
                        </div>
                        </div>
            <fieldset>
               
                 <div><legend><span class="number">1</span> Personal Details</legend></div>
                   <div class="inner-wrap">
                       <asp:Label runat="server" text="File Number: " CssClass="label"/>
                <asp:Textbox runat="server" ID="txtFileNumber" CssClass="textInputs"/>
                <asp:Label runat="server" text="First Name: " CssClass="label"/>
                <asp:Textbox runat="server" ID="txtFirstName" CssClass="textInputs"/>
               
                <asp:Label runat="server" text="Surname: " CssClass="label" />
                <asp:Textbox runat="server" ID="txtSurnname" CssClass="textInputs" />
                </br>
                <asp:Label runat="server" text="Date Of Birth" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtDOB" CssClass="textInputs" />
                </br>
                <asp:Label runat="server" text="Gender" CssClass="label"/>
                <asp:dropdownlist id="cbGender" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbGender_SelectedIndexChanged" AutoPostBack="true">
                   
                </asp:dropdownlist>
                </br>
                <asp:Label runat="server" text="Nationality" CssClass="label"/>
                <asp:dropdownlist id="cbNationality" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbNationality_SelectedIndexChanged" AutoPostBack="true">
                </asp:dropdownlist>
                </br>
                <asp:Label runat="server" text="Legal Status in SA" CssClass="label"/>
                <asp:dropdownlist id="cbLegalStatus" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbLegalStatus_SelectedIndexChanged" AutoPostBack="true">
                </asp:dropdownlist>
                </br>
                <asp:Label runat="server" text="Facilities" CssClass="label"/>
                <asp:dropdownlist id="cbFalicities" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbFalicities_SelectedIndexChanged" AutoPostBack="true"></asp:dropdownlist>
                </br>
             
                <asp:Label runat="server" text="School Name: " CssClass="label" />
                <asp:Textbox runat="server" ID="txtSchoolName" CssClass="textInputs" />
                </br>
                <asp:Label runat="server" text="School Contact Number: " CssClass="label" />
                <asp:Textbox runat="server" ID="txtSchoolContactNumber" CssClass="textInputs" />
                </br>
            </div>
                </fieldset>

            <fieldset>
           
                 <legend><span class="number">2</span> Family Details</legend>
              <div class="inner-wrap">
                 </br>
               <asp:Label  runat="server" text="Relationship to Child: " CssClass="label"/>
                 
            <asp:dropdownlist id="cbRelationship" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbRelationship_SelectedIndexChanged" AutoPostBack="true">
            </asp:dropdownlist>
                 </br>
            <asp:Label runat="server" text="First Name" CssClass="label"/>
            <asp:Textbox runat="server" ID="txtFamilyFirstName" CssClass="textInputs" />
                 </br>
            <asp:Label runat="server" text="Surname" CssClass="label"/>
            <asp:Textbox runat="server" ID="txtFamilySurname" CssClass="textInputs"/>
            
                 </br>
                <asp:Label runat="server" text="Gender" CssClass="label"/>
                <asp:Dropdownlist id="cbFamilyGender" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbFamilyGender_SelectedIndexChanged"></asp:Dropdownlist>
                    </br>
                     <asp:Label runat="server" text="Nationality" CssClass="label"/>
                <asp:dropdownlist id="cbFamilyNationality" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbFamilyNationality_SelectedIndexChanged" AutoPostBack="true">
                </asp:dropdownlist>
                </br>
            <asp:Label runat="server" text="Contact Number" CssClass="label"/>
            <asp:Textbox runat="server" ID="txtFamilyContactNumber" CssClass="textInputs"/>
                 </br>
                   <asp:Label runat="server" text="Extra Notes" CssClass="label"/>
            <asp:Textbox runat="server" ID="txtExtraNotes" CssClass="textInputs"/>
              <div class="inner-wrap">
                <h3>Address</h3>
                <asp:Label runat="server" text="House Number" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtHouseNumber" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Street Address" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtStreetName" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Surburb" CssClass="label" />
                <asp:Textbox runat="server" ID="txtSuburb" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Town" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtTown" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Postal Code" CssClass="label" />
                <asp:Textbox runat="server" ID="txtPostalCode" CssClass="textInputs" />
                </br>
                 <asp:Label runat="server" text="Province" CssClass="label" />
                <asp:Textbox runat="server" ID="txtProvince" CssClass="textInputs" />
                </br>
            </div>
            </div>
    
                </fieldset>
           
            <fieldset>
                <legend><span class="number">3</span> Admin Details</legend>
                <div class="inner-wrap">
           <asp:Label runat="server" text="Date Of Admmisiion" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtAdmissionDate" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Discharge Date" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtDischargeDate" CssClass="textInputs" />
                </br>
                <asp:Label runat="server" text="Years in shelter" CssClass="label"/>
                <asp:Label runat="server" ID="txtYearsInShelter" CssClass="textInputs"/>
                </br>
                <asp:Label runat="server" text="Statutory Type" CssClass="label"/>
                <asp:dropdownlist runat="server" ID="cbStatutory" CssClass="textInputs" OnSelectedIndexChanged="cbStatutory_SelectedIndexChanged" AutoPostBack="true"></asp:dropdownlist>
                </br>
                <asp:Label runat="server" text="Court Order Date" CssClass="label"/>
                <asp:Textbox runat="server" ID="txtCourtOrderExpires" CssClass="textInputs"/>
               
                </br>
                <asp:Label runat="server" text="Social Worker" CssClass="label"/>
                <asp:dropdownlist runat="server" ID= "cbSWorker" CssClass="textInputs" OnSelectedIndexChanged="cbSWorker_SelectedIndexChanged" AutoPostBack="true">          
                </asp:dropdownlist>
                </br>
                   <asp:Label runat="server" text="Childcare Worker" CssClass="label"/>
                <asp:dropdownlist runat="server" ID ="cbCWorker" CssClass="textInputs" OnSelectedIndexChanged="cbCWorker_SelectedIndexChanged" AutoPostBack="true">
                </asp:dropdownlist>
                </br>
            </div>
            </fieldset>
           
           <asp:Button runat="server" text="Update" id="btnUpload" CssClass="submitButton" OnClick="btnUpload_Click" />
       

        </div>
    </form>
    </div>

</body>
</html>
