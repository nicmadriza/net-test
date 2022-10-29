using FeedWeb.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace FeedWeb.Services
{
    public class RequestService
    {
        string API_URL = "https://localhost:7032/api/Feed/";

        public List<UsersModel> GetUsers()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(API_URL + "GetUsers");
            RestResponse response = client.Execute(request);

            List<UsersModel> users = new List<UsersModel>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                users = (List<UsersModel>)JsonConvert.DeserializeObject(response.Content, typeof(List<UsersModel>));
            }

            return users;
        }

        public List<UsersModel> GetUsers(int userId)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(API_URL + "GetUser?userId=" + userId);
            RestResponse response = client.Execute(request);

            List<UsersModel> user = new List<UsersModel>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                user = (List<UsersModel>)JsonConvert.DeserializeObject(response.Content, typeof(List<UsersModel>));
            }

            return user;
        }

        public List<PostsModel> GetPosts(int userId, string text)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(API_URL + "GetPosts?userId=" + userId);
            RestResponse response = client.Execute(request);

            List<PostsModel> posts = new List<PostsModel>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                posts = (List<PostsModel>)JsonConvert.DeserializeObject(response.Content, typeof(List<PostsModel>));
            }

            if (!text.Equals(""))
            {
                posts = (List<PostsModel>)posts.Where(c => c.title.Contains(text) || c.body.Contains(text)).ToList();
            }

            return posts;
        }

        public List<CommentsModel> GetComments(int postId)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(API_URL + "GetComments?postId=" + postId);
            RestResponse response = client.Execute(request);

            List<CommentsModel> comments = new List<CommentsModel>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                comments = (List<CommentsModel>)JsonConvert.DeserializeObject(response.Content, typeof(List<CommentsModel>));
            }

            return comments;
        }
    }
}
