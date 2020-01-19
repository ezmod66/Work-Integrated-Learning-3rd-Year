using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Add_Child_Details : System.Web.UI.Page
    {
        //Declare Variables
        bool updating;
        int genderID, nationalityID, lStatusID, facilityID, statutoryID, childCareWorkerID, socialWorkerID, fNationalityID, fGenderID, relationshipID;

        DB_Manager childDetails = new DB_Manager();

        SqlConnection SqlConn = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillComboBox();
            }
            Session["socialWorkerID"] = Convert.ToInt32(cbSWorker.SelectedValue);
            Session["childCareWorkerID"] = Convert.ToInt32(cbCWorker.SelectedValue);
            Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);
            Session["nationality"] = Convert.ToInt32(cbNationality.SelectedValue);
            Session["relationship"] = Convert.ToInt32(cbRelationship.SelectedValue);

            Session["fGender"] = Convert.ToInt32(cbFamilyGender.SelectedValue);
 
            Session["gender"] = Convert.ToInt32(cbFamilyGender.SelectedValue);      
            Session["socialWorkerID"] = Convert.ToInt32(cbSWorker.SelectedValue);      
            Session["childCareWorkerID"] = Convert.ToInt32(cbCWorker.SelectedValue);       
            Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);

        }
        public Boolean TextValidation()
        {
            bool valid;
            if (txtFileNumber.Text == "")
            {
                txtFileNumber.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFileNumber.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtFamilyFirstName.Text == "")
            {
                txtFamilyFirstName.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFamilyFirstName.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtFamilySurname.Text == "")
            {
                txtFamilySurname.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFamilySurname.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtFamilyDateOfBirth.Text == "")
            {
                txtFamilyDateOfBirth.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFamilyDateOfBirth.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtExtraNotes.Text == "")
            {
                txtExtraNotes.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtExtraNotes.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtAdmissionDate.Text == "")
            {
                txtAdmissionDate.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtAdmissionDate.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtFamilyDateOfBirth.Text == "")
            {
                txtFamilyDateOfBirth.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFamilyDateOfBirth.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtDischargeDate.Text == "")
            {
                txtDischargeDate.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtDischargeDate.BackColor = System.Drawing.Color.White;
                valid = true;
            }

            if (txtCourtOrderExpires.Text == "")
            {
                txtCourtOrderExpires.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtCourtOrderExpires.BackColor = System.Drawing.Color.White;
                valid = true;
            }

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

            if (txtFamilyContactNumber.Text == "")
            {
                txtFamilyContactNumber.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtFamilyContactNumber.BackColor = System.Drawing.Color.White;
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
            if (txtSchoolContactNumber.Text == "")
            {
                txtSchoolContactNumber.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }

            else
            {
                txtSchoolContactNumber.BackColor = System.Drawing.Color.White;
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
            if (txtSchoolName.Text == "")
            {
                txtSchoolName.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtSchoolName.BackColor = System.Drawing.Color.White;
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
            if (txtStreetAddress.Text == "")
            {
                txtStreetAddress.BackColor = System.Drawing.Color.LavenderBlush;
                valid = false;
            }
            else
            {
                txtStreetAddress.BackColor = System.Drawing.Color.White;
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

        public void FillComboBox()
        {
            updating = true;

            IList<Gender> gender = new DB_Manager().GetGender();
            if (gender != null)
            {
                cbGender.DataSource = gender;
                cbGender.DataTextField = "genderDescription";
                cbGender.DataValueField = "genderID";
                cbGender.DataBind();

                cbFamilyGender.DataSource = gender;
                cbFamilyGender.DataTextField = "genderDescription";
                cbFamilyGender.DataValueField = "genderID";
                cbFamilyGender.DataBind();
            }


            IList<Nationality> nationality = new DB_Manager().GetNationality();
            if (nationality != null)
            {
                cbNationality.DataSource = nationality;
                cbNationality.DataTextField = "nationalityDesc";
                cbNationality.DataValueField = "nationalityID";
                cbNationality.DataBind();

                cbFamilyNationality.DataSource = nationality;
                cbFamilyNationality.DataTextField = "nationalityDesc";
                cbFamilyNationality.DataValueField = "nationalityID";
                cbFamilyNationality.DataBind();
            }

            IList<LegalStatus> legalStatus = new DB_Manager().GetlegalStatus();
            if (legalStatus != null)
            {
                cbLegalStatus.DataSource = legalStatus;
                cbLegalStatus.DataTextField = "legalStatusDescription";
                cbLegalStatus.DataValueField = "legalStatusID";
                cbLegalStatus.DataBind();
            }

            updating = false;

            IList<Relationship> relationship = new DB_Manager().GetRelationship();
            if (relationship != null)
            {
                cbRelationship.DataSource = relationship;
                cbRelationship.DataTextField = "description";
                cbRelationship.DataValueField = "descriptionID";
                cbRelationship.DataBind();
            }

            updating = false;

            IList<Statutory> statutory = new DB_Manager().GetStatutory();
            if (statutory != null)
            {
                cbStatutory.DataSource = statutory;
                cbStatutory.DataTextField = "description";
                cbStatutory.DataValueField = "descriptionID";
                cbStatutory.DataBind();
            }

            updating = false;

            IList<SocialWorker> socialWorker = new DB_Manager().GetsocialWorker();
            if (socialWorker != null)
            {
                cbSWorker.DataSource = socialWorker;
                cbSWorker.DataTextField = "description";
                cbSWorker.DataValueField = "descriptionID";
                cbSWorker.DataBind();
            }

            updating = false;

            IList<FillComboBox> childWorker = new DB_Manager().GetChildWorker();
            if (childWorker != null)
            {
                cbCWorker.DataSource = childWorker;
                cbCWorker.DataTextField = "description";
                cbCWorker.DataValueField = "descriptionID";
                cbCWorker.DataBind();
            }

            updating = true;
            IList<Facility> facilities = new DB_Manager().GetFacicilities();
            if (facilities != null)
            {
                cbFalicities.DataSource = facilities;
                cbFalicities.DataTextField = "FacilityName";
                cbFalicities.DataValueField = "FacilityID";
                cbFalicities.DataBind();
            }
        }
        protected void cbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["nationality"] = Convert.ToInt32(cbNationality.SelectedValue);
        }

        protected void cbLegalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["legalStatus"] = Convert.ToInt32(cbLegalStatus.SelectedValue);
        }


        protected void cbRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["relationship"] = Convert.ToInt32(cbRelationship.SelectedValue);
        }
        protected void cbFamilyGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fGender"] = Convert.ToInt32(cbFamilyGender.SelectedValue);
        }

        protected void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["gender"] = Convert.ToInt32(cbFamilyGender.SelectedValue);
        }

        protected void cbFamilyNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fNational"] = Convert.ToInt32(cbFamilyNationality.SelectedValue);
        }

        protected void cbStatutory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["statutoryID"] = Convert.ToInt32(cbStatutory.SelectedValue);
        }

        protected void cbSWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["socialWorkerID"] = Convert.ToInt32(cbSWorker.SelectedValue);
        }

        protected void cbCWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["childCareWorkerID"] = Convert.ToInt32(cbCWorker.SelectedValue);
        }

        protected void cbFalicities_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);
        }

  
   

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TextValidation().Equals(true))
            {
                childDetails.addChildDetails
            (
                txtFileNumber.Text, txtFirstName.Text, txtSurnname.Text, txtDOB.Text, Convert.ToInt32(Session["gender"]), Convert.ToInt32(Session["nationality"]), Convert.ToInt32(Session["legalStatus"]), Convert.ToInt32(Session["facility"]), txtSchoolName.Text, txtSchoolContactNumber.Text,
                Convert.ToInt32(Session["relationship"]), txtFamilyFirstName.Text, txtFamilySurname.Text, txtFamilyDateOfBirth.Text, Convert.ToInt32(Session["fGender"]), Convert.ToInt32(Session["fNational"]), txtFamilyContactNumber.Text, txtExtraNotes.Text,
                txtHouseNumber.Text, txtStreetAddress.Text, txtTown.Text, txtSurburb.Text, Convert.ToInt32(txtPostalCode.Text), txtProvince.Text,
                txtAdmissionDate.Text, txtDischargeDate.Text, Convert.ToInt32(Session["statutoryID"]), txtCourtOrderExpires.Text, Convert.ToInt32(Session["socialWorkerID"]), Convert.ToInt32(Session["childCareWorkerID"])
            );
                txtError.Visible = true;
                txtError.Text = "User Registration Successful";
            }
            else
            {
                TextValidation();
                txtError.Visible = true;
                txtError.Text = "Incorrect Inputs";
            }
        }

    }
}