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
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "FullAndAbbrev";
                ddlState.DataValueField = "abbreviation";
                ddlState.SelectedValue = "PA";
                ddlState.DataBind();
            }
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

                // Call Data Tier Method
                dataTier.PatientRegistration(patientID, firstName, middleInt, lastName, dob, gender, phoneNumber, email, streetName, city, state, zip, primaryInsurance, secondaryInsurance);

                lblStatus.Text = "Patient registered successfully!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }
    }
}