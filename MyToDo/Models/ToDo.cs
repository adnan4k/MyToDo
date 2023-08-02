using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyToDo.Models
{
    public class ToDo
    {
        
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }    
        public bool Status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage ="Date should be MM/dd/yyyy format ")]
        public DateTime? DueDate { get; set; }
        

    }
}