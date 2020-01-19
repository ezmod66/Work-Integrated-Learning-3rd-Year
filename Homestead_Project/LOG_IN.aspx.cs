using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class LOG_IN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Log_In(object sender, EventArgs e)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (txtUsername.Text != "" && txtPassword.Text != "")   
			{
                if (Regex.IsMatch(txtUsername.Text, pattern))
                {
                    IList<Employee> logIn = new DB_Manager().userLogIn(txtUsername.Text, txtPassword.Text);

                    if (logIn.Count > 0)
                    {
                        foreach (Employee employeeDetails in logIn)
                        {
                            if (employeeDetails.EmployeeStatusID.Equals(1))
                            {
                                Response.Redirect("HOME_PAGE.aspx");
                            }
                        }
                    }
                    else
                    {
                        txtErrorMessage.Visible = true;
                        txtErrorMessage.Text = "Incorrect username or Password";
                    }
                }
                else
                {
                    txtErrorMessage.Visible = true;
                    txtErrorMessage.Text = "Incorrect/Invalid Email";
                }
				
			} else
			{
                txtErrorMessage.Visible = true;
                txtErrorMessage.Text = "Please input username or password";

			}	
			
        }

        protected void Forgot_Password(object sender, EventArgs e)
        {

        }

    }
}