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
                if (Request.QueryString["RXNum"] != null)
                {
                    string rxNum = Request.QueryString["RXNum"];
                    LoadRefills(rxNum);
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
    }
}