using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_English_Training_Application_Web_Form_.Database_Models
{
    public class Examples
    {
        [Key]
        public long ID { get; set; }
        public long WordOrPhraseID { get; set; }
        [ForeignKey("WordOrPhraseID")]
        public PhrasesOrWords phrasesOrWords { get; set; }
        public string Example { get; set; }
        //public ICollection<PhrasesOrWords> PhrasesOrWords { get; set; }
    }
}