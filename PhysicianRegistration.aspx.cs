using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;
using ProjectName;

namespace FinalTest1
{
    public partial class PhysicianRegistration : Page
    {
        private PharmacyDataTier dataTier = new PharmacyDataTier();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetNextPhysicianID();
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "FullAndAbbrev";
                ddlState.DataValueField = "abbreviation";
                ddlState.SelectedValue = "PA";
                ddlState.DataBind();
            }
        }

        private void SetNextPhysicianID()
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            int nextID = dataTier.GetNextPhysicianID();
            txtPhysicianCode.Text = nextID.ToString();
            txtPhysicianCode.Enabled = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                lblStatus.Text = "First Name is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lblStatus.Text = "Last Name is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDOB.Text))
            {
                lblStatus.Text = "Date of Birth is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlGender.SelectedValue == "")
            {
                lblStatus.Text = "Please select a gender.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStreetName.Text))
            {
                lblStatus.Text = "Street Name is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                lblStatus.Text = "City is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlState.SelectedValue == "")
            {
                lblStatus.Text = "Please select a state.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtZip.Text))
            {
                lblStatus.Text = "Zip Code is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblStatus.Text = "Email is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                lblStatus.Text = "Phone Number is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSpecialty1.Text))
            {
                lblStatus.Text = "Email is required.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string physicianCode = txtPhysicianCode.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string dob = txtDOB.Text.Trim();
            string gender = ddlGender.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string streetName = txtStreetName.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = ddlState.Text.Trim();
            string zip = txtZip.Text.Trim();
            string specialty1 = txtSpecialty1.Text.Trim();
            string specialty2 = txtSpecialty2.Text.Trim();

            try
            {
                PharmacyDataTier phDT = new PharmacyDataTier();

                phDT.PhysicianRegistration(physicianCode, firstName, middleInitial, lastName, dob, gender,
                                           phoneNumber, email, streetName, city, state, zip, specialty1, specialty2);

                ClearFields();
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Physician registered successfully!";
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Registration failed: " + ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPhysicianCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMiddleInitial.Text = string.Empty;
            txtDOB.Text = string.Empty;
            ddlGender.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtSpecialty1.Text = string.Empty;
            txtSpecialty2.Text = string.Empty;
            lblStatus.Text = string.Empty;
        }

        private void ClearFields()
        {
            txtPhysicianCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMiddleInitial.Text = string.Empty;
            txtDOB.Text = string.Empty;
            ddlGender.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 33;
            txtZip.Text = string.Empty;
            txtSpecialty1.Text = string.Empty;
            txtSpecialty2.Text = string.Empty;
            lblStatus.Text = string.Empty;
            txtPhysicianCode.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtMiddleInitial.Enabled = false;
            txtDOB.Enabled = false;
            ddlGender.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtEmail.Enabled = false;
            txtStreetName.Enabled = false;
            txtCity.Enabled = false;
            ddlState.Enabled = false;
            txtZip.Enabled = false;
            txtSpecialty1.Enabled = false;
            txtSpecialty2.Enabled = false;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianList.aspx");
        }
    }
}