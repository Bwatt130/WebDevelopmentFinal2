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
                DataSet ds = dataTier.ListPhysicians(); // Fetch physician data

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
                    lblError.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading physicians: " + ex.Message;
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void gvPhysicians_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhysicians.PageIndex = e.NewPageIndex; // Set the new page index
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