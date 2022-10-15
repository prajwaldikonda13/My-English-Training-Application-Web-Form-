using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_English_Training_Application_Web_Form_.Database_Models
{
    public class Lectures
    {
        [Key]
        public long ID { get; set; }
        public string LectureName { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }

    }
}