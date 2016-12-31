using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomskiCore1.Data;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Remotion.Linq.Clauses;

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
            return _dbContext.Blog.Include(x => x.Author);
        }

        public Data Get(int id)
        {
            // find blog
            // first approach
            //var blog = _dbContext.Blog.FirstOrDefault(item => item.Id == id);

            // second approach
            string query = "SELECT *"
                        + " FROM blog "
                        + " WHERE id = " + id;
            IEnumerable<Blog> blogs = _dbContext.Blog.FromSql(query);
            Blog blog = blogs.FirstOrDefault( x=> x.Id == id);

            //find comments for blog 
            // first approach
            // var comments = _dbContext.Comment.Where(item => item.BlogId == id);

            // second approach
            var commentsLoaded = _dbContext.Comment.Include(x=> x.Author);
              var comments = from comment in commentsLoaded
                             where comment.BlogId == id
                             select comment;

            blog.Comments = comments.ToArray();

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
            //_dbContext.Remove(item);
            string query = "DELETE FROM blog"
                         + " WHERE id = " + ((Blog)item).Id;
            _dbContext.Database.ExecuteSqlCommand(query);

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
