using FeedService.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace FeedService.Request
{
    public class Services
    {
        string usersURL = "https://jsonplaceholder.typicode.com/users";
        string postsURL = "https://jsonplaceholder.typicode.com/posts";
        string commentsURL = "https://jsonplaceholder.typicode.com/comments";

        public List<Users> RequestUsers()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(usersURL);
            RestResponse response = client.Execute(request);

            List<Users> users = new List<Users>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                users = (List<Users>)JsonConvert.DeserializeObject(response.Content, typeof(List<Users>));
            }

            return users;
        }

        public List<Posts> RequestPosts()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(postsURL);
            RestResponse response = client.Execute(request);

            List<Posts> posts = new List<Posts>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                posts = (List<Posts>)JsonConvert.DeserializeObject(response.Content, typeof(List<Posts>));
            }

            return posts;
        }

        public List<Comments> RequestComments()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(commentsURL);
            RestResponse response = client.Execute(request);

            List<Comments> comments = new List<Comments>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                comments = (List<Comments>)JsonConvert.DeserializeObject(response.Content, typeof(List<Comments>));
            }

            return comments;
        }
    }
}
