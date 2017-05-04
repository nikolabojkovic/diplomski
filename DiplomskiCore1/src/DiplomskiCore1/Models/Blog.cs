using DiplomskiCore1.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomskiCore1.Models
{
    public class Blog : Repository.Data
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Text { get; set; }

        public int NumberOfLike { get; set; }

        public int NumberOfDisike { get; set; }

        public int? Vote { get; set; }
        
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
