using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomskiCore1.Models
{
    public class Comment : Repository.Data
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int NumberOfLike { get; set; }

        public int NumberOfDisike { get; set; }

        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
