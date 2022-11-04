using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Dto.Comment;
using MyBlog.Models;
using MyBlog.Repository;


namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentRepository _commentRepository;
        public CommentController(CommentRepository commentRepository)
        {


            _commentRepository = commentRepository;
        }

        [HttpPost]
        public IActionResult AddComment(CreateCommentDto createCommentDto)
        {
            if (ModelState.IsValid)
            {
                var comment = (new Models.Comment()
                {
                    Content = createCommentDto.Content,
                    AuthorId = createCommentDto.AuthorId,
                    ArticleId = createCommentDto.ArticleId,
                });
                var createdComment = _commentRepository.InsertComment(comment);
                return Ok(createdComment);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListComment()
        {

            var listComment = await _commentRepository.GetListComment();

            return Ok(listComment);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromQuery] Guid id)
        {
            return Ok(await _commentRepository.DeleteComment(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutComment([FromQuery]Guid Id, PutCommentDto PutCommentDto)
        {
            if (ModelState.IsValid)
            {
                var commentNew = new Comment()
                {
                    Content = PutCommentDto.Content,
                    AuthorId = PutCommentDto.AuthorId,
                    ArticleId = PutCommentDto.ArticleId,
                };
                return Ok(await _commentRepository.EditComment(Id, commentNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}