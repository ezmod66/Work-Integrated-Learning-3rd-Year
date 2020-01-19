using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Update_Child_Details : System.Web.UI.Page
    {
        //Declare Variables
        bool updating;
        int childID, genderID, nationalityID, lStatusID, facilityID, statutoryID, childCareWorkerID, socialWorkerID, fNationalityID, fGenderID, relationshipID, schoolID, familyID, addressID;
        string fileNumber;

        DB_Manager updateDetails = new DB_Manager();

        SqlConnection SqlConn = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              

                getChildNames();
                    FillComboBox();
                
            }
        }

        public void getChildNames()
        {
            IList<ChildFullName> childnames = new DB_Manager().GetChildNames();
            if (childnames != null)
            {
                cbChildNames.DataSource = childnames;
                cbChildNames.DataTextField = "childFullname";
                cbChildNames.DataValueField = "childID";
                cbChildNames.DataBind();
            }
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

   

        protected void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            genderID = Convert.ToInt32(cbGender.SelectedValue);
        }

        protected void cbChildNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileNumber = cbChildNames.SelectedValue;
            getChild(fileNumber);
           
        }

        public void getChild(string fileNumber)
        {

            IList<ChildClass> childDetails = new DB_Manager().GetChildDetails(fileNumber);
            if (childDetails.Count > 0)
            {

                foreach (ChildClass childList in childDetails)
                {
                    DateTime DOB = Convert.ToDateTime(childList.Dob);
                    DateTime courtDate = Convert.ToDateTime(childList.CourtOrderDate);
                    DateTime addDate = Convert.ToDateTime(childList.AddmissionDate);
                    DateTime exitDate = Convert.ToDateTime(childList.ExitDate);
                    //startdate.ToString("dddd, dd MMMM yyyy");
                    //lblDate.Text += activityList.ActivityDescription + "        " + startdate.ToString("dddd, dd MMMM yyyy") + "        " + activityList.ActivityTime + "<br/>";
                    Session["schoolID"] = childList.SchoolID;
                    Session["familyID"] = childList.FamilyID;
                    Session["addressID"] = childList.AddressID;
                    Session["childID"] = childList.ChildID;

                    txtFirstName.Text = childList.ChildName;
                    txtSurnname.Text = childList.ChildSurname;
                    cbSWorker.ClearSelection();
                    cbSWorker.Items.FindByValue(childList.SocialWorkerID.ToString()).Selected = true;
                    Session["socialWorkerID"] = Convert.ToInt32(cbSWorker.SelectedValue);

                    cbCWorker.ClearSelection();
                    cbCWorker.Items.FindByValue(childList.ChildWorkerID.ToString()).Selected = true;
                    Session["childCareWorkerID"] = Convert.ToInt32(cbCWorker.SelectedValue);

                    txtFileNumber.Text = childList.FileNumber;
                    cbStatutory.ClearSelection();
                    cbStatutory.Items.FindByValue(childList.StatutoryID.ToString()).Selected = true;
                    Session["statutoryID"] = Convert.ToInt32(cbStatutory.SelectedValue);

                    cbRelationship.ClearSelection();
                    cbRelationship.Items.FindByValue(childList.RelationshipID.ToString()).Selected = true;
                    Session["relationship"] = Convert.ToInt32(cbRelationship.SelectedValue);

                    cbFalicities.ClearSelection();
                    cbFalicities.Items.FindByValue(childList.FacilityID.ToString()).Selected = true;
                    Session["facility"] = Convert.ToInt32(cbFalicities.SelectedValue);

                    txtDOB.Text = DOB.ToString("dddd, dd MMMM yyyy");

                    cbGender.ClearSelection();
                    cbGender.Items.FindByValue(childList.GenderID.ToString()).Selected = true;
                    cbFamilyGender.ClearSelection();
                    cbFamilyGender.Items.FindByValue(childList.FamilyGender.ToString()).Selected = true;
                    txtSchoolName.Text = childList.SchoolName;
                    txtSchoolContactNumber.Text = childList.SchoolContactNumber;

                    cbNationality.ClearSelection();
                    cbNationality.Items.FindByValue(childList.Nationality.ToString()).Selected = true;
                    Session["nationality"] = Convert.ToInt32(cbNationality.SelectedValue);

                    cbLegalStatus.ClearSelection();
                    cbLegalStatus.Items.FindByValue(childList.LegalStatus.ToString()).Selected = true;
                    Session["legalStatus"] = Convert.ToInt32(cbLegalStatus.SelectedValue);

                    txtFamilyFirstName.Text = childList.FamilyFirstName;
                    txtFamilySurname.Text = childList.FamilySurname;
                    txtFamilyContactNumber.Text = childList.ContactNumber;
                    txtExtraNotes.Text = childList.FamilyNote;
                    txtHouseNumber.Text = childList.HouseNumber.ToString();
                    txtStreetName.Text = childList.StreetName;
                    txtSuburb.Text = childList.Suburb;
                    txtTown.Text = childList.Town;
                    txtCourtOrderExpires.Text = courtDate.ToString("dddd, dd MMMM yyyy");
                    txtAdmissionDate.Text = addDate.ToString("dddd, dd MMMM yyyy"); ;
                    txtDischargeDate.Text = exitDate.ToString("dddd, dd MMMM yyyy");
                    txtYearsInShelter.Text = childList.YearsInShelter.ToString();
                    txtProvince.Text = childList.Province.ToString();
                    txtPostalCode.Text = childList.PostalCode.ToString();

                }

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

       
   
        public void updateChildDetails(int schoolID, int familyID, int addressID, int childID, string fileNumber, string childName, string childSurname, string childDateOfBirth, int nationalityID, int lStatusID, int facilityID, string schoolName, string schoolContactNum,
                                    int familyDesc, string firstName, string lastName, string familyDateOfBirth, int fGenderID, int fNationalityID, string contactNumber, string familyNotes,
                                    string houseNumber, string streetName, string town, string surburb, int postalCode, string province,
                                    string admissionDate, string exitDate, int statutoryID, string coutOrderDate, int socialWorkerID, int childCareWorkerID)
        {
          
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (updateDetails.UpdateChildDetails(Convert.ToInt32(Session["schoolID"]), Convert.ToInt32(Session["familyID"]), Convert.ToInt32(Session["addressID"]), Convert.ToInt32(Session["childID"]), txtFileNumber.Text, txtFirstName.Text, txtSurnname.Text, txtDOB.Text, Convert.ToInt32(Session["nationality"]), Convert.ToInt32(Session["legalStatus"]), Convert.ToInt32(Session["facility"]), txtSchoolName.Text, txtSchoolContactNumber.Text, Convert.ToInt32(Session["relationship"]), txtFamilyFirstName.Text,
                                               txtFamilySurname.Text, txtFamilyContactNumber.Text, txtExtraNotes.Text, txtHouseNumber.Text, txtStreetName.Text, txtTown.Text, txtSuburb.Text, Convert.ToInt32(txtPostalCode.Text), txtProvince.Text, txtAdmissionDate.Text,
                                               txtDischargeDate.Text, Convert.ToInt32(Session["statutoryID"]), txtCourtOrderExpires.Text, Convert.ToInt32(Session["socialWorkerID"]), Convert.ToInt32(Session["childCareWorkerID"])).Equals(true))
            {
                txtTrue.Text = "Updating Successfull";
                getChildNames();
            } else
            {
                txtTrue.Text = "Updating Failed";
            }
                
           
            
        }

    }
}