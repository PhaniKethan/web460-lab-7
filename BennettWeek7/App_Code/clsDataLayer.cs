/*Steven Bennett Week 6 Lab*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{
    public clsDataLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //GetAllAddresses() accepts the Path of the Access db and returns a data set.
    public dsAddress GetAllAddresses(string Path)
    {
        //create the variables that will hold the data set, connection string, and query.
        dsAddress DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        //create new OleDbConnection object that holds the connection string.
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Path);

        //create new OleDbDataAdapter object that contains query to return all records from tblAddressBook.
        sqlDA = new OleDbDataAdapter("select * from tblAddressBook;", sqlConn);

        //instantiate new dsAddress object.
        DS = new dsAddress();

        //calls the Fill() method to add/refresh records in the data set to match the data source.
        sqlDA.Fill(DS.tblAddressBook);

        //returns the dataset object.
        return DS;
    }

    //Method that inserst data from the text boxes on the form into the database. 
    public void InsertAddress(string Path, string first, string last, string phone, string email)
    {
        //variables to hold connetion string, SQL command, INSERT statement, the parameters for the table columns.
        OleDbConnection sqlConn;
        OleDbCommand oCommand;
        string stmt;
        OleDbParameter param;

        //Opens database connection.
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Path);
        sqlConn.Open();
        oCommand = new OleDbCommand();
        oCommand.Connection = sqlConn;

        //INSERT to be executed with the data from the form.
        stmt = "INSERT INTO tblAddressBook (FirstName, LastName, Email, PhoneNumber) VALUES (@first, @last, @email, @phone)";

        //enables to the data from the text boxes on the form to be utilized in the INSERT statement.
        param = new OleDbParameter();
        param.ParameterName = "@first";
        param.Value = first;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@last";
        param.Value = last;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@email";
        param.Value = email;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@phone";
        param.Value = phone;
        oCommand.Parameters.Add(param);

        //Takes the INSERT SQL statement and executes it.
        oCommand.CommandText = stmt;
        oCommand.CommandType = CommandType.Text;
        oCommand.ExecuteNonQuery();

        //closes database connection.
        sqlConn.Close();
    }

    public dsAddress FindAddress(string Path, int AddressId)
    {
        //create a new OleDbConnection objec and pass in connection string.
        OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + "");

        //create a SQL query to search for AddressId.  Convert the argument that is passed in to a string.
        string sql = "select * from tblAddressBook WHERE AddressId = " + Convert.ToString(AddressId);
        OleDbDataAdapter sqlDA = new OleDbDataAdapter(sql, sqlConn);

        //create a new dsAddress object and fill it with the records returned from the sql query.
        dsAddress ds = new dsAddress();
        sqlDA.Fill(ds.tblAddressBook);

        return ds;
    }

    public void UpdatAddress(string Path, int AddressId, string first, string last, string phone, string email)
    {
        //create new OleDbConnection object and pass in connection string.  Then open database connection.
        OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + "");
        sqlConn.Open();

        //create new OleDbCommand object.  set oCommand connection to sqlConn.
        OleDbCommand oCommand = new OleDbCommand();
        oCommand.Connection = sqlConn;

        string stmt = "UPDATE tblAddressBook SET FirstName = @first, " + "LastName = @last, Email = @email, PhoneNumber = " +
            "@phone WHERE (tblAddressBook.AddressId = @id)";

        //use OleDbParmeter to pass in the new values desired to update a record with.
        OleDbParameter param;

        param = new OleDbParameter();
        param.ParameterName = "@first";
        param.Value = first;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@last";
        param.Value = last;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@email";
        param.Value = email;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@phone";
        param.Value = phone;
        oCommand.Parameters.Add(param);

        param = new OleDbParameter();
        param.ParameterName = "@id";
        param.Value = AddressId;
        oCommand.Parameters.Add(param);

        //set the CommandText property of oCommand to stmt and call the ExecuteNonQuery() method.
        oCommand.CommandText = stmt;
        oCommand.CommandType = CommandType.Text;
        oCommand.ExecuteNonQuery();

        //close the database connection.
        sqlConn.Close();


    }

    //method GetUser retrieves and validates login information against the database tblUsers.
    public bool GetUser(string Path, string userID, string password)
    {
        OleDbConnection dbConn = new OleDbConnection();

        try
        {
            //stores connection string to database
            string strConnection = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path;
            dbConn = new OleDbConnection(strConnection);
            dbConn.Open();

            //store SQL statement to all unlocked users from table.
            string strSQL = "SELECT * FROM tblUsers WHERE UserID=? AND Password=? AND Locked=FALSE";

            //create OleDbCommand object and add parameters UserId, Password, and Locked.
            OleDbCommand dbCmd;
            dbCmd = new OleDbCommand(strSQL, dbConn);

            dbCmd.Parameters.Add(new OleDbParameter("UserID", userID));
            dbCmd.Parameters.Add(new OleDbParameter("Password", password));
            //add password parameter and default is false.
            dbCmd.Parameters.Add(new OleDbParameter("Locked", false));

            //use OleDbDataReader to read information back from Login attempt. Will return true if successful read.
            OleDbDataReader dr = dbCmd.ExecuteReader();
            return (dr.Read());
        }
        catch (Exception ex) //throw excetion if error happens.
        {
            throw ex;
        }
        finally
        {
            //close database connection no matter what happens.
            dbConn.Close();
        }


    }

    //method to lock user account.
    public void LockUserAcct(string Path, string userID)
    {
        //create new OleDbConnection object and pass in connection string.  Then open database connection.
        OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + "");
        sqlConn.Open();

        //create new OleDbCommand object.  set oCommand connection to sqlConn.
        OleDbCommand oCommand = new OleDbCommand();
        oCommand.Connection = sqlConn;

        string stmt = "UPDATE tblUsers SET Locked = true WHERE (tblUsers.userID = @userID)";

        //use OleDbParmeter to pass in the new values desired to update a record with.
        OleDbParameter param;

        param = new OleDbParameter();
        param.ParameterName = "@userID";
        param.Value = userID;
        oCommand.Parameters.Add(param);

        //set the CommandText property of oCommand to stmt and call the ExecuteNonQuery() method.
        oCommand.CommandText = stmt;
        oCommand.CommandType = CommandType.Text;
        oCommand.ExecuteNonQuery();

        //close database connection.
        sqlConn.Close();
    }
}