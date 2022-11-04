using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class User : BaseEntity
    {
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ArticleLiker> ArticleLikers { get; set; }
    }
}