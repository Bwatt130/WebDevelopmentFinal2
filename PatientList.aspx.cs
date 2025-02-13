using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Runtime.InteropServices.ComTypes;

namespace FinalTest1
{
    public partial class PatientList : System.Web.UI.Page
    {
        private PharmacyDataTier patientData = new PharmacyDataTier();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                LoadPatientData();
                BindPatientsGrid();
            }
        }

        private void LoadPatientData()
        {
            try
            {
                DataSet ds = patientData.ListPatients();
                if (ds != null && ds.Tables.Count > 0)
                {
                    gvPatients.DataSource = ds.Tables[0];
                    gvPatients.DataBind();
                }
                else
                {
                    gvPatients.DataSource = null;
                    gvPatients.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading patients: " + ex.Message;
                
                lblError.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string patientID = txtPatientID.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            DataSet ds = patientData.SearchPatients(patientID, firstName, lastName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPatients.DataSource = ds.Tables[0];
                gvPatients.DataBind();
            }
            else
            {
                gvPatients.DataSource = null;
                gvPatients.DataBind();
                lblError.Text = "No matching records found.";
                lblError.Visible = true;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPatientID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            LoadPatientData();
        }


        protected void gvPatients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string patientID = e.CommandArgument.ToString();

            if (e.CommandName == "UpdatePatient")
            {
                Response.Redirect("UpdatePatient.aspx?PatientID=" + patientID);
            }
        }

        protected void btnViewPrescriptions_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string patientID = btn.CommandArgument;
            Response.Redirect("PrescriptionList.aspx?PatientID=" + patientID);
        }

        protected void btnAddPrescription_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string patientID = btn.CommandArgument;
            Response.Redirect("AddPrescription.aspx?PatientID=" + patientID);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            string patientID = btn.CommandArgument;
            Response.Redirect("UpdatePatient.aspx?PatientID=" + patientID);
        }

        protected void gvPatients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPatients.PageIndex = e.NewPageIndex;
            BindPatientsGrid();
        }
        private void BindPatientsGrid()
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds = dataTier.ListPatients();

            if (ds != null && ds.Tables.Count > 0)
            {
                gvPatients.DataSource = ds.Tables[0];
                gvPatients.DataBind();
            }
        }
        protected void gvPatients_Sorting(object sender, GridViewSortEventArgs e)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();

            string sortExpression = e.SortExpression;
            string sortDirection = (ViewState["SortDirection"] as string == "ASC") ? "DESC" : "ASC";
            ViewState["SortDirection"] = sortDirection;

            string patientID = ViewState["PatientID"] != null ? ViewState["PatientID"].ToString() : txtPatientID.Text.Trim();
            string firstName = ViewState["FirstName"] != null ? ViewState["FirstName"].ToString() : txtFirstName.Text.Trim();
            string lastName = ViewState["LastName"] != null ? ViewState["LastName"].ToString() : txtLastName.Text.Trim();

            DataTable dt = dataTier.GetPatients(patientID, firstName, lastName, sortExpression, sortDirection);

            if (dt != null)
            {
                gvPatients.DataSource = dt;
                gvPatients.DataBind();
            }
        }
        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalMainPage.aspx"); 
        }

        protected void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientRegistration.aspx");
        }
    }
}