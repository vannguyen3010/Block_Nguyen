using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;
using MyBlog.Data;
using MyBlog.Dto.Comment;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Repository
{
    public class CommentRepository
    {
        private readonly AppDbContext _appDbContext;
        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public CommentDto InsertComment(Comment comment)
        {
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
            var result = new CommentDto()
            {
                ArticleId = comment.ArticleId,
                Content = comment.Content,
                ID = comment.ID,
                AuthorId = comment.AuthorId,
            };
            return result;
        }

        public async Task<List<CommentDto>> GetListComment()
        {
            return await _appDbContext.Comments.Select(comment => new CommentDto()
            {
                ArticleId = comment.ArticleId,
                Content = comment.Content,
                ID = comment.ID,
                AuthorId = comment.AuthorId,
            }).AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteComment(Guid Id)
        {
            var comment = await _appDbContext.Comments.FirstOrDefaultAsync(comment => comment.ID == Id);

            if (comment == null)
            {
                return false;
            };

            _appDbContext.Comments.Remove(comment);
            await _appDbContext.SaveChangesAsync();

            return true;

        }


        public async Task<CommentDto> EditComment(Guid Id, Comment comment)
        {

            var commentExist = await _appDbContext.Comments.FirstOrDefaultAsync(comment => comment.ID == Id);

            if (commentExist == null)
            {
                return null;
            };
            commentExist.ArticleId = comment.ArticleId;
            commentExist.Content = comment.Content;
            commentExist.AuthorId = comment.AuthorId;

            await _appDbContext.SaveChangesAsync();

            return new CommentDto()
            {
                ArticleId = commentExist.ArticleId,
                Content = commentExist.Content,
                ID = commentExist.ID,
                AuthorId = commentExist.AuthorId,
            };
        }

    }
}