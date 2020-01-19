using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Homestead_Project
{
    public class DB_Manager
    {
        SqlConnection SqlConn = null;
        //Employee employee = null;

 
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

        
        



        public SqlConnection MakeConnection(SqlConnection sqlConn)
        {
            // Getting the connection string from the web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();

            // Only create new connection object if it does not already exists
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(connectionString);
            }

            return sqlConn;
        }


        public List<Employee> userLogIn(string username, string password)
		{
			List<Employee> logInDetails = new List<Employee>();
			try
			{
				MakeConnection();
				string sqlString = "SELECT * FROM tbl_Employee"
									+ " WHERE (empEmail = '" + username + "')"
									+ " AND (empPassword = '" + password + "');";
				SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
				DataSet ds = new DataSet();
				sqlCmd.Fill(ds);
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					int facilityID = Convert.ToInt32(row["facilityID"]);
					int addressID = Convert.ToInt32(row["addressID"]);
					int jobRoleID = Convert.ToInt32(row["jobRoleID"]);
					string empFirstName = row["empFirstName"].ToString();
					string empSurname = row["empLastName"].ToString();
					string empEmail = row["empEmail"].ToString();
					string dob = row["empDateOfBirth"].ToString();
					int genderID = Convert.ToInt32(row["genderID"]);
					int nationalityID = Convert.ToInt32(row["nationalityID"]);
					int empStatusID = Convert.ToInt32(row["employeeStatusID"]);
					string empPassword = row["empPassword"].ToString();
					
					string contactNumber = row["contactNumber"].ToString();

					logInDetails.Add(new Employee(facilityID, addressID, jobRoleID, empFirstName, empSurname, empEmail, dob, genderID, nationalityID, empStatusID, empPassword, contactNumber));

				}

			}
			catch (Exception ex)
			{

			}
			return logInDetails;
		}
		

        public List<Facility> GetFacicilities()
        {
         
            List<Facility> facilities = new List<Facility>();
            try
            {
                MakeConnection();
                String sqlString = "select facilityID, facilityName from tbl_Facility";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string facilityName = row["facilityName"].ToString();
                    int facilityID = Convert.ToInt32(row["facilityID"]);

                    facilities.Add(new Facility(facilityID, facilityName));

                }

            }
            catch (Exception ex)
            {
                
            }
            return facilities;
        }
        public List<JobRole> GetJobRole()
        {
           
            List<JobRole> role = new List<JobRole>();
            try
            {
                MakeConnection();
                String sqlString = "select jobRoleID, jobRoleDescription from tbl_Job_Role";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string jobRoleDescription = row["jobRoleDescription"].ToString();
                    int jobRoleID = Convert.ToInt32(row["jobRoleID"]);

                    role.Add(new JobRole(jobRoleID, jobRoleDescription));

                }

            }
            catch (Exception ex)
            {

            }
            return role;
        }

        public List<Employee_Status> GetEmployeeStatus()
        {
       
            List<Employee_Status> status = new List<Employee_Status>();
            try
            {
                MakeConnection();
                String sqlString = "select employeeStatusID, employeeStatusDescription from tbl_Employee_Status";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string employeeStatusDescription = row["employeeStatusDescription"].ToString();
                    int employeeStatusID = Convert.ToInt32(row["employeeStatusID"]);

                    status.Add(new Employee_Status(employeeStatusID, employeeStatusDescription));

                }

            }
            catch (Exception ex)
            {

            }
            return status;
        }

        public List<Gender> GetGender()
        {
            
            List<Gender> gender = new List<Gender>();
            try
            {
                MakeConnection();
                String sqlString = "select * from tbl_Gender";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string genderType = row["genderDescription"].ToString();
                    int genderID = Convert.ToInt32(row["genderID"]);

                    gender.Add(new Gender(genderID, genderType));

                }

            }
            catch (Exception ex)
            {

            }
            return gender;
        }

        public List<Nationality> GetNationality()
        {
            
            List<Nationality> nationality = new List<Nationality>();
            try
            {
                MakeConnection();
                String sqlString = "select * from tbl_Nationality";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string nationalityDesc = row["nationalityDesc"].ToString();
                    int nationalityID = Convert.ToInt32(row["nationalityID"]);

                    nationality.Add(new Nationality(nationalityID, nationalityDesc));

                }

            }
            catch (Exception ex)
            {

            }
            return nationality;
        }

        public List<LegalStatus> GetlegalStatus()
        {
           
            List<LegalStatus> legalStatus = new List<LegalStatus>();
            try
            {
                MakeConnection();
                String sqlString = "select * from tbl_LegalStatus";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string statusDesc = row["statusDescription"].ToString();
                    int statusID = Convert.ToInt32(row["statusID"]);

                    legalStatus.Add(new LegalStatus(statusID, statusDesc));

                }

            }
            catch (Exception ex)
            {

            }
            return legalStatus;
        }

        public List<Relationship> GetRelationship()
        {
       
            List<Relationship> relationship = new List<Relationship>();
            try
            {
                MakeConnection();
                String sqlString = "select * from tbl_Relationship";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string relationshipDescription = row["relationshipDescription"].ToString();
                    int relationshipID = Convert.ToInt32(row["relationshipID"]);

                    relationship.Add(new Relationship(relationshipID, relationshipDescription));

                }

            }
            catch (Exception ex)
            {

            }
            return relationship;
        }

        public List<Statutory> GetStatutory()
        {
        
            List<Statutory> statutoryType = new List<Statutory>();
            try
            {
                MakeConnection();
                String sqlString = "select * from tbl_StatutoryType";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string statutoryDescription = row["statutoryDescription"].ToString();
                    int statutoryID = Convert.ToInt32(row["statutoryID"]);

                    statutoryType.Add(new Statutory(statutoryID, statutoryDescription));

                }

            }
            catch (Exception ex)
            {

            }
            return statutoryType;
        }

        public List<SocialWorker> GetsocialWorker()
        {
            List<SocialWorker> socilaWorker = new List<SocialWorker>();
            try
            {
                MakeConnection();
                String sqlString = " SELECT tbl_Employee.empID, CONCAT(tbl_Employee.empFirstName,' ', tbl_Employee.empLastName) AS EmployeeFullName FROM tbl_Employee, tbl_Job_Role "
                                    + "WHERE(tbl_Employee.jobRoleID = tbl_Job_Role.jobRoleID) AND (tbl_Job_Role.jobRoleDescription = 'Social Worker'); ";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string socialWorkerName = row["EmployeeFullName"].ToString();
                    int socialWorkerID = Convert.ToInt32(row["empID"]);

                    socilaWorker.Add(new SocialWorker(socialWorkerID, socialWorkerName));

                }

            }
            catch (Exception ex)
            {

            }
            return socilaWorker;
        }

        public List<FillComboBox> GetChildWorker()
        {
           

            List<FillComboBox> childWorker = new List<FillComboBox>();
            try
            {
                MakeConnection();
                String sqlString = " SELECT tbl_Employee.empID, CONCAT(tbl_Employee.empFirstName,' ', tbl_Employee.empLastName) AS EmployeeFullName FROM tbl_Employee, tbl_Job_Role "
                                    + "WHERE(tbl_Employee.jobRoleID = tbl_Job_Role.jobRoleID) AND (tbl_Job_Role.jobRoleDescription = 'Child Care Worker'); ";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string childCareWorkerName = row["EmployeeFullName"].ToString();
                    int childCareWorkerID = Convert.ToInt32(row["empID"]);

                    childWorker.Add(new FillComboBox(childCareWorkerID, childCareWorkerName));

                }

            }
            catch (Exception ex)
            {

            }
            return childWorker;
        }


        public List<Activity> GetDailyActivities(string date)
        {
        
            List<Activity> activities = new List<Activity>();
            try
            {
                MakeConnection();
                String sqlString = "select tbl_Activity.activityDescription, tbl_Facility.facilityName, tbl_Activity.activityDate, tbl_Activity.activityTime, tbl_Activity.activityPointAllocation "
                                +   "FROM tbl_Activity, tbl_Facility "
                                + "WHERE (tbl_Activity.facilityID = tbl_Facility.facilityID) AND (activityDate = '" + date + "')";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string activityName = row["activityDescription"].ToString();
                    string facilityName = row["facilityName"].ToString();
              
                    string activityDate = row["activityDate"].ToString();
                    string activityTime = row["activityTime"].ToString();
                    int points = Convert.ToInt32(row["activityPointAllocation"]);

                    activities.Add(new Activity(activityName, activityDate, activityTime, points));

                }

            }
            catch (Exception ex)
            {

            }
            return activities;
        }

        public List<Activity> GetMonthlyActivities(string date)
        {

            List<Activity> activities = new List<Activity>();
            try
            {
                MakeConnection();
                String sqlString = "select tbl_Activity.activityDescription, tbl_Facility.facilityName, tbl_Activity.activityDate, tbl_Activity.activityTime, tbl_Activity.activityPointAllocation "
                                + "FROM tbl_Activity, tbl_Facility "
                                + "WHERE (tbl_Activity.facilityID = tbl_Facility.facilityID) AND (MONTH(activityDate) = MONTH('" + date + "'))";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string activityName = row["activityDescription"].ToString();
                    string facilityName = row["facilityName"].ToString();

                    string activityDate = row["activityDate"].ToString();
                    string activityTime = row["activityTime"].ToString();
                    int points = Convert.ToInt32(row["activityPointAllocation"]);

                    activities.Add(new Activity(activityName, activityDate, activityTime, points));

                }

            }
            catch (Exception ex)
            {

            }
            return activities;
        }

        public List<CourtOrderDates> GetDailyCourtDates(string date)
		{
			List<CourtOrderDates> court = new List<CourtOrderDates>();
			try
			{
				MakeConnection();
				String sqlString = "SELECT childName, childSurname, courtOrderExpirationDate FROM tbl_Child "
                            + "WHERE DAY(courtOrderExpirationDate) = DAY('" + date + "') "
							+ "AND MONTH(courtOrderExpirationDate) = MONTH('" + date + "');";
				SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
				DataSet ds = new DataSet();
				sqlCmd.Fill(ds);
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					string name = row["childName"].ToString();
					string surname = row["childSurname"].ToString();
					string courtDate = row["courtOrderExpirationDate"].ToString();


					court.Add(new CourtOrderDates(name, surname, courtDate));

				}

			}
			catch (Exception ex)
			{

			}
			return court;
		}

        public List<CourtOrderDates> GetMonthlyCourtDates(string date)
        {
            List<CourtOrderDates> court = new List<CourtOrderDates>();
            try
            {
                MakeConnection();
                String sqlString = "SELECT childName, childSurname, courtOrderExpirationDate FROM tbl_Child "
                            + "WHERE MONTH(courtOrderExpirationDate) = MONTH('" + date + "');";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string name = row["childName"].ToString();
                    string surname = row["childSurname"].ToString();
                    string courtDate = row["courtOrderExpirationDate"].ToString();


                    court.Add(new CourtOrderDates(name, surname, courtDate));

                }

            }
            catch (Exception ex)
            {

            }
            return court;
        }


        public List<Birthdate> GetDailyBirthdays(string date)
        {
            List<Birthdate> childData= new List<Birthdate>();
            try
            {
                MakeConnection();
                String sqlString = "SELECT childName, childSurname, dateOfBirth FROM dbo.tbl_Child "
                                    + "WHERE DAY(dateOfBirth) = DAY('" + date + "') " 
                                    + "AND MONTH(dateOfBirth) = MONTH('" + date + "');";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string name = row["childName"].ToString();
                    string surname = row["childSurname"].ToString();
                    string dob = row["dateOfBirth"].ToString();


                    childData.Add(new Birthdate(name, surname, dob));

                }

            }
            catch (Exception ex)
            {

            }
            return childData;
        }

        public List<Birthdate> GetMonthlyBirthdays(string date)
        {
            List<Birthdate> childData = new List<Birthdate>();
            try
            {
                MakeConnection();
                String sqlString = "SELECT childName, childSurname, dateOfBirth FROM dbo.tbl_Child "
                                    + "WHERE MONTH(dateOfBirth) = MONTH('" + date + "');";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string name = row["childName"].ToString();
                    string surname = row["childSurname"].ToString();
                    string dob = row["dateOfBirth"].ToString();


                    childData.Add(new Birthdate(name, surname, dob));

                }

            }
            catch (Exception ex)
            {

            }
            return childData;
        }

        public List<ChildClass> GetChildDetails(string fileNumber)
        {
            List<ChildClass> childData = new List<ChildClass>();
            try
            {
                MakeConnection();
                String sqlString = "select tbl_Child.childID, tbl_Child.childName, tbl_Child.childSurname , tbl_Child.socialWorkerID, tbl_Child.childCareWorkerID, tbl_Child.fileNumber, tbl_Child.statutoryID, tbl_Family.relationshipToChild, tbl_Child.facilityID, tbl_Child.dateOfBirth,  tbl_Child.genderID, tbl_Child.schoolID, tbl_School.schoolName, tbl_School.schoolContactNum, tbl_Child.nationalityID, tbl_Child.legalStatusID, tbl_Child.familyID, tbl_Family.firstName, tbl_Family.lastName, tbL_Family.contactNumber, tbl_Family.addressID, tbl_Address.houseNumber, tbl_Address.streetName, tbl_Address.suburb, tbl_Address.town, tbl_Address.province, tbl_Address.postalCode, tbl_Child.courtOrderExpirationDate, tbl_Family.familyNote, tbl_Child.admissionDate, tbl_Child.exitDate, tbl_Family.genderID AS familyGender,  DATEDIFF(YEAR, tbl_Child.admissionDate, tbl_Child.exitDate) AS YearsInShelter "
                                + "FROM tbl_Child, tbl_Gender, tbl_School, tbl_Nationality, tbl_LegalStatus, tbl_Family, tbl_Address, tbl_Facility, tbl_Relationship, tbl_StatutoryType, tbl_Employee "
                                + "WHERE(tbl_Child.schoolID = tbl_School.schoolID) AND(tbl_Child.socialWorkerID = tbl_Employee.empID) AND(tbl_StatutoryType.statutoryID = tbl_Child.statutoryID) AND(tbl_Child.facilityID = tbl_Facility.facilityID) AND(tbl_Relationship.relationshipID = tbl_Family.relationshipToChild) AND(tbl_Child.nationalityID = tbl_Nationality.nationalityID) AND(tbl_Child.genderID = tbl_Gender.genderID) AND(tbl_Child.legalStatusID = tbl_LegalStatus.statusID) AND(tbl_Child.familyID = tbl_Family.familyMemberID) AND(tbl_Family.addressID = tbl_Address.addressID) AND tbl_Child.fileNumber = '" + fileNumber + "'";

                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    int childID = Convert.ToInt32(row["childID"]);
                     string childName = row["childName"].ToString(); ;
                     string childSurname = row["childSurname"].ToString();
                     int socialWorkerID = Convert.ToInt32(row["socialWorkerID"]);
                    int childWorkerID = Convert.ToInt32(row["childCareWorkerID"]);
                    string filenumber = row["fileNumber"].ToString();
                     int statutoryID = Convert.ToInt32(row["statutoryID"]);
                     int relationshipID = Convert.ToInt32(row["relationshipToChild"]);
                    int facilityID = Convert.ToInt32(row["facilityID"]); ;
                     string dob = row["dateOfBirth"].ToString();
                     int genderID = Convert.ToInt32(row["genderID"]); ;
                     int schoolID = Convert.ToInt32(row["schoolID"]); ;
                     string schoolName = row["schoolName"].ToString();
                    string schoolContactNumber = row["schoolContactNum"].ToString();
                    int nationality = Convert.ToInt32(row["nationalityID"]); ;
                     int legalStatus = Convert.ToInt32(row["legalStatusID"]); ;
                     int familyID = Convert.ToInt32(row["familyID"]);
                     string familyFirstName = row["firstName"].ToString();
                    string familySurname = row["lastName"].ToString();
                    string contactNumber = row["contactNumber"].ToString();
                    int addressID = Convert.ToInt32(row["addressID"]);
                     int houseNumber = Convert.ToInt32(row["houseNumber"]);
                     string streetName = row["streetName"].ToString();
                    string suburb = row["suburb"].ToString();
                    string town = row["town"].ToString();
                    string courtOrderDate = row["courtOrderExpirationDate"].ToString();
                    string addmissionDate = row["admissionDate"].ToString();
                    string exitDate = row["exitDate"].ToString();
                    int yearsInShelter = Convert.ToInt32(row["YearsInShelter"]);
                    string familyNotes = row["familyNote"].ToString();
                    string province = row["province"].ToString();
                    int postalCode = Convert.ToInt32(row["postalCode"]);
                    int familyGender = Convert.ToInt32(row["familyGender"]);


                    childData.Add(new ChildClass(childID, childName, childSurname, socialWorkerID, childWorkerID, filenumber, statutoryID, relationshipID, facilityID, dob, genderID, schoolID, schoolName, schoolContactNumber, nationality, legalStatus, familyID, familyFirstName, familySurname, contactNumber, addressID, houseNumber, streetName, suburb, town, province, postalCode, courtOrderDate, addmissionDate, exitDate, yearsInShelter, familyNotes, familyGender));
     
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return childData;
        }

        public void RegisterUser(int facilityID, int jobRole, string firstName, string surname, string email, string dob, int genderID, int nationalityID, int employeeStatusID, string password, string contactNumber, string province, string surburb, string town, string streetName, string houseNumber, int postalCode )
        {
            try
            {
                DateTime date = Convert.ToDateTime(dob);
               

                MakeConnection();
                // Use parameters in the SQL query string
                string sql = "insert into tbl_Address (province, suburb, town, streetName, houseNumber, postalCode) " +
                    "values (@province, @suburb, @town, @streetName, @houseNumber, @postalCode)";

                // Create the Command object
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);

                // Asign values to each parameter in the query string
                sqlCmd.Parameters.Add("@province", SqlDbType.VarChar, 20).Value = province;
                sqlCmd.Parameters.Add("@suburb", SqlDbType.VarChar, 20).Value = surburb;
                sqlCmd.Parameters.Add("@town", SqlDbType.VarChar, 30).Value = town;
                sqlCmd.Parameters.Add("@streetName", SqlDbType.VarChar, 30).Value = streetName;
                sqlCmd.Parameters.Add("@houseNumber", SqlDbType.VarChar, 10).Value = houseNumber;
                sqlCmd.Parameters.Add("@postalCode", SqlDbType.Int).Value = postalCode;

                // Connect to the DB
                SqlConn.Open();

                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd.ExecuteNonQuery();

                //get ID
                sql = "select addressID FROM tbl_Address WHERE houseNumber = '" + houseNumber +"'";
                sqlCmd.CommandText = sql;
                int addressID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                // Remember to close the DB connection again
                SqlConn.Close();
                //MessageBox.Show("Test Created");

                string sql2 = "insert into tbl_Employee (facilityID, addressID, jobRoleID, empFirstName, empLastName, empEmail, empDateOfBirth, genderID, nationalityID, employeeStatusID, empPassword, contactNumber)" +
                            "values (@facilityID, @addressID, @jobRole, @firstName, @surname, @email, @date, @genderID, @nationalityID, @employeeStatusID, @password, @contactNumber)";

                SqlCommand sqlCmd2 = new SqlCommand(sql2, SqlConn);
                sqlCmd2.Parameters.Add("@facilityID", SqlDbType.Int).Value = facilityID;
                sqlCmd2.Parameters.Add("@addressID", SqlDbType.Int).Value = addressID;
                sqlCmd2.Parameters.Add("@jobRole", SqlDbType.Int).Value = jobRole;
                sqlCmd2.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = firstName;
                sqlCmd2.Parameters.Add("@surname", SqlDbType.VarChar, 50).Value = surname;
                sqlCmd2.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = email;
                sqlCmd2.Parameters.Add("@date", SqlDbType.Date).Value = date.ToString("yyyy/MM/dd"); 
                sqlCmd2.Parameters.Add("@genderID", SqlDbType.Int).Value = genderID;
                sqlCmd2.Parameters.Add("@nationalityID", SqlDbType.Int).Value = nationalityID;
                sqlCmd2.Parameters.Add("@employeeStatusID", SqlDbType.Int).Value = employeeStatusID;
                sqlCmd2.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
                sqlCmd2.Parameters.Add("@contactNumber", SqlDbType.VarChar, 10).Value = contactNumber;

                SqlConn.Open();
                //sqlCmd.ExecuteNonQuery();
                sqlCmd2.ExecuteNonQuery();
                //MessageBox.Show("Question was saved");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }

            

        }
      


        public Boolean AddNewActivity(int facilityID, int activityStatusID, string activityDescription, int pointsAllocated)
        {
            bool result = false;
            try
            {
               
                MakeConnection();
                // Use parameters in the SQL query string
                string saveActivitySql = "insert into tbl_Activity(facilityID, activityStatusID, activityDescription, activityDate, activityTime, activityPointAllocation) " +
                    "values(@facilityID, @activityStatusID, @activityDescription, null, null, @activityPointAllocation)";

                // Create the Command object
                SqlCommand sqlCmd = new SqlCommand(saveActivitySql, SqlConn);

                // Asign values to each parameter in the query string
                sqlCmd.Parameters.Add("@facilityID", SqlDbType.Int, 20).Value = facilityID;
                sqlCmd.Parameters.Add("@activityStatusID", SqlDbType.Int, 20).Value = activityStatusID;
                sqlCmd.Parameters.Add("@activityDescription", SqlDbType.VarChar, 30).Value = activityDescription;
                sqlCmd.Parameters.Add("@activityPointAllocation", SqlDbType.Int, 20).Value = pointsAllocated;

                // Connect to the DB
                SqlConn.Open();

                //sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                //MessageBox.Show("Question was saved");
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                string error = ex.ToString();
            }

            return result;
        }



        public void addChildDetails(string fileNumber, string childName, string childSurname, string childDateOfBirth, int genderID, int nationalityID, int lStatusID, int facilityID, string schoolName, string schoolContactNum,
                                    int familyDesc, string firstName, string lastName, string familyDateOfBirth, int fGenderID, int fNationalityID, string contactNumber, string familyNotes,
                                    string houseNumber, string streetName, string town, string surburb, int postalCode, string province,
                                    string admissionDate, string exitDate, int statutoryID, string coutOrderDate, int socialWorkerID, int childCareWorkerID)
        {
            try
            {
                DateTime cDateOfBirth = Convert.ToDateTime(childDateOfBirth);
                DateTime fDateOfBirth = Convert.ToDateTime(familyDateOfBirth);
                DateTime addDate = Convert.ToDateTime(admissionDate);
                DateTime exitdate = Convert.ToDateTime(exitDate);
                DateTime coDate = Convert.ToDateTime(coutOrderDate);

                MakeConnection();


                // Use parameters in the SQL query string for the tbl_School
                string sql = "insert into tbl_School (schoolName, schoolContactNum) " +
                    "values (@schoolName, @schoolContactNum)";

                // Create the Command object
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);

                // Asign values to each parameter in the query string
                sqlCmd.Parameters.Add("@schoolName", SqlDbType.VarChar, 40).Value = schoolName;
                sqlCmd.Parameters.Add("@schoolContactNum", SqlDbType.VarChar, 10).Value = schoolContactNum;
                SqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                // Connect to the DB
                string sqlL = "SELECT @@IDENTITY AS SCHOOLID FROM tbl_School";
                sqlCmd.CommandText = sqlL;
                int schoolID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                

                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                
                SqlConn.Close();



                // Use parameters in the SQL query string for the tbl_Address
                string sql1 = "insert into tbl_Address (province, suburb, town, streetName, houseNumber, postalCode) " +
                    "values (@province, @suburb, @town, @streetName, @houseNumber, @postalCode)";

                // Create the Command object
                SqlCommand sqlCmd1 = new SqlCommand(sql1, SqlConn);

                // Asign values to each parameter in the query string
                sqlCmd1.Parameters.Add("@province", SqlDbType.VarChar, 20).Value = province;
                sqlCmd1.Parameters.Add("@suburb", SqlDbType.VarChar, 20).Value = surburb;
                sqlCmd1.Parameters.Add("@town", SqlDbType.VarChar, 30).Value = town;
                sqlCmd1.Parameters.Add("@streetName", SqlDbType.VarChar, 30).Value = streetName;
                sqlCmd1.Parameters.Add("@houseNumber", SqlDbType.VarChar, 10).Value = houseNumber;
                sqlCmd1.Parameters.Add("@postalCode", SqlDbType.Int).Value = postalCode;

                // Connect to the DB
                SqlConn.Open();
                sqlCmd1.ExecuteNonQuery();

                string sqlA = "SELECT @@IDENTITY AS ADDRESSID FROM tbl_Address";
                sqlCmd1.CommandText = sqlA;
                int addressID = Convert.ToInt32(sqlCmd1.ExecuteScalar());
               
                SqlConn.Close();

                // Use parameters in the SQL query string for the tbl_Familly
                string sql2 = "insert into tbl_Family (addressID, familyNote, firstName, lastName, dateOfBirth, genderID, nationalityID, relationshipToChild, contactNumber) " +
                    "values (@addressID, @familyNoteID, @firstName, @lastName, @dateOfBirth, @genderID, @nationalityID, @relationshipToChild, @contactNumber)";

                // Create the Command object
                SqlCommand sqlCmd2 = new SqlCommand(sql2, SqlConn);

                // Asign values to each parameter in the query string
                sqlCmd2.Parameters.Add("@addressID", SqlDbType.Int).Value = addressID;
                sqlCmd2.Parameters.Add("@familyNoteID", SqlDbType.VarChar, 225).Value = familyNotes;
                sqlCmd2.Parameters.Add("@firstName", SqlDbType.VarChar, 30).Value = firstName;
                sqlCmd2.Parameters.Add("@lastName", SqlDbType.VarChar, 30).Value = lastName;
                sqlCmd2.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = fDateOfBirth.ToString("yyyy/MM/dd");
                sqlCmd2.Parameters.Add("@genderID", SqlDbType.Int).Value = fGenderID;
                sqlCmd2.Parameters.Add("@nationalityID", SqlDbType.Int).Value = fNationalityID;
                sqlCmd2.Parameters.Add("@relationshipToChild", SqlDbType.Int).Value = familyDesc;
                sqlCmd2.Parameters.Add("@contactNumber", SqlDbType.VarChar, 10).Value = contactNumber;
                // Connect to the DB

                SqlConn.Open();
                sqlCmd2.ExecuteNonQuery();

                string sqlF = "SELECT @@IDENTITY AS FAMILYID FROM tbl_Family";
                sqlCmd2.CommandText = sqlF;
                int familyID = Convert.ToInt32(sqlCmd2.ExecuteScalar());
          
                SqlConn.Close();

                // Use parameters in the SQL query string
                string sql4 = "insert into tbl_Child (fileNumber, schoolID, facilityID, familyID, childName, childSurname, dateOfBirth, genderID, nationalityID, " +
                              "legalStatusID, statutoryID, courtOrderExpirationDate, admissionDate, exitDate, socialWorkerID, childcareWorkerID) " +
                              "values (@fileNumber, @schoolID, @facilityID, @familyID, @childName, @childSurname, @dateOfBirth, @genderID, @nationalityID, " +
                              "@lStatusID, @statutoryID, @coutOrderDate, @admissionDate, @exitDate, @socialWorkerID, @childCareWorkerID)";

                // Create the Command object and Asign values to each parameter in the query string
                SqlCommand sqlCmd4 = new SqlCommand(sql4, SqlConn);

                sqlCmd4.Parameters.Add("@fileNumber", SqlDbType.VarChar, 40).Value = fileNumber;
                sqlCmd4.Parameters.Add("@schoolID", SqlDbType.Int).Value = schoolID;
                sqlCmd4.Parameters.Add("@facilityID", SqlDbType.Int).Value = facilityID;
                sqlCmd4.Parameters.Add("@familyID", SqlDbType.Int).Value = familyID;
                sqlCmd4.Parameters.Add("@addressID", SqlDbType.Int).Value = addressID;
                sqlCmd4.Parameters.Add("@childName", SqlDbType.VarChar, 30).Value = childName;
                sqlCmd4.Parameters.Add("@childSurname", SqlDbType.VarChar, 30).Value = childSurname;
                sqlCmd4.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = cDateOfBirth.ToString("yyyy/MM/dd");
                sqlCmd4.Parameters.Add("@genderID", SqlDbType.Int).Value = genderID;
                sqlCmd4.Parameters.Add("@nationalityID", SqlDbType.Int).Value = nationalityID;
                sqlCmd4.Parameters.Add("@lStatusID", SqlDbType.Int).Value = lStatusID;
                sqlCmd4.Parameters.Add("@statutoryID", SqlDbType.Int).Value = statutoryID;
                sqlCmd4.Parameters.Add("@coutOrderDate", SqlDbType.Date).Value = coDate.ToString("yyyy/MM/dd");
                sqlCmd4.Parameters.Add("@admissionDate", SqlDbType.Date).Value = addDate.ToString("yyyy/MM/dd");
                sqlCmd4.Parameters.Add("@exitDate", SqlDbType.Date).Value = exitdate.ToString("yyyy/MM/dd");
                sqlCmd4.Parameters.Add("@socialWorkerID", SqlDbType.Int).Value = socialWorkerID;
                sqlCmd4.Parameters.Add("@childCareWorkerID", SqlDbType.Int).Value = childCareWorkerID;

                // Connect to the DB
                SqlConn.Open();
                

                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd4.ExecuteNonQuery();
                SqlConn.Close();

            }
            catch (System.Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }


            finally
            {
                // Remember to close the DB connection again
                SqlConn.Close();
            }
        }


        public List<ChildFullName> GetChildNames()
        {

            List<ChildFullName> childName = new List<ChildFullName>();
            try
            {
                MakeConnection();
                String sqlString = "SELECT fileNumber, CONCAT(childName, ' ', childSurname) AS childFullName FROM tbl_Child";
                SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlString, SqlConn);
                DataSet ds = new DataSet();
                sqlCmd.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string childFullName = row["childFullName"].ToString();
                    string childID = row["fileNumber"].ToString();

                    childName.Add(new ChildFullName(childID, childFullName));

                }

            }
            catch (Exception ex)
            {

            }
            return childName;
        }

        public Boolean UpdateChildDetails(int schoolID, int familyID, int addressID,  int childID, string fileNumber, string childName, string childSurname, string childDateOfBirth, int nationalityID, int lStatusID, int facilityID, string schoolName, string schoolContactNum,
                                    int familyDesc, string firstName, string lastName, string contactNumber, string familyNotes,
                                    string houseNumber, string streetName, string town, string surburb, int postalCode, string province,
                                    string admissionDate, string exitDate, int statutoryID, string coutOrderDate, int socialWorkerID, int childCareWorkerID)
        {
            bool update;
            try
            {
                MakeConnection();

                DateTime DOB = Convert.ToDateTime(childDateOfBirth);
                DateTime courtDate = Convert.ToDateTime(coutOrderDate);
                DateTime addDate = Convert.ToDateTime(admissionDate);
                DateTime exitdate = Convert.ToDateTime(exitDate);

                //UPDATE SCHOOL DETAILS
                string updateSchool = "update tbl_School set schoolName = '" + schoolName + "', schoolContactNum = '" + schoolContactNum + "' where schoolID = " + schoolID;
                SqlCommand sqlCmd = new SqlCommand(updateSchool, SqlConn);
                SqlConn.Open();
                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd.ExecuteNonQuery();
                SqlConn.Close();

                //UPDATE FAMILY DETAILS
                string updateFamily = "update tbl_Family set familyNote = '" + familyNotes + "', firstName = '" + firstName + "', lastName = '" + lastName + "', " 
                                        + "relationshipToChild = " + familyDesc + ", contactNumber = '" + contactNumber + "' where familyMemberID = " + familyID;
                SqlCommand sqlCmd2 = new SqlCommand(updateFamily, SqlConn);
                SqlConn.Open();
                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd2.ExecuteNonQuery();
                SqlConn.Close();

                //UPDATE FAMILY ADDRESS 
                string updateAddress = "update tbl_Address set province = '" + province + "', suburb = '" + surburb + "', town = '" + town + "', "
                                       + "streetName = '" + streetName + "', houseNumber = '" + houseNumber + "', postalCode = " + postalCode + " where addressID = " + addressID;
                SqlCommand sqlCmd3 = new SqlCommand(updateAddress, SqlConn);
                SqlConn.Open();
                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd3.ExecuteNonQuery();
                SqlConn.Close();

                //UPDATE CHILD DETAILS
                string updateChildDetails = "update tbl_Child set fileNumber = '" + fileNumber + "', facilityID = " + facilityID + ", familyID = " + familyID + ", " +
                                       "childName = '" + childName + "', childSurname = '" + childSurname + "', dateOfbirth = '" + DOB.ToString("yyyy/MM/dd") + "', legalStatusID = " + lStatusID +", " +
                                       "statutoryID = " + statutoryID + ", courtOrderExpirationDate = '" + courtDate.ToString("yyyy/MM/dd") + "', admissionDate = '" + addDate.ToString("yyyy/MM/dd") + "', " +
                                       "exitDate = '" + exitdate.ToString("yyyy/MM/dd") + "', socialWorkerID = " + socialWorkerID + ", childCareWorkerID = " + childCareWorkerID + " where childID = " + childID;
                SqlCommand sqlCmd4 = new SqlCommand(updateChildDetails, SqlConn);
                SqlConn.Open();
                // Execute the insert statement - it returns no result set and that is why ExecuteNonQuery is used
                sqlCmd4.ExecuteNonQuery();

                SqlConn.Close();
                update = true;
            }
            catch (System.Exception ex)
            {
                string error = ex.ToString();
                //MessageBox.Show(ex.Message);
                update = false;
            }
            return update;
        }

      
        public int getNumOfEnrolled(int month, int facilityID)
        {
            int numOfKids = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM tbl_Child WHERE(MONTH(admissionDate) = " + month + ") AND facilityID = " + facilityID;
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                 numOfKids = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return numOfKids;
        }

        public int getNumOfExits(int month, int facilityID)
        {
            int numOfKids = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM tbl_Child WHERE(MONTH(exitDate) = " + month + ") AND facilityID = " + facilityID;
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                numOfKids = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return numOfKids;
        }

        public int getNumOfActivities(int month, int facilityID)
        {
            int numOfActivities = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM  tbl_Activity WHERE(MONTH(activityDate) = " + month + ") AND facilityID = " + facilityID;
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                numOfActivities = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return numOfActivities;
        }

        public int getSleptIn(int month, int facilityID)
        {
            int sleptIn = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM  tbl_Daily_Attendance, tbl_Child WHERE(MONTH(dailyDate) = " + month + ") AND(dailyAttendanceStatusID = 1) AND(tbl_Child.fileNumber = tbl_Daily_Attendance.fileNumber) AND(tbl_Child.facilityID = " + facilityID + ");";
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                sleptIn = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return sleptIn;
        }

        public int getDetained(int month, int facilityID)
        {
            int type = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM  tbl_Daily_Attendance, tbl_Child WHERE(MONTH(dailyDate) = " + month + ") AND(dailyAttendanceStatusID = 2) AND(tbl_Child.fileNumber = tbl_Daily_Attendance.fileNumber) AND(tbl_Child.facilityID = " + facilityID + ");";
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                type = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return type;
        }

        public int getAbsconded(int month, int facilityID)
        {
            int type = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM  tbl_Daily_Attendance, tbl_Child WHERE(MONTH(dailyDate) = " + month + ") AND(dailyAttendanceStatusID = 3) AND(tbl_Child.fileNumber = tbl_Daily_Attendance.fileNumber) AND(tbl_Child.facilityID = " + facilityID + ");";
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                type = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return type;
        }

        public int getHomeVisit(int month, int facilityID)
        {
            int type = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM  tbl_Daily_Attendance, tbl_Child WHERE(MONTH(dailyDate) = " + month + ") AND(dailyAttendanceStatusID = 4) AND(tbl_Child.fileNumber = tbl_Daily_Attendance.fileNumber) AND(tbl_Child.facilityID = " + facilityID + ");";
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                type = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return type;
        }

        public int getBirthdays(int month, int facilityID)
        {
            int type = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM tbl_Child WHERE(MONTH(dateOfBirth) = " + month + ") AND facilityID = " + facilityID;
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                type = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return type;
        }

        public int getCourtDates(int month, int facilityID)
        {
            int type = 0;

            try
            {
                MakeConnection();
                string sql = "SELECT COUNT(*) FROM tbl_Child WHERE(MONTH(courtOrderExpirationDate) = " + month + ") AND facilityID = " + facilityID;
                SqlCommand sqlCmd = new SqlCommand(sql, SqlConn);
                SqlConn.Open();
                sqlCmd.CommandText = sql;
                type = Convert.ToInt32(sqlCmd.ExecuteScalar());
                SqlConn.Close();
            }
            catch (System.Exception ex)
            {

            }

            return type;
        }
    }
}