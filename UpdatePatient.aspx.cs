using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class UpdatePatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patientID = Request.QueryString["PatientID"];
                if (!string.IsNullOrEmpty(patientID))
                {
                    LoadPatientData(patientID);
                }
            }
        }

        private void LoadPatientData(string patientID)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds = dataTier.GetPatientByID(patientID); // A method to fetch patient details

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtMiddleInt.Text = row["MiddleInitial"].ToString();
                txtStreetName.Text = row["StreetName"].ToString();
                txtCity.Text = row["City"].ToString();
                txtState.Text = row["State"].ToString();
                txtZip.Text = row["ZipCode"].ToString();
                txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtGender.Text = row["Gender"].ToString();
                txtDOB.Text = Convert.ToDateTime(row["DOB"]).ToString("yyyy-MM-dd");
                txtPrimaryInsurance.Text = row["PrimaryInsurance"].ToString();
                txtSecondaryInsurance.Text = row["SecondaryInsurance"].ToString();
                txtPatientID.Text = patientID;
                txtPatientID.Enabled = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();

                string patientID = txtPatientID.Text;
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string middleInt = txtMiddleInt.Text;
                DateTime dob;
                if (!DateTime.TryParse(txtDOB.Text, out dob))
                {
                    lblStatus.Text = "Invalid date format.";
                    return;
                }
                string gender = txtGender.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string email = txtEmail.Text;
                string streetName = txtStreetName.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string zip = txtZip.Text;
                string primaryInsurance = txtPrimaryInsurance.Text;
                string secondaryInsurance = txtSecondaryInsurance.Text;

                bool success = dataTier.UpdatePatient(patientID, firstName, middleInt, lastName, dob, gender, phoneNumber, email, streetName, city, state, zip, primaryInsurance, secondaryInsurance);

                lblStatus.Text = success ? "Patient information updated successfully." : "Failed to update patient information.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }
    }
}