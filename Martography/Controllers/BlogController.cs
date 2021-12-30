using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Blog;

namespace Martography.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var allposts = await blogService.GetAll<BlogPostViewModel>();
            return View(allposts);
        }

        public async Task<IActionResult> ById(string Id)
        {
            var post = await blogService.GetPost<BlogPostViewModel>(Id);
            return View(post);
        }
    }
}
