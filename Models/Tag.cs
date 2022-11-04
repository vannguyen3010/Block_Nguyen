using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Tag:BaseEntity
    {
        public String Name{get;set;}
        public ICollection<ArticleTag> ArticleTags{get;set;}
    }
}