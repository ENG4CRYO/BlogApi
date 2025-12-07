using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

      
        [HttpGet("all-posts")]
        [AllowAnonymous] 
        public async Task<IActionResult> GetAll()
        {

            var posts = await _postService.GetAllPostsAync();
            return Ok(posts);
        }

        [HttpGet("my-posts")]
        public async Task<IActionResult> GetMyPosts()
        {
            var userId = User.FindFirst("uid")?.Value;
            var posts = await _postService.GetMyPostsAync(userId);
            return Ok(posts);
        }

        [HttpGet("post/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound("Post Not Exsist");

            return Ok(post);
        }


        [HttpPost("create-post")]
        public async Task<IActionResult> Create([FromBody] CreatePostDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var userId = User.FindFirst("uid")?.Value;


            var result = await _postService.CreatePostAsync(dto, userId);

    
            return CreatedAtAction(nameof(GetById), new { id = 1 }, result);
    
        }


        [HttpPut("update-post/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirst("uid")?.Value;

            var result = await _postService.UpdatePostAsync(id, dto, userId);

            if (result == null)
                return BadRequest("you cant update this post or not exsist");

            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst("uid")?.Value;

            var isAdmin = User.IsInRole("Admin") || User.HasClaim("roles", "Admin");

            var deleted = await _postService.DeletePostAsync(id, userId, isAdmin);

            if (!deleted)
                return BadRequest("Only Admin And the owenr can Delete this post");

            return NoContent();
        }
    }
}