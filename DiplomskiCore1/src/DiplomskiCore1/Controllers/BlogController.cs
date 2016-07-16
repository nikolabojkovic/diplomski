using System.Collections.Generic;
using DiplomskiCore1.Models;
using DiplomskiCore1.Repository;
using DiplomskiCore1.Services;
using DiplomskiCore1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiCore1.Controllers
{
    public class BlogController : Controller
    {
        private IRepository _repository;

        public BlogController(IRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            var model = new BlogViewModel();
            model.Blogs = _repository.GetAll() as IEnumerable<Blog>;

            return View(model);
        }

        public ViewResult Details(int id)
        {
            var model = _repository.Get(id) as Blog;
            if (model == null)
                return View();

            var viewModel = new BlogCommentsViewModel();
            viewModel.Title = model.Title;
            viewModel.Text = model.Text;
            viewModel.BlogId = model.Id;
            
            viewModel.Comments = model.Comments;

            return View(viewModel);
        }
         
        [HttpPost]
        public ViewResult Create(BlogEditViewModel model)
        {
            if (model.Title == null || model.Text == null)
                return View();

            var blog = new Blog();
            blog.AuthorId = 1;

            blog.Title = model.Title;
            blog.Text = model.Text;

            _repository.Add(blog);
            BlogCommentsViewModel blogViewModel = new BlogCommentsViewModel();
            blogViewModel.Title = blog.Title;
            blogViewModel.Text = blog.Text;
            blogViewModel.Comments = new List<Comment>();

            return View("Details", blogViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var blog = _repository.Get(id) as Blog;

            if (blog == null)
                return View("Index");

            var model = new BlogEditViewModel();
                model.Title = blog.Title;
                model.Text = blog.Text;

            return View(model);
        }

        [HttpPost]
        public ViewResult Edit(int id, BlogEditViewModel model)
        {
            var blog = _repository.Get(id) as Blog;

            if (blog == null)
                return View("Index");

            blog.Title = model.Title;
            blog.Text = model.Text;

            _repository.Edit(blog);

            BlogCommentsViewModel blogViewModel = new BlogCommentsViewModel();
            blogViewModel.Title = blog.Title;
            blogViewModel.Text = blog.Text;
            blogViewModel.Comments = blog.Comments;

            return View("Details", blogViewModel);
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(_repository.Get(id));
            return RedirectToAction("Index");
        }
    }
}