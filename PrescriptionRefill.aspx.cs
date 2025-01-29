using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;

namespace FinalTest1
{
    public partial class PrescriptionRefill : Page
    {
        private PharmacyDataTier dataTier = new PharmacyDataTier();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRXNumbers();
            }
        }

        private void LoadRXNumbers()
        {
            try
            {
                DataSet ds = dataTier.GetAllPrescriptions(); // Call DataTier to get all prescriptions
                cboRX.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string rxNum = row["RXNum"].ToString();
                    cboRX.Items.Add(new ListItem(rxNum, rxNum)); // Add RX numbers to the dropdown list
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading RX numbers: " + ex.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string rxNum = cboRX.SelectedValue;

            if (string.IsNullOrEmpty(rxNum))
            {
                lblMessage.Text = "Please select a valid RX number.";
                return;
            }

            try
            {
                // Fetch refills associated with the selected RX number
                int rxNumInt = Int32.Parse(rxNum);
                DataSet refills = dataTier.GetRefillsRXNum(rxNumInt);

                if (refills.Tables[0].Rows.Count > 0)
                {
                    dgvPrescriptions.DataSource = refills.Tables[0];
                    dgvPrescriptions.Visible = true;
                }
                else
                {
                    lblMessage.Text = "No refills found for the selected RX number.";
                    dgvPrescriptions.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error searching refills: " + ex.Message;
            }
        }

        protected void btnAddRefill_Click(object sender, EventArgs e)
        {
            string rxNum = cboRX.SelectedValue;

            if (string.IsNullOrEmpty(rxNum))
            {
                lblMessage.Text = "Please select a valid RX number.";
                return;
            }

            try
            {
                int rxNumInt = Int32.Parse(rxNum);
                dataTier.AddRefill(rxNumInt); // Call DataTier to add a refill

                lblMessage.Text = "Refill added successfully!";
                btnSearch_Click(sender, e); // Refresh refills after adding a refill
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error adding refill: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string rxNum = cboRX.SelectedValue;

            if (string.IsNullOrEmpty(rxNum))
            {
                lblMessage.Text = "Please select a valid RX number.";
                return;
            }

            try
            {
                int rxNumInt = Int32.Parse(rxNum);
                dataTier.DeleteRefill(rxNumInt); // Call DataTier to delete the refill

                lblMessage.Text = "Refill deleted successfully!";
                btnSearch_Click(sender, e); // Refresh refills after deletion
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error deleting refill: " + ex.Message;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalMainPage.aspx");
        }
    }
}