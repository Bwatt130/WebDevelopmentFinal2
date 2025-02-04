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
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "FullAndAbbrev";
                ddlState.DataValueField = "abbreviation";
                ddlState.SelectedValue = "PA";
                ddlState.DataBind();
                string physicianID = Request.QueryString["PhysicianID"];
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
                txtPhysicianID.Text = physicianID;
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtMiddleInitial.Text = row["MiddleInitial"].ToString();
                txtStreetName.Text = row["StreetName"].ToString();
                txtCity.Text = row["City"].ToString();
                ddlState.SelectedValue = row["State"].ToString();
                txtZipCode.Text = row["ZipCode"].ToString();
                txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                txtEmail.Text = row["Email"].ToString();
                ddlGender.SelectedValue = row["Gender"].ToString();
                txtDOB.Text = row["DOB"].ToString();
                txtSpecialty1.Text = row["Specialty1"].ToString();
                txtSpecialty2.Text = row["Specialty2"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();

                string physicianID = txtPhysicianID.Text;
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string middleInitial = txtMiddleInitial.Text.Trim();

                DateTime dob;
                if (!DateTime.TryParse(txtDOB.Text, out dob))
                {
                    lblStatus.Text = "Invalid date format.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string gender = ddlGender.SelectedValue;
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string email = txtEmail.Text.Trim();
                string streetName = txtStreetName.Text.Trim();
                string city = txtCity.Text.Trim();
                string state = ddlState.SelectedValue;
                string zipCode = txtZipCode.Text.Trim();
                string specialty1 = txtSpecialty1.Text.Trim();
                string specialty2 = txtSpecialty2.Text.Trim();

                bool success = dataTier.UpdatePhysician(physicianID, firstName, middleInitial, lastName, streetName, city, state, zipCode, phoneNumber, email, gender, dob.ToString("yyyy-MM-dd"), specialty1, specialty2);

                if (success)
                {
                    lblStatus.Text = "Physician information updated successfully.";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatus.Text = "Failed to update physician information.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianList.aspx");
        }
    }
}