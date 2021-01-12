using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Comment
    {
        //[Key]
        //public Guid  id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Email  is required.")]
        public string emailAddress { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        public string message { get; set; }
    }
}