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

namespace FinalTest1
{
    public partial class PatientList : System.Web.UI.Page
    {
        private PharmacyDataTier patientData = new PharmacyDataTier();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                lblError.ForeColor = System.Drawing.Color.Red;
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
            gvPatients.PageIndex = e.NewPageIndex; // Set the new page index
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
            DataSet ds = new PharmacyDataTier().ListPatients();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataView dv = ds.Tables[0].DefaultView;
                dv.Sort = e.SortExpression + " ASC";

                gvPatients.DataSource = dv;
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