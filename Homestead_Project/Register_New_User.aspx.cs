using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

//using System.Net.Mail;

namespace Homestead_Project
{
    public partial class Register_New_User : System.Web.UI.Page
    {
        bool updating, validated = false;
        int genderID, facilityID, nationalityID, jobRoleID, statusID, addressID;
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
      
        DB_Manager addNewUser = new DB_Manager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                FillComboBox();
                
            }
            genderID = Convert.ToInt32(cbGender.SelectedValue);
            nationalityID = Convert.ToInt32(cbNationality.SelectedValue);
            jobRoleID = Convert.ToInt32(cbJobRole.SelectedValue);
            statusID = Convert.ToInt32(cbStatus.SelectedValue);
            facilityID = Convert.ToInt32(cbFacilities.SelectedValue);
        }

        public void FillComboBox()
        {
            updating = true;
            IList<Facility> facilities = new DB_Manager().GetFacicilities();
            if (facilities != null)
            {
                cbFacilities.DataSource = facilities;
                cbFacilities.DataTextField = "FacilityName";
                cbFacilities.DataValueField = "FacilityID";
                cbFacilities.DataBind();
            }

            IList<JobRole> role = new DB_Manager().GetJobRole();
            if (role != null)
            {
                cbJobRole.DataSource = role;
                cbJobRole.DataTextField = "JobRoleDescription";
                cbJobRole.DataValueField = "JobRoleID";
                cbJobRole.DataBind();
            }

            IList<Employee_Status> status = new DB_Manager().GetEmployeeStatus();
            if (status != null)
            {
                cbStatus.DataSource = status;
                cbStatus.DataTextField = "EmployeeDescription";
                cbStatus.DataValueField = "EmployeeStatusID";
                cbStatus.DataBind();
            }

            IList<Gender> gender = new DB_Manager().GetGender();
            if (gender != null)
            {
                cbGender.DataSource = gender;
                cbGender.DataTextField = "GenderDescription";
                cbGender.DataValueField = "GenderID";
                cbGender.DataBind();
            }


            IList<Nationality> nationality = new DB_Manager().GetNationality();
            if (nationality != null)
            {
                cbNationality.DataSource = nationality;
                cbNationality.DataTextField = "NationalityDesc";
                cbNationality.DataValueField = "NationalityID";
                cbNationality.DataBind();
            }
            
            updating = false;
            
        }

        protected void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            genderID = Convert.ToInt32(cbGender.SelectedValue);
            
        }

        protected void cbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            nationalityID = Convert.ToInt32(cbNationality.SelectedValue);
        }

        protected void cbJobRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobRoleID = Convert.ToInt32(cbJobRole.SelectedValue);
        }

        protected void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusID = Convert.ToInt32(cbStatus.SelectedValue);
        }

        protected void cbFacilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            facilityID = Convert.ToInt32(cbFacilities.SelectedValue);
        }

        public void registerUser()
        {

            if (TextValidation().Equals(true))
            {
                addNewUser.RegisterUser(facilityID, jobRoleID, txtFirstName.Text, txtSurnname.Text, txtEmail.Text, txtDOB.Text, genderID, nationalityID, statusID, txtPassword.Text, txtContactNumber.Text, txtProvince.Text, txtSurburb.Text, txtTown.Text, txtStreetName.Text, txtHouseNumber.Text, Convert.ToInt32(txtPostalCode.Text));
                txtError.Visible = true;
                txtError.Text = "User Registration Successful";
            } else
            {
                TextValidation();
                txtError.Visible = true;
                txtError.Text = "Incorrect Inputs";
            }
        }
  
        /*
        public String HashPassword(string password)
        {

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password: password,
           salt: salt,
           prf: KeyDerivationPrf.HMACSHA1,
           iterationCount: 10000,
           numBytesRequested: 256 / 8));

            return password;
        }
        */
        public Boolean TextValidation()
        {
            bool valid;
            if (txtFirstName.Text == "")
            {
                txtFirstName.BackColor = System.Drawing.Color.LavenderBlush;
                 valid = false;
            }
            else
            {
                txtFirstName.BackColor = System.Drawing.Color.White;
                 valid = true;
            }
             if (txtSurnname.Text == "")
            {
                txtSurnname.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtSurnname.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtContactNumber.Text == "")
            {
                txtContactNumber.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtContactNumber.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtDOB.Text == "")
            {
                txtDOB.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtDOB.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtEmail.Text == "" && Regex.IsMatch(txtEmail.Text, pattern))
            {
                txtEmail.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
          
            else {
                txtEmail.BackColor = System.Drawing.Color.White;
                valid = true;
            }
          
            if (txtHouseNumber.Text == "")
            {
                txtHouseNumber.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtHouseNumber.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtPassword.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtPostalCode.Text == "")
            {
                txtPostalCode.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtPostalCode.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtProvince.Text == "")
            {
                txtProvince.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtProvince.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtStreetName.Text == "")
            {
                txtStreetName.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtStreetName.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtSurburb.Text == "")
            {
                txtSurburb.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtSurburb.BackColor = System.Drawing.Color.White;
                valid = true;
            }
            if (txtTown.Text == "")
            {
                txtTown.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtTown.BackColor = System.Drawing.Color.White;
                valid = true;
            } 
            

            return valid;
        }

        protected void RegisterNewUser(object sender, EventArgs e)
        {
            registerUser();
        }


    }
}