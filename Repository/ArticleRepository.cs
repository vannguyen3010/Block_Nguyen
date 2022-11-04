using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;
using MyBlog.Data;
using MyBlog.Dto.Article;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Repository
{
    public class ArticleRepository
    {
        private readonly AppDbContext _appDbContext;
        public ArticleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ArticleDto InsertArticle(Article article)
        {
            _appDbContext.Articles.Add(article);
            _appDbContext.SaveChanges();
            var result = new ArticleDto()
            {
                ID=article.ID,
                Title = article.Title,
                Content = article.Content,
                ViewCount = article.ViewCount,
                AuthorId = article.AuthorId,
            };
            return result;
        }

        public async Task<List<ArticleDto>> GetListArticle()
        {
            return await _appDbContext.Articles.Select(article => new ArticleDto()
            {
                ID=article.ID,
                Title = article.Title,
                Content = article.Content,
                ViewCount = article.ViewCount,
                AuthorId = article.AuthorId,
            }).AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteArticle(Guid Id)
        {
            var article = await _appDbContext.Articles.FirstOrDefaultAsync(article => article.ID == Id);

            if (article == null)
            {
                return false;
            };

            _appDbContext.Articles.Remove(article);
            await _appDbContext.SaveChangesAsync();

            return true;

        }


        public async Task<ArticleDto> EditArticle(Guid Id, Article article)
        {

            var articleExist = await _appDbContext.Articles.FirstOrDefaultAsync(article => article.ID == Id);

            if (articleExist == null)
            {
                return null;
            };
                articleExist.Title = article.Title;
                articleExist.Content = article.Content;
                articleExist.ViewCount = article.ViewCount;
                articleExist.AuthorId = article.AuthorId;

            await _appDbContext.SaveChangesAsync();

            return new ArticleDto()
            {
                ID=articleExist.ID,
                Title = articleExist.Title,
                Content = articleExist.Content,
                ViewCount = articleExist.ViewCount,
                AuthorId = articleExist.AuthorId,
            };
        }

    }
}