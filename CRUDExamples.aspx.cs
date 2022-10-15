using My_English_Training_Application_Web_Form_.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace My_English_Training_Application_Web_Form_
{
    public partial class CRUDExamples : System.Web.UI.Page
    {
        static List<Examples> list;
        private static long lastExampleID = 0;
        private static long firstExampleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using(DatabaseContext dbContext =new DatabaseContext())
                {
                    list = dbContext.examples.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                    bindData();
                }
                
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
                lastExampleID = list.Last().ID;
                firstExampleID = list.First().ID;
            }
            else
            {
                lastExampleID = 0;
                firstExampleID = 0;
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
                dbContext.examples.Attach(list[e.RowIndex]);
                dbContext.examples.Remove(list[e.RowIndex]);
                dbContext.SaveChanges();
            }
                list.RemoveAt(e.RowIndex);
            bindData();
        }

        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Examples example = list[e.RowIndex];
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                var update = dbContext.Entry(example);
                TextBox txtExample = grid.Rows[e.RowIndex].FindControl("txtExample") as TextBox;
                dbContext.examples.Attach(example);

                example.Example = txtExample.Text;
                update.CurrentValues.SetValues(example);
                dbContext.SaveChanges();
            }
            grid.EditIndex = -1;
            bindData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.examples.Where(s => s.ID > lastExampleID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                if (list.Count == 0)
                    list = dbContext.examples.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            }
            bindData();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.examples.OrderByDescending(s => s.ID).Where(s => s.ID < firstExampleID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
                if (list.Count == 0)
                    list = dbContext.examples.OrderByDescending(s => s.ID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
            }

            bindData();
        }

        protected void drpTake_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
                list = dbContext.examples.Where(s => s.ID >= firstExampleID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            bindData();
        }
    }
}