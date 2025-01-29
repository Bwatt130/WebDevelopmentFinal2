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
        protected void LoadPhysicians()
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
                    lblStatus.Text = "No physicians found.";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading physicians: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}