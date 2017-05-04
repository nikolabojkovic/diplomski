using DiplomskiCore1.Models.New_Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomskiCore1.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<NewComment> Comments { get; set; }
    }
}
