using System;
using EFTutorial.Models;
using System.Linq;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var option;
            do
            {
                Console.WriteLine("--Menu--");
                Console.WriteLine("1. Display Blogs");
                Console.WriteLine("2. Add Blogs");
                Console.WriteLine("3. Display Posts");
                Console.WriteLine("4. Add Post");
                Console.WriteLine("Please select a option: ");
                option = Console.ReadLine();

                if (option == "1")
                {
                    //1. Read Blogs from database
                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("Here is the list of blogs");
                        foreach (var b in db.Blogs)
                        {
                            Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                        }
                    }
                }
                else if (option == "2")
                {
                    // 2. Add Blog to Database
                    Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();

                    // Create new Blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // // Save blog object to database
                    using (var db = new BlogContext())
                    {
                        db.Add(blog);
                        db.SaveChanges();
                    }
                }
                else if (option == "3")
                {
                    // 3. List Posts for Blog #1
                    using (var db = new BlogContext())
                    {
                        var blog = db.Blogs.Where(x => x.BlogId == 1).FirstOrDefault();
                        // var blogsList = blog.ToList(); // convert to List from IQueryable

                        Console.WriteLine($"Posts for Blog {blog.Name}");

                        foreach (var post in blog.Posts)
                        {
                            Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                        }
                    }
                }
                else if (option == "4")
                {

                    // 4. Add Post to database
                    Console.WriteLine("Enter your Post title");
                    var postTitle = Console.ReadLine();

                    var post = new Post();
                    post.Title = postTitle;
                    post.BlogId = 1;

                    using (var db = new BlogContext())
                    {
                        db.Posts.Add(post);
                        db.SaveChanges();
                    }
                }
            }while(option != "5")
        } 

    }
}
