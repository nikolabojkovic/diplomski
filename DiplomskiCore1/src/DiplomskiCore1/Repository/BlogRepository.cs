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
            int count = comments.Count();
            blog.Comments.AddRange(comments.ToList());
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
            _dbContext.SaveChanges();
        }
    }
}
