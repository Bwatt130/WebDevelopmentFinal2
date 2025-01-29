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
                DropDownList1.DataSource = StateManager.getStates();
                DropDownList1.DataTextField = "FullAndAbbrev";
                DropDownList1.DataValueField = "abbreviation";
                DropDownList1.SelectedValue = "PA";
                DropDownList1.DataBind();
            }
            else
            {
                if (Request.Form["btnClear"] != null)
                {
                    ClearFields();
                    lblStatus.Text = "Cleared!";
                    lblStatus.Visible = true;
                }
                else
                {
                    lblStatus.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string physicianCode = txtPhysicianCode.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string dob = txtDOB.Text.Trim();
            string gender = txtGender.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string streetName = txtStreetName.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = DropDownList1.Text.Trim();
            string zip = txtZip.Text.Trim();
            string specialty1 = txtSpecialty1.Text.Trim();
            string specialty2 = txtSpecialty2.Text.Trim();

            // Basic validation for mandatory fields
            if (string.IsNullOrEmpty(physicianCode) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(dob))
            {
                lblStatus.Text = "Physician ID, Last Name, and Date of Birth are required!";
                return;
            }

            try
            {
                PharmacyDataTier phDT = new PharmacyDataTier();

                phDT.PhysicianRegistration(physicianCode, firstName, middleInitial, lastName, dob, gender,
                                           phoneNumber, email, streetName, city, state, zip, specialty1, specialty2);

                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Physician registered successfully!";
                ClearFields();
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
            txtGender.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            DropDownList1.Text = string.Empty;
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
            txtGender.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            DropDownList1.SelectedIndex = 33;
            txtZip.Text = string.Empty;
            txtSpecialty1.Text = string.Empty;
            txtSpecialty2.Text = string.Empty;
            lblStatus.Text = string.Empty;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalMainPage.aspx");
        }
    }
}