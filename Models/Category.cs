using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Category:BaseEntity
    {
        public String Name{get;set;}
        public ICollection<Article> Articles{get;set;}
        public Guid CreatedById{get;set;}
        public User CreatedBy{get;set;}
    }
}