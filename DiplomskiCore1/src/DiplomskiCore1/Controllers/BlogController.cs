using System.Collections.Generic;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using DiplomskiCore1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DiplomskiCore1.Repository;

namespace DiplomskiCore1.Controllers
{
    public class BlogController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserRpository _userRepository;
        private BlogRepository _repository;

        public BlogController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            BlogRepository repository,
            UserRpository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
            _userRepository = userRepository;
        }

        public ViewResult Index()
        {
            var model = new BlogViewModel();
            //User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;

            //List<Blog> blogsTemp = new List<Blog>();

            //if (tempUser != null)
            //{
            //    foreach (var item in _repository.GetAll() as IEnumerable<Blog>)
            //        if (item.AuthorId == tempUser.Id)
            //            blogsTemp.Add(item);
            //    model.Blogs = blogsTemp;
            //}
            //else
            //{
            //    model.Blogs = _repository.GetAll() as IEnumerable<Blog>;
            //}

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
            viewModel.NumberOfLike = model.NumberOfLike;
            viewModel.NumberOfDisike = model.NumberOfDisike;
            viewModel.AuthorId = model.AuthorId;
            viewModel.Comments = model.Comments;

            User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;
            var blogActivity = (BlogActivity)null;
            if (tempUser != null)
               blogActivity = _repository.GetActivity(model.Id, tempUser.Id) as BlogActivity;

            if (blogActivity == null)
                blogActivity = new BlogActivity();

            viewModel.BlogActivity = blogActivity;
            
            return View(viewModel);
        }
         
        [HttpPost]
        public ActionResult Create(BlogEditViewModel model)
        {
            if (model.Title == null || model.Text == null)
                return View();

            var blog = new Blog();
            blog.Title = model.Title;
            blog.Text = model.Text;

            User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;
            blog.AuthorId = tempUser.Id;

            _repository.Add(blog);
            return RedirectToAction("Index");
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
            blogViewModel.BlogId = blog.Id;
            blogViewModel.Title = blog.Title;
            blogViewModel.Text = blog.Text;
            blogViewModel.NumberOfLike = blog.NumberOfLike;
            blogViewModel.NumberOfDisike = blog.NumberOfDisike;
            blogViewModel.Comments = blog.Comments;

            User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;
            var blogActivity = (BlogActivity)null;
            if (tempUser != null)
                blogActivity = _repository.GetActivity(blog.Id, tempUser.Id) as BlogActivity;

            if (blogActivity == null)
                blogActivity = new BlogActivity();

            blogViewModel.BlogActivity = blogActivity;

            return View("Details", blogViewModel);
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(_repository.Get(id));
            return RedirectToAction("Index");
        }

        public string Like(int id, bool status)
        {
            User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;

            var blog = _repository.Get(id) as Blog;
            var blogActivity = _repository.GetActivity(blog.Id, tempUser.Id) as BlogActivity;

            if (blogActivity == null)
            {
                blogActivity = new BlogActivity();
                blogActivity.AuthorId = tempUser.Id;
                blogActivity.BlogId = blog.Id;
                _repository.AddActivity(blogActivity);
            }
            
            if (status)
            {
                blogActivity.IsLike = true;
                blog.NumberOfLike++;

                if (blogActivity.IsDislike)
                    blog.NumberOfDisike--;

                blogActivity.IsDislike = false;
            }
            else
            {
                blogActivity.IsLike = false;
                blog.NumberOfLike--;
            }
            
            _repository.RecordLike(blogActivity, blog);
            return blog.NumberOfLike.ToString() + "/" + blog.NumberOfDisike.ToString();
        }

        public string Dislike(int id, bool status)
        {
            User tempUser = _userRepository.GetByAspNetUserId(_userManager.GetUserId(User)) as User;

            var blog = _repository.Get(id) as Blog;
            var blogActivity = _repository.GetActivity(blog.Id, tempUser.Id) as BlogActivity;

            if (blogActivity == null)
            {
                blogActivity = new BlogActivity();
                blogActivity.AuthorId = tempUser.Id;
                blogActivity.BlogId = blog.Id;
                _repository.AddActivity(blogActivity);
            }

            if (status)
            {
                blogActivity.IsDislike = true;
                blog.NumberOfDisike++;

                if (blogActivity.IsLike)
                    blog.NumberOfLike--;

                blogActivity.IsLike = false;
            }
            else
            {
                blogActivity.IsDislike = false;
                blog.NumberOfDisike--;
            }

            _repository.RecordLike(blogActivity, blog);
            return blog.NumberOfLike.ToString() + "/" + blog.NumberOfDisike.ToString();
        }
    }
}