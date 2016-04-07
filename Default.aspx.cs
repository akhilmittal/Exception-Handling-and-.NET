using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string textValue = txtId.Text;
        int id;
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        try
        {
            if (!Int32.TryParse(textValue, out id))
                throw new ApplicationException("Please provide correct student id.");
            if (id <= 0 || id >= 5)
                throw new ApplicationException("No user exists with the specified id, please enter another id between 1 to 5");
            SqlCommand sqlCommand = new SqlCommand("Select StudentID,Fnamn,Enamn,Email,Login,Password from egStudents where StudentId=" +
           id.ToString(), sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlConnection.Open();
            sqlDataAdapter.Fill(dataSet);
            grdStudentView.DataSource = dataSet.Tables[0];
            grdStudentView.DataBind();
        }
        catch (ApplicationException exception)
        {
            lblErrorDisplay.Visible = true;
            lblErrorDisplay.Text = exception.Message;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            sqlConnection.Close();
            sqlDataAdapter.Dispose();
        }
    }
}
