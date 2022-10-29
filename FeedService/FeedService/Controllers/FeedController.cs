using FeedService.Models;
using FeedService.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        [HttpGet]
        public List<Users> GetUsers()
        {
            Services services = new Services();
            return services.RequestUsers().OrderBy(u => u.username).ToList();
        }

        [HttpGet]
        public List<Users> GetUser(int userId)
        {
            Services services = new Services();
            return services.RequestUsers().Where(u => u.id == userId).ToList();
        }

        [HttpGet]
        public List<Posts> GetPosts(int userId)
        {
            Services services = new Services();
            return services.RequestPosts().Where(p => p.userId == userId).ToList();
        }

        [HttpGet]
        public List<Comments> GetComments(int postId)
        {
            Services services = new Services();
            return services.RequestComments().Where(c => c.postId == postId).ToList();
        }
    }
}
