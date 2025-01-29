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

        protected void btnPatientRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientRegistration.aspx");
        }

        protected void btnPrescription_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prescription.aspx");
        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList.aspx");
        }

        protected void btnPrescriptionRefill_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrescriptionRefill.aspx");
        }

        protected void btnPhysicianRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianRegistration.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // Close functionality does not directly apply in a web application.
            Response.Redirect("Goodbye.aspx");
        }

        protected void btnUpdatePhysician_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePhysician.aspx");
        }
    }
}