using My_English_Training_Application_Web_Form_.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace My_English_Training_Application_Web_Form_
{
    public partial class CRUDPhrases : System.Web.UI.Page
    {
       
        static List<PhrasesOrWords> list;
        private static long lastPhraseID = 0;
        private static long firstPhraseID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                    list = dbContext.phrasesOrWords.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
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
                lastPhraseID = list.Last().ID;
                firstPhraseID = list.First().ID;
            }
            else
            {
                lastPhraseID = 0;
                firstPhraseID = 0;
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
                dbContext.phrasesOrWords.Attach(list[e.RowIndex]);
                dbContext.phrasesOrWords.Remove(list[e.RowIndex]);
                dbContext.SaveChanges();
            }
                
            list.RemoveAt(e.RowIndex);
            bindData();
        }

        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PhrasesOrWords phrase = list[e.RowIndex];
            TextBox txtPhrase = grid.Rows[e.RowIndex].FindControl("txtPhrase") as TextBox;
            TextBox txtDescription = grid.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                var update = dbContext.Entry(phrase);
                dbContext.phrasesOrWords.Attach(phrase);
                phrase.PhraseOrWord = txtPhrase.Text;
                phrase.Description = txtDescription.Text;
                update.CurrentValues.SetValues(phrase);
                dbContext.SaveChanges();
            }
                
            grid.EditIndex = -1;
            bindData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.phrasesOrWords.Where(s => s.ID > lastPhraseID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                if (list.Count == 0)
                    list = dbContext.phrasesOrWords.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            }
                
            bindData();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.phrasesOrWords.OrderByDescending(s => s.ID).Where(s => s.ID < firstPhraseID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
                if (list.Count == 0)
                    list = dbContext.phrasesOrWords.OrderByDescending(s => s.ID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
            }
                
            bindData();
        }
        protected void drpTake_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
                list = dbContext.phrasesOrWords.Where(s => s.ID >= firstPhraseID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
            bindData();
        }
    }
}