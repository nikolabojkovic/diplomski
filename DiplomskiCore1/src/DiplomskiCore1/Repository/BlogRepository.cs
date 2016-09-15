using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomskiCore1.Data;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using Microsoft.ApplicationInsights.Extensibility;
using NuGet.Packaging;

namespace DiplomskiCore1.Repository
{
    public class BlogRepository : IRepository
    {
        private ApplicationDbContext _dbContext;

        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Data> GetAll()
        {
            return _dbContext.Blog;
        }

        public Data Get(int id)
        {
            var blog = _dbContext.Blog.FirstOrDefault(item => item.Id == id);
            var comments = _dbContext.Comment.Where(item => item.BlogId == id);
            blog.Comments = new List<Comment>();
            List<Comment> commentsTemp = comments.ToList();

            // blog.Comments.AddRange(commentsTemp);
            //foreach (var comment in blog.Comments)
            //{
            //    comment.Author.ToString();
            //}

            return blog;
        }

        public void Add(Data item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public Data Edit(Data item)
        {
            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Data item)
        {
            _dbContext.Remove(item);
            foreach (var blogActivityItem in _dbContext.BlogActivity.Where(x => x.BlogId == ((Blog)item).Id))
            {
                _dbContext.Remove(blogActivityItem);
            }

            _dbContext.SaveChanges();
        }

        public void AddActivity(Data item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public Data GetActivity(int blogId, int authorId)
        {
            var blogActivity = _dbContext.BlogActivity.FirstOrDefault(
                item => item.BlogId == blogId && item.AuthorId == authorId);

            return blogActivity;
        }

        public void RecordLike(Data blogActivity, Data blog)
        {
            _dbContext.Update(blogActivity);
            _dbContext.Update(blog);
            _dbContext.SaveChanges();
        }
    }
}
