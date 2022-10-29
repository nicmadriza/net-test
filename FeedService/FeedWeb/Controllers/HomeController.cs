using FeedWeb.Models;
using FeedWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FeedWeb.Controllers
{
    public class HomeController : Controller
    {
        RequestService request = new RequestService();

        public IActionResult Index()
        {
            GetHTTPInfo();

            BindOptions(0);

            return View();
        }

        [HttpPost]
        public IActionResult Index(SubmitModel submit)
        {
            int UserID = submit.User;
            string? SearchText = submit.Text;
            if (SearchText == null)
            {
                SearchText = "";
            }

            GetHTTPInfo();

            BindOptions(UserID);         

            if (UserID != 0)
            {
                UsersModel user = request.GetUsers(UserID)[0];

                ViewData["User"] = UserCardTemplate(user.name, user.username, user.email, user.address, user.phone, user.website, user.company);

                BindPosts(UserID, SearchText);
            }

            ViewData["SearchText"] = SearchText;

            return View();
        }

        public void GetHTTPInfo()
        {
            //Request.User
            string userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ViewData["UserAgent"] = userAgent;
            ViewData["IP"] = ipAddress;
        }

        public void BindOptions(int userID)
        {
            StringBuilder options = new StringBuilder();
            foreach (UsersModel user in request.GetUsers())
            {
                options.Append("<option value='" + user.id + "' " + (userID == user.id ? "selected" : "") + ">" + user.name + "</option>");
            }
            ViewData["Options"] = options.ToString();
        }

        public void BindPosts(int userId, string text)
        {
            StringBuilder posts = new StringBuilder();
            foreach (PostsModel post in request.GetPosts(userId, text))
            {
                posts.Append(PostCardTemplate(post.id, post.title, post.body));
            }
            ViewData["Posts"] = posts.ToString();
        }

        [HttpPost]
        public string BindComments(string form)
        {
            int postId = (int)JObject.Parse(form)["postId"];

            JArray comments = new JArray();
            foreach (CommentsModel comment in request.GetComments(postId))
            {
                JObject commentData = new JObject()
                {
                    { "Name", comment.name },
                    { "Email", comment.email },
                    { "Body", comment.body }
                };

                comments.Add(commentData);
            }

            return JsonConvert.SerializeObject(comments);
        }

        public string PostCardTemplate(int postId, string title, string body)
        {
            return "<div class='card' style='margin-top: 15px;'>" + 
            "<div class='card-body'>" +
            "<h5 class='card-title'>" + title + "</h5>" +
            "<p class='card-text'>" + body + "</p>" + 
            "<a href='javascript:;' onclick='getComments(" + postId + ")' class='btn btn-primary'>Comments</a>" +
            "</div>" +
            "</div>" +
            "<div id='post" + postId + "' style='background-color: rgb(235 232 232);'>" +
            "</div>";
        }

        public string UserCardTemplate(string name, string username, string email, Address address, string phone, string website, Company company)
        {
            return "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Name:</label>" +
            "<label class='col-sm-8 col-form-label'>" + name + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Username:</label>" +
            "<label class='col-sm-8 col-form-label'>" + username + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Email:</label>" +
            "<label class='col-sm-8 col-form-label'>" + email + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Address:</label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Street:</label>" +
            "<label class='col-sm-4 col-form-label'>" + address.street + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Suite:</label>" +
            "<label class='col-sm-4 col-form-label'>" + address.suite + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>City:</label>" +
            "<label class='col-sm-4 col-form-label'>" + address.city + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>ZipCode:</label>" +
            "<label class='col-sm-4 col-form-label'>" + address.zipcode + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Geo:</label>" +
            "<label class='col-sm-2 col-form-label' style='font-weight: bold;'>Lat:</label>" +
            "<label class='col-sm-2 col-form-label'>" + address.geo.lat + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-2 col-form-label' style='font-weight: bold;'>Lng:</label>" +
            "<label class='col-sm-2 col-form-label'>" + address.geo.lng + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Phone:</label>" +
            "<label class='col-sm-8 col-form-label'>" + phone + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Website:</label>" +
            "<label class='col-sm-8 col-form-label'>" + website + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Company:</label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Name:</label>" +
            "<label class='col-sm-4 col-form-label'>" + company.name + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>Catchphrase:</label>" +
            "<label class='col-sm-4 col-form-label'>" + company.catchPhrase + "</label>" +
            "</div>" +
            "<div class='form-group row'>" +
            "<label class='col-sm-4 col-form-label'></label>" +
            "<label class='col-sm-4 col-form-label' style='font-weight: bold;'>BS:</label>" +
            "<label class='col-sm-4 col-form-label'>" + company.bs + "</label>" +
            "</div>";
        }   
    }
}