using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class ViewRefills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rxNum = Request.QueryString["RXNum"];
                if (!string.IsNullOrEmpty(rxNum))
                {
                    LoadRefills(rxNum);
                }
                else
                {
                    lblStatus.Text = "No prescription selected?";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadRefills(string rxNum)
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                DataSet ds = dataTier.ViewRefillsByPrescription(int.Parse(rxNum));

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvRefills.DataSource = ds;
                    gvRefills.DataBind();
                }
                else
                {
                    gvRefills.DataSource = null;
                    gvRefills.DataBind();
                    lblStatus.Text = "No refills found for this prescription.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void btnAddRefill_Click(object sender, EventArgs e)
        {
            string rxNum = Request.QueryString["RXNum"];

            if (!string.IsNullOrEmpty(rxNum))
            {
                try
                {
                    PharmacyDataTier dataTier = new PharmacyDataTier();
                    bool success = dataTier.AddRefill(int.Parse(rxNum));

                    if (success)
                    {
                        lblStatus.Text = "Refill added successfully.";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        LoadRefills(rxNum); // Refresh the list
                    }
                    else
                    {
                        lblStatus.Text = "Failed to add refill.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "An error occurred: " + ex.Message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "No prescription selected.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvRefills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRefills.PageIndex = e.NewPageIndex;

            string rxNum = Request.QueryString["RXNum"];
            if (!string.IsNullOrEmpty(rxNum))
            {
                LoadRefills(rxNum);
            }
        }
        protected void btnSubRefill_Click(object sender, EventArgs e)
        {
            string rxNum = Request.QueryString["RXNum"];

            if (!string.IsNullOrEmpty(rxNum))
            {
                try
                {
                    PharmacyDataTier dataTier = new PharmacyDataTier();
                    bool success = dataTier.SubtractRefill(int.Parse(rxNum));

                    if (success)
                    {
                        lblStatus.Text = "Refill subtracted and logged successfully.";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        LoadRefills(rxNum);
                    }
                    else
                    {
                        lblStatus.Text = "Failed to subtract refill.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "An error occurred: " + ex.Message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "No prescription selected.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrescriptionList.aspx");
        }
    }
}