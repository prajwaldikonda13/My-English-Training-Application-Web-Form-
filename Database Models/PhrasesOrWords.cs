using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_English_Training_Application_Web_Form_.Database_Models
{
    public class PhrasesOrWords
    {
        [Key]
        public long ID { get; set; }
        public long LectureID { get; set; }
        [ForeignKey("LectureID")]
        public Lectures lectures { get; set; }
        public string PhraseOrWord { get; set; }
        public string Description { get; set; }
        //public ICollection<Lectures> Lectures { get; set; }
    }
}