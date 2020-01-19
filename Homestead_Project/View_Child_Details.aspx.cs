using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class View_Child_Details : System.Web.UI.Page
    {
        SqlConnection SqlConn = null;
        string fileNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<ChildFullName> childnames = new DB_Manager().GetChildNames();
                if (childnames != null)
                {
                    cbNames.DataSource = childnames;
                    cbNames.DataTextField = "childFullname";
                    cbNames.DataValueField = "childID";
                    cbNames.DataBind();
                }
            }
            
        }

        private void MakeConnection()
        {
            // Getting the connection string from the web.config file
            //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\DBDemoDB.mdf; Integrated Security = True; Connect Timeout = 30";
            //string connectionString = @"Data Source = VCCT-STD-SQL01; Initial Catalog = 18199; Integrated Security = True";
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();
            // Only create new connection object if it does not already exists

            if (SqlConn == null)
            {
                SqlConn = new SqlConnection(connectionString);
            }
        }

        protected void cbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileNumber = cbNames.SelectedValue;
            ViewChildData(fileNumber);
        }


        public void ViewChildData(string fileNumber)
        {
            try
            {
                MakeConnection();
                string sqlString = "select tbl_Child.childName, tbl_Child.childSurname , tbl_Child.fileNumber, tbl_StatutoryType.statutoryDescription, tbl_Relationship.relationshipDescription, tbl_Facility.facilityName, tbl_Child.dateOfBirth, DATEDIFF(YEAR, tbl_Child.dateOfBirth, GETDATE()) AS Age,  tbl_Gender.genderDescription, tbl_School.schoolName, tbl_School.schoolContactNum, tbl_Nationality.nationalityDesc, tbl_LegalStatus.statusDescription, tbl_Family.firstName, tbl_Family.lastName, tbL_Family.contactNumber, tbl_Address.houseNumber, tbl_Address.streetName, tbl_Address.suburb, tbl_Address.town, tbl_Child.courtOrderExpirationDate, tbl_Child.admissionDate, tbl_Child.exitDate, DATEDIFF(YEAR, tbl_Child.admissionDate, tbl_Child.exitDate) AS YearsInShelter, "
                                + "(SELECT tbl_Employee.empFirstName FROM tbl_Employee, tbl_Child WHERE(tbl_Employee.empID = tbl_Child.socialWorkerID)  AND(tbl_Child.fileNumber = '" + fileNumber + "')) AS 'socialworker', "
                                + "(SELECT tbl_Employee.empFirstName FROM tbl_Employee, tbl_Child WHERE(tbl_Employee.empID = tbl_Child.childCareWorkerID) AND(tbl_Child.fileNumber = '" + fileNumber + "')) AS 'childcareworker' "
                                + "FROM tbl_Child, tbl_Gender, tbl_School, tbl_Nationality, tbl_LegalStatus, tbl_Family, tbl_Address, tbl_Facility, tbl_Relationship, tbl_StatutoryType "
                                + "WHERE(tbl_Child.schoolID = tbl_School.schoolID) AND(tbl_StatutoryType.statutoryID = tbl_Child.statutoryID) AND(tbl_Child.facilityID = tbl_Facility.facilityID) AND(tbl_Relationship.relationshipID = tbl_Family.relationshipToChild) AND(tbl_Child.nationalityID = tbl_Nationality.nationalityID) AND(tbl_Child.genderID = tbl_Gender.genderID) AND(tbl_Child.legalStatusID = tbl_LegalStatus.statusID) AND(tbl_Child.familyID = tbl_Family.familyMemberID) AND(dbo.tbl_Family.addressID = tbl_Address.addressID) AND tbl_Child.fileNumber = '" + fileNumber + "'";


                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    txtFullName.Text = row["childName"].ToString() + " " + row["childSurname"].ToString();
                    txtFileNumber.Text = row["fileNumber"].ToString();

                    DateTime dob = Convert.ToDateTime(row["dateOfBirth"].ToString());
                    txtDateOfBirth.Text = dob.ToString("dddd, dd MMMM yyyy");

                    txtAge.Text = row["Age"].ToString();
                    txtGender.Text = row["genderDescription"].ToString();
                    txtSchoolName.Text = row["schoolName"].ToString();
                    txtSchoolContactNumber.Text = row["schoolContactNum"].ToString();
                    txtNationalityChild.Text = row["nationalityDesc"].ToString();
                    txtLegalStatusChild.Text = row["statusDescription"].ToString();
                    txtFamilyName.Text = row["firstName"].ToString() + " " + row["lastName"].ToString();
                    txtRelationship.Text = row["relationshipDescription"].ToString();
                    txtContactNumber.Text = row["contactNumber"].ToString();
                    txtStreetAddress.Text = row["houseNumber"].ToString() + " " + row["streetName"].ToString();
                    txtSurburb.Text = row["suburb"].ToString();
                    txtTown.Text = row["town"].ToString();

                    DateTime courtDate = Convert.ToDateTime(row["courtOrderExpirationDate"].ToString());
                    txtCourtOrderDate.Text = courtDate.ToString("dddd, dd MMMM yyyy");

                    DateTime dischargeDate = Convert.ToDateTime(row["exitDate"].ToString());
                    txtDischargeDate.Text = dischargeDate.ToString("dddd, dd MMMM yyyy");

                    DateTime addmissionDate = Convert.ToDateTime(row["admissionDate"].ToString());
                    txtAddmissionDate.Text = addmissionDate.ToString("dddd, dd MMMM yyyy");

                    txtSocialWorkerName.Text = row["socialworker"].ToString();
                    txtChildCareWorkerName.Text = row["childcareworker"].ToString();
                    txtYearsInShelter.Text = row["YearsInShelter"].ToString();
                    txtFacility.Text = row["facilityName"].ToString();
                    txtStatutoryType.Text = row["statutoryDescription"].ToString();
                    
                }

            }
            catch (Exception ex)
            {
                txtSchoolName.Text = ex.ToString();
            }
        }

        protected void ViewAttendanceRecord(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceRecord_Per_Child.aspx");
        }
    }
}