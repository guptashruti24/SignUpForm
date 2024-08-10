using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Form2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            SqlConnection con = new SqlConnection(sqlConnectionString);

            try
            {

                string query = @"
                INSERT INTO Form Data (FirstName, MiddleName, LastName, PhoneNumber, DateOfBirth, EmailID,  Address, , Sex, Stream)
                VALUES (@FirstName, @MiddleName, @LastName, @PhoneNumber, @DateOfBirth , @EmailID, @Address @Sex, @Stream)";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@MiddleName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@LastName", TextBox3.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox4.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(TextBox5.Text));

                cmd.Parameters.AddWithValue("@EmailID", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Address", TextBox7.Text);
                string sex = "";
                if (RadioButton1.Checked)
                {
                    sex = "Male";
                }
                else if (RadioButton2.Checked)
                {
                    sex = "Female";
                }


                cmd.Parameters.AddWithValue("@Sex", sex);

                cmd.Parameters.AddWithValue("@Stream", DropDownList1.SelectedValue);


                con.Open();


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Label2.Text = "Successfully inserted!";

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    RadioButton1.Checked = false;

                    RadioButton2.Checked = false;
                    DropDownList1.SelectedIndex = 0;
                }
                else
                {
                    Label2.Text = "No rows were inserted. Please check your data.";
                }
            }
            catch (SqlException ex)
            {
                Label1.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
    
