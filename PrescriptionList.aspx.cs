using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class PrescriptionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PatientID"] != null)
                {
                    ViewState["PatientID"] = Request.QueryString["PatientID"];
                }
                LoadPrescriptions();
            }
        }

        private void LoadPrescriptions()
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                DataSet ds = dataTier.ListPrescriptions();

                if (ViewState["PatientID"] != null)
                {
                    string patientID = Convert.ToString(ViewState["PatientID"]);
                    ds = dataTier.ListPrescriptionsByPatient(patientID);
                } 
                else
                {
                    ds = dataTier.ListPrescriptions();
                }
                
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPrescriptions.DataSource = ds;
                    gvPrescriptions.DataBind();
                }
                else
                {
                    gvPrescriptions.DataSource = null;
                    gvPrescriptions.DataBind();
                    lblStatus.Text = "No prescriptions found.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds;

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string dob = txtDOB.Text.Trim();
            DateTime? dobValue = null;

            if (!string.IsNullOrEmpty(dob))
            {
                dobValue = DateTime.Parse(dob);
            }

            if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName) || !string.IsNullOrEmpty(dob))
            {
                ds = dataTier.ListPrescriptionsByPatientInfo(firstName, lastName, dobValue?.ToString("yyyy-MM-dd"));
            }
            else
            {
                ds = dataTier.ListPrescriptions();
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPrescriptions.DataSource = ds;
                gvPrescriptions.DataBind();
            }
            else
            {
                gvPrescriptions.DataSource = null;
                gvPrescriptions.DataBind();
                lblStatus.Text = "No prescriptions found.";
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDOB.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            LoadPrescriptions();
        }
        protected void gvPrescriptions_Sorting(object sender, GridViewSortEventArgs e)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();

            string sortExpression = e.SortExpression;
            string sortDirection = (ViewState["SortDirection"] as string == "ASC") ? "DESC" : "ASC";
            ViewState["SortDirection"] = sortDirection;

            string patientID = Request.QueryString["PatientID"];
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string dob = txtDOB.Text.Trim();

            DataTable dt = dataTier.GetPrescriptions(patientID, firstName, lastName, dob, sortExpression, sortDirection);

            if (dt != null)
            {
                gvPrescriptions.DataSource = dt;
                gvPrescriptions.DataBind();
            }
        }

        protected void gvPrescriptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int rxNum))
            {
                if (e.CommandName == "AddRefill")
                {
                    PharmacyDataTier dataTier = new PharmacyDataTier();
                    try
                    {
                        bool success = dataTier.AddRefill(rxNum);

                        if (success)
                        {
                            lblStatus.Text = "Refill subtracted and logged successfully.";
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            LoadPrescriptions();
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
                else if (e.CommandName == "SubtractRefill")
                {
                    PharmacyDataTier dataTier = new PharmacyDataTier();
                    try
                    {
                        bool success = dataTier.SubtractRefill(rxNum);

                        if (success)
                        {
                            lblStatus.Text = "Refill subtracted and logged successfully.";
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            LoadPrescriptions();
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
                else if (e.CommandName == "EditPrescription")
                {
                    string patientID = ViewState["PatientID"] != null ? ViewState["PatientID"].ToString() : string.Empty;
                    string redirectUrl = "EditPrescription.aspx?RXNum=" + rxNum;

                    if (!string.IsNullOrEmpty(patientID))
                    {
                        redirectUrl += "&PatientID=" + patientID;
                    }

                    Response.Redirect(redirectUrl);
                }
                else if (e.CommandName == "ViewRefills")
                {
                    string patientID = ViewState["PatientID"] != null ? ViewState["PatientID"].ToString() : string.Empty;
                    string redirectUrl = "ViewRefills.aspx?RXNum=" + rxNum;

                    if (!string.IsNullOrEmpty(patientID))
                    {
                        redirectUrl += "&PatientID=" + patientID;
                    }

                    Response.Redirect(redirectUrl);
                }
                else
                {
                    lblStatus.Text = "Invalid prescription number.";
                }
            }
        }

        protected void btnAddPrescription_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPrescription.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalMainPage.aspx");
        }
    }
}