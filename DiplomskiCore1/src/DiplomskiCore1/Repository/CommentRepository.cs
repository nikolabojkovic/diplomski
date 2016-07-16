using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomskiCore1.Data;
using DiplomskiCore1.Models;
using DiplomskiCore1.Services;
using Microsoft.ApplicationInsights.Extensibility;

namespace DiplomskiCore1.Repository
{
    public class CommentRepository : IRepository
    {
        private ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Data> GetAll()
        {
            return _dbContext.Comment;
        }

        public IEnumerable<Data> GetByBlogId(int blogId)
        {
            return _dbContext.Comment.Where(item => item.BlogId == blogId);
        } 

        public Data Get(int id)
        {
            return _dbContext.Comment.FirstOrDefault(item => item.Id == id);
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
