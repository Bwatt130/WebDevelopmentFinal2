using ProjectName;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetNextPatientID();
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "FullAndAbbrev";
                ddlState.DataValueField = "abbreviation";
                ddlState.SelectedValue = "PA";
                ddlState.DataBind();
            }
        }

        private void SetNextPatientID()
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            int nextID = dataTier.GetNextPatientID();
            txtPatientID.Text = nextID.ToString();
            txtPatientID.Enabled = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();

                string patientID = txtPatientID.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string middleInt = txtMiddleInt.Text.Trim();
                string streetName = txtStreetName.Text.Trim();
                string city = txtCity.Text.Trim();
                string state = ddlState.SelectedValue;
                string zip = txtZip.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string email = txtEmail.Text.Trim();
                string gender = ddlGender.SelectedValue;
                string dob = txtDOB.Text.Trim();
                string primaryInsurance = txtPrimaryInsurance.Text.Trim();
                string secondaryInsurance = txtSecondaryInsurance.Text.Trim();

                dataTier.PatientRegistration(patientID, firstName, middleInt, lastName, dob, gender, phoneNumber, email, streetName, city, state, zip, primaryInsurance, secondaryInsurance);

                ClearFields();
                lblStatus.Text = "Patient registered successfully!";
                
                lblStatus.Visible = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
                
            }
        }

        private void ClearFields()
        {
            txtPatientID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMiddleInt.Text = string.Empty;
            txtDOB.Text = string.Empty;
            ddlGender.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 33;
            txtZip.Text = string.Empty;
            txtPrimaryInsurance.Text = string.Empty;
            txtSecondaryInsurance.Text = string.Empty;
            lblStatus.Text = string.Empty;
            txtPatientID.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtMiddleInt.Enabled = false;
            txtDOB.Enabled = false;
            ddlGender.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtEmail.Enabled = false;
            txtStreetName.Enabled = false;
            txtCity.Enabled = false;
            ddlState.Enabled = false;
            txtZip.Enabled = false;
            txtPrimaryInsurance.Enabled = false;
            txtSecondaryInsurance.Enabled = false;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }
    }
}