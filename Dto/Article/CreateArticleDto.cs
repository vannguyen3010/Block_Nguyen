using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Models;
using MyBlog.Dto.User;

namespace MyBlog.Dto.Article
{
    public class CreateArticleDto
    {
        
        public String Title{get;set;}
        public String Content{get;set;}
        public int ViewCount{get;set;}
        public Guid AuthorId{get;set;}

    }
}