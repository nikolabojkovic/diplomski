using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.Models.New_Models
{
    public class NewComment
    {
        public string Id { get; set; }

        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("ParentCommentId")]
        public ICollection<NewComment> Comments { get; set; }
    }
}
