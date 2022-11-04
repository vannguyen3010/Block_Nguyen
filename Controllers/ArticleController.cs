using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Dto.Article;
using MyBlog.Models;
using MyBlog.Repository;


namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRepository _articleRepository;
        public ArticleController(ArticleRepository articleRepository)
        {


            _articleRepository = articleRepository;
        }

        [HttpPost]
        public IActionResult AddArticle(CreateArticleDto createArticleDto)
        {
            if (ModelState.IsValid)
            {
                var article = (new Models.Article()
                {
                    Title = createArticleDto.Title,
                    Content = createArticleDto.Content,
                    ViewCount = createArticleDto.ViewCount,
                    AuthorId = createArticleDto.AuthorId,
                });
                var createdArticle = _articleRepository.InsertArticle(article);
                return Ok(createdArticle);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListArticle()
        {

            var listArticle = await _articleRepository.GetListArticle();

            return Ok(listArticle);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteArticle([FromQuery] Guid id)
        {
            return Ok(await _articleRepository.DeleteArticle(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutArticle([FromQuery]Guid Id, PutArticleDto PutArticleDto)
        {
            if (ModelState.IsValid)
            {
                var articleNew = new Article()
                {
                
                Title = PutArticleDto.Title,
                Content = PutArticleDto.Content,
                ViewCount = PutArticleDto.ViewCount,
                AuthorId = PutArticleDto.AuthorId,
                };
                return Ok(await _articleRepository.EditArticle(Id, articleNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}