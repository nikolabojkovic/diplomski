using System.Collections.Generic;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using DiplomskiCore1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DiplomskiCore1.Repository;

namespace DiplomskiCore1.Controllers
{
    public class CommentController : Controller
    {
        private CommentRepository _repository;

        public CommentController(CommentRepository repository)
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

            return RedirectToAction("Details", "Blog", new { id = model.BlogId });
        }

        [HttpPost]
        public string Edit(int id, string text)
        {
            var comment = _repository.Get(id) as Comment;

            if (comment == null)
                return string.Empty;

            comment.Text = text;
            _repository.Edit(comment);

            return comment.Text;
        }

        public ActionResult Delete(int id, int blogId)
        {
            _repository.Delete(_repository.Get(id));
            return RedirectToAction("Details", "Blog", new { id = blogId});
        }
    }
}