using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class Article:BaseEntity
    {
        public String Title{get;set;}
        public String Content{get;set;}
        public int ViewCount{get;set;}
        public Guid AuthorId{get;set;}
        public User Author{get;set;}

        public Guid CategoryId{get;set;}
        public Category Category{get;set;}
        public ICollection<ArticleTag> ArticleTags{get;set;}
        public ICollection<Comment> Comments{get;set;}
        public ICollection<ArticleLiker> ArticleLikers{get;set;}
    }
}