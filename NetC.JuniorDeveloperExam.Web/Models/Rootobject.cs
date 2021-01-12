using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Rootobject
    {
        [JsonProperty(PropertyName = "blogPosts")]
        public List<BlogPost> blogPosts { get; set; }
    }
}