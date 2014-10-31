/*Steven Bennett Week 7 Lab*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmUpdateAddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //test if page is being loaded for the first time do database is not getting hit during every request.
        if (!Page.IsPostBack)
        {
            //call BindGridView method on dsAddress objec. if page is loaded for the first time.
            dsAddress addressSet = BindGridView();
        }
    }

    private dsAddress BindGridView()
    {
        //TempPath to hold the location of the database.
        string TempPath;
        TempPath = Server.MapPath("App_Data/AddressBook.mdb");

        //instantiate new clsDataLayer object.
        clsDataLayer oDataLayer = new clsDataLayer();

        //call the GetAllAddresses method and pass in TempPath for the argument.  returns a data set to be stroed in myAddressSet.
        dsAddress myAddressSet = oDataLayer.GetAllAddresses(TempPath);

        //assign the data source to the grid view from the data set.
        gvAddresses.DataSource = myAddressSet.tblAddressBook;

        //bind the grid view to the data source.
        gvAddresses.DataBind();

        //return the data set.
        return myAddressSet;
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //instantiate new clsDataLayer object.
        clsDataLayer myDataLayer = new clsDataLayer();

        //string to hold location of database.
        string TempPath = Server.MapPath("App_Data/AddressBook.mdb");

        //call the method in clsDataLayer Object and pass in arguments from the text boxes on the form.
        myDataLayer.InsertAddress(TempPath, txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, txtEmail.Text);

        //bind the grid view with the newly added information.
        BindGridView();
    }

    protected void cmdFind_Click(object sender, EventArgs e)
    {
        //creates a new data access layer object.
        clsDataLayer myDAL = new clsDataLayer();
        dsAddress myAddressSet;

        //call the FindAddress method in the data access layer and store the results in myAddressSet.
        myAddressSet = (myDAL.FindAddress(Server.MapPath("~/App_Data/AddressBook.mdb"), Convert.ToInt32(txtAddressId.Text)));
        lblStatus.Text = string.Empty;

        //if the above operation returns a myAddressSet that is not null and contains a row then display the information in the forms textboxes.
        if (!(myAddressSet == null) && (myAddressSet.tblAddressBook.Rows.Count != 0))
        {
            this.txtFirstName.Text = myAddressSet.tblAddressBook[0].FirstName.ToString();
            this.txtLastName.Text = myAddressSet.tblAddressBook[0].LastName.ToString();
            this.txtEmail.Text = myAddressSet.tblAddressBook[0].Email.ToString();
            this.txtPhoneNumber.Text = myAddressSet.tblAddressBook[0].PhoneNumber.ToString();

            Session.Add("ValidRecord", true);
        }
        else
        {
            //dislay a message in the status label that no record was found.
            lblStatus.Text = "No record was found";
            Session.Add("ValidRecord", false); 
        }

        BindGridView();
    }


    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        //create new data access layer object.
        clsDataLayer myDAL = new clsDataLayer();

        //check the session state value for ValidRecord.  If true call the UpdateAddress record which will update the record in the database.
        if (Convert.ToBoolean(Session["ValidRecord"]))
        {
            //call the Update Address method in myDAL clsDataLayer object.
            myDAL.UpdatAddress(Server.MapPath("~/App_Data/AddressBook.mdb"), Convert.ToInt32(txtAddressId.Text), txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, txtEmail.Text);
        }

        BindGridView();
    }
}