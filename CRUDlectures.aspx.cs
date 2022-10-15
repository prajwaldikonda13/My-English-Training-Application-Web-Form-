using My_English_Training_Application_Web_Form_.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace My_English_Training_Application_Web_Form_
{
    public partial class CRUDLectures : System.Web.UI.Page
    {
       
        static List<Lectures> list;
        private static long lastLectureID = 0;
        private static long firstLectureID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                    list = dbContext.lectures.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                bindData();
            }
            else
            {
                grid.EditIndex = -1;
            }
        }

        private void bindData()
        {
            if(list.Count>0)
            {
                lastLectureID = list.Last().ID;
                firstLectureID = list.First().ID;
            }
            else
            {
                lastLectureID = 0;
                firstLectureID = 0;
            }
            grid.DataSource = list;
            grid.DataBind();
        }

        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grid.EditIndex = -1;
            bindData();
        }

        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                dbContext.lectures.Attach(list[e.RowIndex]);
                dbContext.lectures.Remove(list[e.RowIndex]);
                dbContext.SaveChanges();
            }

            list.RemoveAt(e.RowIndex);
            bindData();
        }

        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Lectures lecture = list[e.RowIndex];
            TextBox txtLectureName = grid.Rows[e.RowIndex].FindControl("txtLectureName") as TextBox;
            TextBox txtDescription = grid.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
            TextBox txtURL = grid.Rows[e.RowIndex].FindControl("txtURL") as TextBox;
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                var update = dbContext.Entry(lecture);
                dbContext.lectures.Attach(lecture);
                lecture.LectureName = txtLectureName.Text;
                lecture.Description = txtDescription.Text;
                lecture.VideoURL = txtURL.Text;
                update.CurrentValues.SetValues(lecture);
                dbContext.SaveChanges();
            }
               
            grid.EditIndex = -1;
            bindData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.lectures.Where(s => s.ID > lastLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                if (list.Count == 0)
                    list = dbContext.lectures.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            }
                
            bindData();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.lectures.OrderByDescending(s => s.ID).Where(s => s.ID < firstLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
                if (list.Count == 0)
                    list = dbContext.lectures.OrderByDescending(s => s.ID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
            }
                
            bindData();
        }
        protected void drpTake_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
                list = dbContext.lectures.Where(s => s.ID >= firstLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            bindData();
        }
    }
}