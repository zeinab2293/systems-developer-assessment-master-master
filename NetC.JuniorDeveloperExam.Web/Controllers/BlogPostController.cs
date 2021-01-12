using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetC.JuniorDeveloperExam.Web.Models;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogPostController :Controller
    {
        [HttpGet]
        public ActionResult Index( int id)
  
        {
           
            string filePath = Server.MapPath("~/App_Data/Blog-Posts.json");
            using (StreamReader r =
                new StreamReader(
                    filePath)
            )
            {
                string json = r.ReadToEnd();

                Rootobject Blogs = JsonConvert.DeserializeObject<Rootobject>(json);
                if(Blogs != null)
                {
                    List<BlogPost> newBlogPosts = (List<BlogPost>)Blogs.blogPosts.Where(b => b.id == id).ToList();


                    return View(newBlogPosts);
                }
                else
                {
                    TempData["message"] = "No Data in Json file to display as blog posts !";
                    return View();
                }

             
            }
        }

        [Route("/BlogPosts/CreateComment/{id}")]
        [HttpPost]
        public ActionResult CreateComment( string Name , string EmailAddress, string Message , int id)
        {

           
           
            try
            {
                  string filePath = Server.MapPath("~/App_Data/Blog-Posts.json");
               

                Comment comment = new Comment();
                //comment.id = Guid.NewGuid();
                comment.name = Name;
                comment.emailAddress = EmailAddress;
                comment.message = Message;
                comment.date = DateTime.Now;

                //
                string json = string.Empty;
                using (StreamReader r = new StreamReader(filePath))
                {
                    json = r.ReadToEnd();
                }
                Rootobject list = JsonConvert.DeserializeObject<Rootobject>(json);

             

                try
                {
                    var newBlogPostComments = list.blogPosts.Where(b => b.id == id).FirstOrDefault().comments;
                    if(newBlogPostComments != null)
                    {
                        newBlogPostComments.Add(comment);
                    }
                    else
                    {
                        List<Comment> newList = new List<Comment>();

                        newList.Add(comment);
                        var newBlogPostCatched = list.blogPosts.Where(b => b.id == id).FirstOrDefault();
                        newBlogPostCatched.comments = newList;
                    }
                 

                }
             
                 catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }




                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                
                using (var writer = new StreamWriter(filePath))
                    {
                        writer.Write(convertedJson);
                    }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(); 

        }
    }
}