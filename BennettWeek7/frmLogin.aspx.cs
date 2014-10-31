/*Steven Bennett Week 7 Lab*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //create a boolean variable to indicate is userID and password combination is found.
        bool IsFound = false;

        clsDataLayer dl = new clsDataLayer();

        //set IsFound to true or false based on what is returned from GetUser.
        IsFound = dl.GetUser(Server.MapPath("~/App_Data/AddressBook.mdb"), txtUserID.Text, txtPassword.Text);

        //test if IsFound is true or fasle.  If true redirect to frmUdpdateAddress.aspx. if false redirect to frmLogin.aspx and increment attempts counter.
        if (IsFound)
        {
            //provide user access and redirect to frmUpdateAddress.aspx.
            Response.Redirect("~/frmUpdateAddress.aspx");
        }
        else
        {
            //create variable to hold session object's AttemptCount.  Increment counter by 1.
            int myAttempts = Convert.ToInt32(Session["AttemptCount"]);
            myAttempts = myAttempts + 1;
            Session["AttemptCount"] = myAttempts;

            //update lblStatus to reflect the log in attempt failed.
            lblStatus.Text = "The User ID and/or Password supplied is incorrect.  Please try again!";

            //lock out user if number of invalid login attempts is 3 or greater
            if (myAttempts >= 3)
            {
                //Code that locks user account.
                dl.LockUserAcct(Server.MapPath("~/App_Data/AddressBook.mdb"), txtUserID.Text);

                //update status message to indicate that the account is locked.
                lblStatus.Text = "Your account is disabled.";
            }
        }
    }
}