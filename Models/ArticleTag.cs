
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class ArticleTag
    {
        public Guid ArticleId{get;set;}
        public Article Article{get;set;}
        public Guid TagId{get;set;}
        
        public Tag Tag{get;set;}
    }
}