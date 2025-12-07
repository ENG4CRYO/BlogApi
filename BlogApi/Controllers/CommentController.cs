using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; // لاستخراج الـ Claims

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // 1. تحسين: إضافة دالة لجلب تعليق واحد (ضرورية للـ CreatedAtAction)
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
                return NotFound("التعليق غير موجود");

            return Ok(comment);
        }

        // 2. تحسين: توضيح الرابط (Route) للفصل بين جلب تعليق وجلب قائمة
        // الرابط سيصبح: api/comments/post/{postId}
        [HttpGet("post/{postId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCommentsByPostId(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentDto createCommentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirst("uid")?.Value;

           
            var comment = await _commentService.AddCommentAsync(createCommentDto, userId);

            if (comment == null)
                return BadRequest("Cannot add Comment (post does not exist)");

     
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirst("uid")?.Value;

            var updatedComment = await _commentService.UpdateCommentAsync(id, updateCommentDto, userId);

            if (updatedComment == null)
            {
                return BadRequest("You cant update this comment or is not exsit");
            }
            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var userId = User.FindFirst("uid")?.Value;

        
            var isAdmin = User.IsInRole("Admin") || User.HasClaim("roles", "Admin");

            var result = await _commentService.DeleteCommentAsync(id, userId, isAdmin);

            if (!result)
            {
                return BadRequest("only admin can delete or does not exsist");
            }
            return NoContent();
        }
    }
}