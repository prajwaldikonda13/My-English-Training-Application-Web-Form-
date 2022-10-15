using My_English_Training_Application_Web_Form_.Database_Models;
using System;

namespace My_English_Training_Application_Web_Form_
{
    public partial class Default : System.Web.UI.Page
    {
        static long lectureID=0;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSetLecture_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                
                txtLectureName.Attributes.Add("readonly", "readonly");
                txtLectureDescription.Attributes.Add("readonly", "readonly");
                txtURL.Attributes.Add("readonly", "readonly");
                Lectures lecture = new Lectures { LectureName = txtLectureName.Text, Description = txtLectureDescription.Text, VideoURL = txtURL.Text };
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.lectures.Add(lecture);
                    dbContext.SaveChanges();
                }
                    
                lectureID = lecture.ID;
                lblInfo.Text = "Lecture has been set successfully!!!!!";
                btnSetLecture.Attributes.Add("disabled", "disabled");
                test.Attributes.Add("class", "alert alert-success");
            }
            else
            {
                lblInfo.Text = "Please check Lecture Name,URL and Description.";
                test.Attributes.Add("class", "alert alert-danger");

            }
        }

        protected void btnAddPhrase_Click(object sender, EventArgs e)
        {
            if (lectureID>0)
            {
                PhrasesOrWords phrasesOrWords = new PhrasesOrWords() { PhraseOrWord = txtPhraseOrWord.Text, Description = txtPhraseDescription.Text, LectureID = lectureID };
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.phrasesOrWords.Add(phrasesOrWords);
                    dbContext.SaveChanges();
                    string examplesString = txtExamples.Text.Trim();
                    if (examplesString != string.Empty)
                    {
                        foreach (string str in examplesString.Split('\n'))
                        {
                            dbContext.examples.Add(new Examples { Example = str, WordOrPhraseID = phrasesOrWords.ID });
                        }
                        dbContext.SaveChanges();
                    }
                }
                   
                txtPhraseOrWord.Text = "";
                txtPhraseDescription.Text = "";
                txtExamples.Text = "";
                lblInfo.Text = "Word and examples added successfully!!!";
                test.Attributes.Add("class", "alert alert-success");
            }
            else
            {
                lblInfo.Text = "Please first set the lecture.";
                test.Attributes.Add("class", "alert alert-danger");
            }

        }
    }
}