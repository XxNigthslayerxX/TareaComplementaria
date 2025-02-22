using BasicCrudApi.Data;
using BasicCrudApi.Models;

namespace BasicCrudApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("api/")]
[ApiController]
public class CrudController : ControllerBase
{
    // Users CRUD
    [HttpGet("users")]
    public ActionResult<List<User>> GetUsers() => DataContext.Users;

    [HttpGet("users/{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = DataContext.Users.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost("users")]
    public ActionResult<User> CreateUser(User user)
    {
        user.Id = DataContext.Users.Count + 1;
        DataContext.Users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("users/{id}")]
    public ActionResult UpdateUser(int id, User user)
    {
        var existingUser = DataContext.Users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null) return NotFound();
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        return NoContent();
    }

    [HttpDelete("users/{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = DataContext.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        DataContext.Users.Remove(user);
        return NoContent();
    }

    // Posts CRUD
    [HttpGet("posts")]
    public ActionResult<List<Post>> GetPosts() => DataContext.Posts;

    [HttpGet("posts/{id}")]
    public ActionResult<Post> GetPost(int id)
    {
        var post = DataContext.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null) return NotFound();
        return post;
    }

    [HttpPost("posts")]
    public ActionResult<Post> CreatePost(Post post)
    {
        post.Id = DataContext.Posts.Count + 1;
        DataContext.Posts.Add(post);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpPut("posts/{id}")]
    public ActionResult UpdatePost(int id, Post post)
    {
        var existingPost = DataContext.Posts.FirstOrDefault(p => p.Id == id);
        if (existingPost == null) return NotFound();
        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        return NoContent();
    }

    [HttpDelete("posts/{id}")]
    public ActionResult DeletePost(int id)
    {
        var post = DataContext.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null) return NotFound();
        DataContext.Posts.Remove(post);
        return NoContent();
    }

    // Comments CRUD
    [HttpGet("comments")]
    public ActionResult<List<Comment>> GetComments() => DataContext.Comments;

    [HttpGet("comments/{id}")]
    public ActionResult<Comment> GetComment(int id)
    {
        var comment = DataContext.Comments.FirstOrDefault(c => c.Id == id);
        if (comment == null) return NotFound();
        return comment;
    }

    [HttpPost("comments")]
    public ActionResult<Comment> CreateComment(Comment comment)
    {
        comment.Id = DataContext.Comments.Count + 1;
        DataContext.Comments.Add(comment);
        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [HttpPut("comments/{id}")]
    public ActionResult UpdateComment(int id, Comment comment)
    {
        var existingComment = DataContext.Comments.FirstOrDefault(c => c.Id == id);
        if (existingComment == null) return NotFound();
        existingComment.Text = comment.Text;
        return NoContent();
    }

    [HttpDelete("comments/{id}")]
    public ActionResult DeleteComment(int id)
    {
        var comment = DataContext.Comments.FirstOrDefault(c => c.Id == id);
        if (comment == null) return NotFound();
        DataContext.Comments.Remove(comment);
        return NoContent();
    }
}