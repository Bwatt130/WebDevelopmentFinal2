using ProjectName;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class UpdatePhysician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPhysicianCode.Enabled = false;
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "FullAndAbbrev";
                ddlState.DataValueField = "abbreviation";
                ddlState.SelectedValue = "PA";
                ddlState.DataBind();
                string physicianID = Request.QueryString["PhysicianID"];
                rvDOB.MaximumValue = DateTime.Now.ToString("yyyy/MM/dd");
                if (!string.IsNullOrEmpty(physicianID))
                {
                    LoadPhysicianData(physicianID);
                }
            }
        }
        private void LoadPhysicianData(string physicianID)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds = dataTier.GetPhysicianByID(physicianID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtPhysicianCode.Text = physicianID;
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtMiddleInitial.Text = row["MiddleInitial"].ToString();
                txtStreetName.Text = row["StreetName"].ToString();
                txtCity.Text = row["City"].ToString();
                ddlState.SelectedValue = row["State"].ToString();
                txtZip.Text = row["ZipCode"].ToString();
                txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                txtEmail.Text = row["Email"].ToString();
                ddlGender.SelectedValue = row["Gender"].ToString();

                DateTime dob;
                if (DateTime.TryParse(row["DOB"].ToString(), out dob))
                {
                    txtDOB.Text = dob.ToString("yyyy-MM-dd");
                }

                txtSpecialty1.Text = row["Specialty1"].ToString();
                txtSpecialty2.Text = row["Specialty2"].ToString();
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                string physicianID = "";
                string firstName = "";
                string lastName = "";
                string middleInitial = "";

                DateTime dob;
                if (!DateTime.TryParse(txtDOB.Text, out dob) || dob < new DateTime(1753, 1, 1) || dob > DateTime.Today)
                {
                    lblStatus.Text = "Invalid date. Date must be between 1753/01/01 and today.";
                    
                    lblStatus.Visible = true;
                    return;
                }

                string gender = ddlGender.SelectedValue;
                string phoneNumber = "";
                string email = "";
                string streetName = "";
                string city = "";
                string state = "";
                string zipCode = "";
                string primarySpecialty = "";
                string secondarySpecialty = "";

                physicianID = txtPhysicianCode.Text.Trim();
                firstName = txtFirstName.Text.Trim();
                lastName = txtLastName.Text.Trim();
                middleInitial = txtMiddleInitial.Text.Trim();
                gender = ddlGender.SelectedValue;
                phoneNumber = txtPhoneNumber.Text.Trim();
                email = txtEmail.Text.Trim();
                streetName = txtStreetName.Text.Trim();
                city = txtCity.Text.Trim();
                state = ddlState.SelectedValue;
                zipCode = txtZip.Text.Trim();
                primarySpecialty = txtSpecialty1.Text.Trim();
                secondarySpecialty = txtSpecialty2.Text.Trim();

                bool success = dataTier.UpdatePhysician(physicianID, firstName, lastName, middleInitial, dob, gender, phoneNumber, email, streetName, city, state, zipCode, primarySpecialty, secondarySpecialty);
                
                if (success)
                {
                    ClearFields();
                    lblStatus.Text = "Physician information updated successfully.";
                    
                    lblStatus.Visible = true;
                }
                else
                {
                    lblStatus.Text = "Failed to update physician information.";
                    
                    lblStatus.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
                
            }
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