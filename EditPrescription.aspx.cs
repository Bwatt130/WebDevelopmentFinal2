using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class EditPrescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RXNum"] != null)
                {
                    string rxNum = Request.QueryString["RXNum"];
                    LoadPrescription(rxNum);
                }
            }
        }

        private void LoadPrescription(string rxNum)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataRow row = dataTier.GetPrescriptionByID(int.Parse(rxNum));

            if (row != null)
            {
                hfRXNum.Value = rxNum;
                txtDosage.Text = row["Dosage"].ToString();
                txtFrequency.Text = row["Frequency"].ToString();
                txtMedicationName.Text = row["MedicationName"].ToString();
                txtPrescriptionDate.Text = row["PrescriptionDate"].ToString();
                ddlAdministrationRoute.SelectedValue = row["AdministrationRoute"].ToString();
                txtRefillCount.Text = row["REFILLCOUNT"].ToString();
            }
            else
            {
                lblStatus.Text = "Prescription not found.";
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                bool success = dataTier.ModifyPrescription(
                    int.Parse(hfRXNum.Value),
                    txtDosage.Text.Trim(),
                    txtFrequency.Text.Trim(),
                    txtMedicationName.Text.Trim(),
                    txtPrescriptionDate.Text.Trim(),
                    ddlAdministrationRoute.SelectedValue,
                    int.Parse(txtRefillCount.Text.Trim())
                );

                if (success)
                {
                    ClearFields();
                    lblStatus.Text = "Prescription updated successfully.";
                    
                    lblStatus.Visible = true;
                   
                }
                else
                {
                    lblStatus.Text = "Failed to update prescription.";
                    
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
                
            }
        }

        public void ClearFields()
        {
            txtDosage.Enabled = false;
            txtFrequency.Enabled = false;
            txtMedicationName.Enabled = false;
            txtPrescriptionDate.Enabled = false;
            txtRefillCount.Enabled = false;
            ddlAdministrationRoute.Enabled = false;
            txtDosage.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            txtMedicationName.Text = string.Empty;
            txtPrescriptionDate.Text = string.Empty;
            txtRefillCount.Text = string.Empty;
            ddlAdministrationRoute.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string patientID = Request.QueryString["PatientID"];
            string redirectUrl = "PrescriptionList.aspx";

            if (!string.IsNullOrEmpty(patientID))
            {
                redirectUrl += "?PatientID=" + patientID;
            }

            Response.Redirect(redirectUrl);
        }
    }
}