using KPopZtation_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
	public partial class InsertArtist : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
			ArtistController artistController = new ArtistController();

			string name = tbName.Text;

			string errorMessage;

			artistController.validateInsertion(name, fileUploadImage, out errorMessage);
		

			if (!string.IsNullOrEmpty(errorMessage))
			{
				lbErrorMessage.Text = errorMessage;
				return;
			}

			Response.Redirect("HomePage.aspx");
		}

		protected void btnBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("HomePage.aspx");
		}
	}
}