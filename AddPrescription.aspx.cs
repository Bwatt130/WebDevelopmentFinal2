using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class Prescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patientID = Request.QueryString["PatientID"];
                if (!string.IsNullOrEmpty(patientID))
                {
                    txtPatientID.Text = patientID;
                    txtPatientID.Enabled = false;
                }
                LoadPhysicianIDs();
            }
        }

        private void LoadPhysicianIDs()
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                DataSet ds = dataTier.GetPhysicianIDs(); 

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cbPhysicianID.DataSource = ds.Tables[0];
                    cbPhysicianID.DataTextField = "PhysicianName"; 
                    cbPhysicianID.DataValueField = "PhysicianID";  
                    cbPhysicianID.DataBind();
                }

                cbPhysicianID.Items.Insert(0, new ListItem("-- Select Physician --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading physicians: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string patientID = Request.QueryString["PatientID"];
            string physicianID = cbPhysicianID.SelectedValue;
            string medicationName = txtMedName.Text.Trim();
            string dosage = txtDosage.Text.Trim();
            string frequency = txtFrequency.Text.Trim();
            string administrationRoute = string.Empty;

            if (rbOral.Checked) administrationRoute = "Oral";
            else if (rbTopical.Checked) administrationRoute = "Topical";
            else if (rbInjection.Checked) administrationRoute = "Injection";

            int refillCount;
            if (!int.TryParse(txtRefillAmt.Text.Trim(), out refillCount))
            {
                lblMessage.Text = "Invalid refill count. Please enter a valid number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(patientID) || string.IsNullOrEmpty(physicianID) || string.IsNullOrEmpty(medicationName) ||
                string.IsNullOrEmpty(dosage) || string.IsNullOrEmpty(frequency) || string.IsNullOrEmpty(administrationRoute))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!rbOral.Checked && !rbTopical.Checked && !rbInjection.Checked)
            {
                lblMessage.Text = "Route of administration is required.";
                return;
            }


            PharmacyDataTier dataTier = new PharmacyDataTier();
            dataTier.AddPrescription(patientID, physicianID, medicationName, dosage, frequency, administrationRoute, refillCount);

            lblMessage.Text = "Prescription added successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("PrescriptionList.aspx?PatientID=" + txtPatientID.Text);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }

        protected void ValidateRoute(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rbOral.Checked || rbTopical.Checked || rbInjection.Checked;
        }
    }
}