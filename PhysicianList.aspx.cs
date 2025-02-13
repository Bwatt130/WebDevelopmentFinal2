using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class PhysicianList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                LoadPhysicianData();
                BindPhysicianGrid();
            }
        }
        protected void LoadPhysicianData()
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                DataSet ds = dataTier.ListPhysicians();

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPhysicians.DataSource = ds;
                    gvPhysicians.DataBind();
                }
                else
                {
                    gvPhysicians.DataSource = null;
                    gvPhysicians.DataBind();
                    lblError.Text = "No physicians found.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading physicians: " + ex.Message;
                lblError.Visible = true;
            }
        }
        protected void gvPhysicians_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhysicians.PageIndex = e.NewPageIndex;
            BindPhysicianGrid();
        }

        private void BindPhysicianGrid()
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds = dataTier.ListPhysicians();

            if (ds != null && ds.Tables.Count > 0)
            {
                gvPhysicians.DataSource = ds.Tables[0];
                gvPhysicians.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();
            string physicianID = txtPhysicianID.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            DataSet ds = dataTier.SearchPhysicians(physicianID, firstName, lastName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPhysicians.DataSource = ds.Tables[0];
                gvPhysicians.DataBind();
            }
            else
            {
                gvPhysicians.DataSource = null;
                gvPhysicians.DataBind();
                lblError.Text = "No matching records found.";
                lblError.Visible = true;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPhysicianID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            LoadPhysicianData();
        }


        protected void gvPhysicians_Sorting(object sender, GridViewSortEventArgs e)
        {
            PharmacyDataTier dataTier = new PharmacyDataTier();

            string sortExpression = e.SortExpression;
            string sortDirection = (ViewState["SortDirection"] as string == "ASC") ? "DESC" : "ASC";
            ViewState["SortDirection"] = sortDirection;

            string physicianID = ViewState["PhysicianID"] != null ? ViewState["PhysicianID"].ToString() : txtPhysicianID.Text.Trim();
            string firstName = ViewState["FirstName"] != null ? ViewState["FirstName"].ToString() : txtFirstName.Text.Trim();
            string lastName = ViewState["LastName"] != null ? ViewState["LastName"].ToString() : txtLastName.Text.Trim();

            DataTable dt = dataTier.GetPhysicians(physicianID, firstName, lastName, sortExpression, sortDirection);

            if (dt != null)
            {
                gvPhysicians.DataSource = dt;
                gvPhysicians.DataBind();
            }
        }

        protected void gvPhysicians_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPhysician")
            {
                string physicianID = e.CommandArgument.ToString();
                Response.Redirect("UpdatePhysician.aspx?PhysicianID=" + physicianID);
            }
        }

        protected void btnRegisterNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianRegistration.aspx");
        }
        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalMainPage.aspx");
        }
    }
}