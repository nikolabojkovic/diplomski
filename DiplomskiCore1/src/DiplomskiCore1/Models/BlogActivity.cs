using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomskiCore1.Models
{
    public class BlogActivity : Repository.Data
    {
        public bool IsLike { get; set; }

        public bool IsDislike { get; set; }

        public int AuthorId { get; set; }

        public int BlogId { get; set; }
    }
}
