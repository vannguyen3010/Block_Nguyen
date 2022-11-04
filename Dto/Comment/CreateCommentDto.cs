using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Dto.Comment;

    public class CreateCommentDto
    {
        public String Content{get;set;}
       public Guid AuthorId{get;set;}

        public Guid ArticleId{get;set;}
    }
