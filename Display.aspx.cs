using My_English_Training_Application_Web_Form_.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace My_English_Training_Application_Web_Form_
{
    public partial class Display : System.Web.UI.Page
    {
        private static long lastLectureID = 0;
        private static long firstLectureID = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Lectures> list;
                using (DatabaseContext dbContext = new DatabaseContext())
                    list = dbContext.lectures.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                bindData(list);
            }
        }

        private void bindData(List<Lectures> lecturesList)
        {
            if(lecturesList.Count>0)
            {
                lastLectureID = lecturesList.Last().ID;
                firstLectureID = lecturesList.First().ID;
            }
            else
            {
                lastLectureID = 0;
                firstLectureID = 0;
            }
            rptLectures.DataSource = lecturesList;
            rptLectures.DataBind();
        }

        protected void rptLectures_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                long lectureID = (e.Item.DataItem as Lectures).ID;
                Repeater rptWords = e.Item.FindControl("rptWords") as Repeater;
                using (DatabaseContext dbContext = new DatabaseContext())
                    rptWords.DataSource = dbContext.phrasesOrWords.Where(s => s.LectureID == lectureID).ToList();
                rptWords.DataBind();
            }
        }

        protected void rptWords_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                long wordID = (e.Item.DataItem as PhrasesOrWords).ID;
                Repeater rptExamples = e.Item.FindControl("rptExamples") as Repeater;
                using (DatabaseContext dbContext = new DatabaseContext())
                    rptExamples.DataSource = dbContext.examples.Where(s => s.WordOrPhraseID == wordID).ToList();
                rptExamples.DataBind();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            List<Lectures> list = new List<Lectures>();

            using (DatabaseContext dbContext = new DatabaseContext())
            {
               list = dbContext.lectures.Where(s => s.ID > lastLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                if (list.Count == 0)
                    list = dbContext.lectures.Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                bindData(list);
            }


        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            List<Lectures> list = new List<Lectures>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                list = dbContext.lectures.OrderByDescending(s => s.ID).Where(s => s.ID < firstLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
                if (list.Count == 0)
                    list = dbContext.lectures.OrderByDescending(s => s.ID).Take(Convert.ToInt32(drpTake.SelectedValue)).OrderBy(s => s.ID).ToList();
                bindData(list);
            }

        }
        protected void drpTake_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lectures> list = new List<Lectures>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
               list = dbContext.lectures.Where(s => s.ID >= firstLectureID).Take(Convert.ToInt32(drpTake.SelectedValue)).ToList();
                bindData(list);
            }
               
        }

        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            List<Lectures> list = new List<Lectures>();
            using (DatabaseContext dbContext = new DatabaseContext())
                list.AddRange(dbContext.lectures.Where(l => l.LectureName.Contains(txtFilter.Text)));
            bindData(list);
        }
    }
}