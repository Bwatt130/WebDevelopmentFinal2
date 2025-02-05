using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class FinalMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnPrescriptions_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrescriptionList.aspx");
        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }

        protected void btnRefill_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewRefills.aspx");
        }

        protected void btnUpdatePhysician_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianList.aspx");
        }
    }
}