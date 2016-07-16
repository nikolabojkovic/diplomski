using System.Collections.Generic;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using DiplomskiCore1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiCore1.Controllers
{
    public class CommentController : Controller
    {
        private IRepository _repository;

        public CommentController(IRepository repository)
        {
            _repository = repository;
        }

        //public ViewResult Index()
        //{
        //    var model = new CommentViewModel();
        //    model.Comments = _repository.GetAll() as IEnumerable<Comment>;

        //    return View(model);
        //}

        //public ViewResult Details(int id)
        //{
        //    var model = _repository.Get(id);

        //    return View(model);
        //}

        [HttpPost]
        public ActionResult Create(BlogCommentsViewModel model)
        {
            var comment = new Comment();
            comment.BlogId = model.BlogId;
            
            comment.Text = model.NewCommentText;

            _repository.Add(comment);

            return RedirectToAction("Index", "Blog");
        }

        //[HttpPost] // does not working , fix it later
        //public ViewResult Create()
        //{
        //    return View();
        //}

        //public ViewResult Edit(int id, BlogEditViewModel model)
        //{
        //    var blog = _repository.Get(id) as Blog;

        //    if (blog == null)
        //        return View("Index");

        //    if (model.Title == null || model.Text == null)
        //    {
        //        model.Title = blog.Title;
        //        model.Text = blog.Text;
        //        return View(model);
        //    }

        //    blog.Title = model.Title;
        //    blog.Text = model.Text;

        //    _repository.Edit(blog);

        //    return View("Details", blog);
        //}

        //public ActionResult Delete(int id)
        //{
        //    _repository.Delete(_repository.Get(id));
        //    return RedirectToAction("Index");
        //}
    }
}