using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    using Newtonsoft.Json;
    public class BlogPost
    {
        public BlogPost()
        {
        }

        public BlogPost(int v1, string v2, string v3, string v4, string v5, Comment comment)
        {
        }

        [Key]
        public int id { get; set; }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime date { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string htmlContent{ get; set; }
      public IList<Comment> comments { get; set; }
       

    }
}