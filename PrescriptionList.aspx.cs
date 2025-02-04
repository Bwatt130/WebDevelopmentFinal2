using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                LoadPrescriptions();
            }
        }

        private void LoadPrescriptions()
        {
            try
            {
                PharmacyDataTier dataTier = new PharmacyDataTier();
                DataSet ds = dataTier.ListPrescriptions();

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

        protected void gvPrescriptions_Sorting(object sender, GridViewSortEventArgs e)
        {
            // Get the prescriptions from the database
            PharmacyDataTier dataTier = new PharmacyDataTier();
            DataSet ds = dataTier.ListPrescriptions();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                dt.DefaultView.Sort = e.SortExpression;
                gvPrescriptions.DataSource = dt;
                gvPrescriptions.DataBind();
            }
        }

        protected void gvPrescriptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPrescription")
            {
                string rxNum = e.CommandArgument.ToString();
                Response.Redirect("EditPrescription.aspx?RXNum=" + rxNum);
            }
            else if (e.CommandName == "ViewRefills")
            {
                string rxNum = e.CommandArgument.ToString();
                Response.Redirect("ViewRefills.aspx?RXNum=" + rxNum);
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