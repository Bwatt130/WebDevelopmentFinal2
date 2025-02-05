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
                txtAdministrationRoute.Text = row["AdministrationRoute"].ToString();
                txtRefillCount.Text = row["REFILLCOUNT"].ToString();
            }
            else
            {
                lblStatus.Text = "Prescription not found.";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                bool success = dataTier.ModifyPrescription(
                    int.Parse(hfRXNum.Value),
                    txtDosage.Text.Trim(),
                    txtFrequency.Text.Trim(),
                    txtMedicationName.Text.Trim(),
                    txtPrescriptionDate.Text.Trim(),
                    txtAdministrationRoute.Text.Trim(),
                    int.Parse(txtRefillCount.Text.Trim())
                );

                if (success)
                {
                    lblStatus.Text = "Prescription updated successfully.";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatus.Text = "Failed to update prescription.";
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
            Response.Redirect("PrescriptionList.aspx");
        }
    }
}