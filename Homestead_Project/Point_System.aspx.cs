using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homestead_Project
{
    public partial class Point_System : System.Web.UI.Page
    {
		int totatPoints;
		SqlConnection sqlConnection = null;
		DB_Manager dbConn = new DB_Manager();
		DataTable dtbl = new DataTable();
		DataTable dtblTotalPoints = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
        {
			
        }

		//populate Points View gridview with query this will be inputting all the points tables into the gridview
		protected void PopulatePointsSystemGridViewWithData()
		{
			try
			{
				ClearGridView();
				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();


				string sql = "SELECT c.fileNumber, c.childName, c.childSurname, a.activityDate, a.activityDescription, p.allocatedPointValue, p.reasonForPoints FROM tbl_Points p, tbl_Activity a, tbl_Child c WHERE p.fileNumber = c.fileNumber AND p.activityID = a.activityID";

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtbl);

				if (dtbl.Rows.Count > 0)
				{
					PointsSystemGridView.DataSource = dtbl;
					PointsSystemGridView.DataBind();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		//order History by input
		protected void PopulatePointsSystemOrder(string orderBy)
		{
			try
			{
				ClearGridView();
				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();

				string sql = "SELECT c.fileNumber, c.childName, c.childSurname, a.activityDate, a.activityDescription, p.allocatedPointValue, p.reasonForPoints FROM tbl_Points p, tbl_Activity a, tbl_Child c WHERE p.fileNumber = c.fileNumber AND p.activityID = a.activityID order by '" + orderBy;

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtbl);

				if (dtbl.Rows.Count > 0)
				{
					PointsSystemGridView.DataSource = dtbl;
					PointsSystemGridView.DataBind();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		//populate the drop down list(Working)
		public void FillHistoryComboBox()
		{
			try
			{
				//open connection
				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();

				//datatable
				string sql = "SELECT facilityID, facilityName FROM tbl_Facility";

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtblTotalPoints);

				//set datasource to data table
				DropDownOrderbyCriteria.DataSource = dtblTotalPoints;
				DropDownOrderbyCriteria.DataTextField = "facilityName";
				DropDownOrderbyCriteria.DataValueField = "facilityID";
				DropDownOrderbyCriteria.DataBind();

				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


		}

		//populate the modify child points gridview order the listed data by activity date
		public void PopulateModifyChildPointsGridView()
		{
			try
			{
				GridViewModifyChildPoints.DataSource = null;

				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();

				string sql = "SELECT p.pointsID, c.fileNumber, c.childName, c.childSurname, a.activityDate, a.activityDescription, p.allocatedPointValue, p.reasonForPoints FROM tbl_Points p, tbl_Activity a, tbl_Child c WHERE p.fileNumber = c.fileNumber AND p.activityID = a.activityID and c.fileNumber ='" + TextBoxModifyPoints.Text + "'";

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtbl);

				if (dtbl.Rows.Count > 0)
				{
					GridViewModifyChildPoints.DataSource = dtbl;
					GridViewModifyChildPoints.DataBind();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}

		}

		protected void ClearGridView()
		{
			PointsSystemGridView.DataSource = null;
			PointsSystemGridView.DataBind();
		}
		//clear total points gridView
		protected void ClearTotalPointsGridView()
		{
			TotalPointsGridView.DataSource = null;
			TotalPointsGridView.DataBind();
		}

		//search method for history(The query will bring back a result set of ll the points that have beeen added. by the fileNumber of the child)
		protected void SearchForHistoryFromFileNumber()
		{
			try
			{
				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();

				string sql = "SELECT c.fileNumber, c.childName, c.childSurname, a.activityDate, a.activityDescription, p.allocatedPointValue, p.reasonForPoints FROM tbl_Points p, tbl_Activity a, tbl_Child c WHERE p.fileNumber = c.fileNumber AND p.activityID = a.activityID and c.fileNumber ='" + SearchBoxId.Text + "'";

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtbl);

				if (dtbl.Rows.Count > 0)
				{
					PointsSystemGridView.DataSource = dtbl;
					PointsSystemGridView.DataBind();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		//total points of each child id that is searched. Join tables child and points. Display the fileNumber, childName, childSurname, and sum(Points)
		protected void SearchForChildTotalPoints_Click(Object sender, EventArgs e)
		{
			try
			{
				ClearTotalPointsGridView();
				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();

				string sql = "select c.fileNumber, c.childName,c.childSurname, sum(allocatedPointValue) as 'Total Points' from tbl_Child c, tbl_Points p where p.fileNumber = c.fileNumber and p.fileNumber ='" + TotalPointsTxtBox.Text + "'group by c.fileNumber, c.childName, c.childSurname";

				SqlDataAdapter sqlCmd = new SqlDataAdapter(sql, sqlConnection);

				sqlCmd.Fill(dtblTotalPoints);

				if (dtblTotalPoints.Rows.Count > 0)
				{
					TotalPointsGridView.DataSource = dtblTotalPoints;
					TotalPointsGridView.DataBind();
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{//close connection
				sqlConnection.Close();
			}
		}

		//viewPoiontsHistory
		protected void ModifyPoints_Click(object sender, EventArgs e)
		{

			if (ViewTotalPoints.Visible == false)
			{
				ViewTotalPoints.Visible = true;
			}
			else
			{
				ViewTotalPoints.Visible = false;
			}
		}

		//populate modify child points gridview with child information
		protected void btnModifyPointsSeachChild_Click(object sender, EventArgs e)
		{
			PopulateModifyChildPointsGridView();
		}

		//on off for displaying the gridview
		protected void ViewHistory_Click(object sender, EventArgs e)
		{
			if (gridViewData.Visible == false)
			{
				gridViewData.Visible = true;

				PopulatePointsSystemGridViewWithData();
				FillHistoryComboBox();
			}
			else
			{
				gridViewData.Visible = false;
			}
		}

		protected void ModifyPointsBtn_Click(object sender, EventArgs e)
		{

			if (ModifyChildPoints.Visible == false)
			{
				ModifyChildPoints.Visible = true;
			}
			else
			{
				ModifyChildPoints.Visible = false;
			}
		}

		//click event for searching for points history by file Number
		protected void Search_Click(Object sender, EventArgs e)
		{

			SearchForHistoryFromFileNumber();

		}

		//click even for reset button on View points history
		protected void btnReset_Click(object sender, EventArgs e)
		{

			PopulatePointsSystemGridViewWithData();

		}

		//row updating in child modify points. Updating data
		protected void GridViewModifyChildPoints_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{

			try
			{
				TextBox TextBoxPoints = GridViewModifyChildPoints.Rows[e.RowIndex].FindControl("TextBoxPoints") as TextBox;
				Label id = GridViewModifyChildPoints.Rows[e.RowIndex].FindControl("apointNumber") as Label;

				sqlConnection = dbConn.MakeConnection(sqlConnection);
				sqlConnection.Open();
				//update tabele
				SqlCommand cmd = new SqlCommand("update tbl_Points set allocatedPointValue='" + Convert.ToInt32(TextBoxPoints.Text) + "' where pointsID=" + Convert.ToInt32(id.Text), sqlConnection);
				cmd.ExecuteNonQuery();
				//close connection
				sqlConnection.Close();
				//cancel edit mode
				GridViewModifyChildPoints.EditIndex = -1;

				PopulateModifyChildPointsGridView();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


		}

		// editing a field in a column row(working)(Only allow the editing of the childs points) https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview.rowediting?view=netframework-4.8 ()
		protected void GridViewModifyChildPoints_RowEditing(object sender, GridViewEditEventArgs e)
		{

			//Set the edit index.
			GridViewModifyChildPoints.EditIndex = e.NewEditIndex;
			//Bind data to the GridView control.
			PopulateModifyChildPointsGridView();

		}
		//cancel all editing on gridview(Working)
		protected void GridViewModifyChildPoints_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			//Reset the edit index.
			GridViewModifyChildPoints.EditIndex = -1;
			//Bind data to the GridView control.
			PopulateModifyChildPointsGridView();

		}
		//change sql string depending on index of the drop down list. index = facility id
		protected void DropDownOrderbyCriteria_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedItemValue = DropDownOrderbyCriteria.DataValueField;
			//get id of combo box

			//populate the list by the selected combobox value
			PopulatePointsSystemOrder(selectedItemValue);

		}










	}
}