using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading;
using RascalChat.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RascalChat.Services
{
    public class UserService
    {
        public HttpClient Client { get; set; }
        public string ApiKey { get; set; }
        public UserService()
        {
            Client = new HttpClient();
        }

        public User Register(string login, string password)
        {
            LoginInfo log = new LoginInfo() { Login = login, Password = password };
            var response = Client.PostAsJsonAsync("https://rafale-p2p-chat.herokuapp.com/api/user/register/", log).Result;
            if (response.IsSuccessStatusCode)
            {
                User output = response.Content.ReadAsAsync<User>().Result;
                return output;
            }
            else
            {
                return null;
            }
        }

        public Key Login(string login, string password)
        {
            LoginInfo log = new LoginInfo() { Login = login, Password = password };
            var response = Client.PostAsJsonAsync("https://rafale-p2p-chat.herokuapp.com/api/user/login/", log).Result;
            if (response.IsSuccessStatusCode)
            {
                Key output = response.Content.ReadAsAsync<Key>().Result;
                ApiKey = output.ApiKey;
                return output;
            }
            else
            {
                return null;
            }
        }

        public User Info()
        {
            Key key = new Key() { ApiKey = ApiKey };
            Client.DefaultRequestHeaders.Add("apiKey", ApiKey);
            var response = Client.GetAsync($"https://rafale-p2p-chat.herokuapp.com/api/user/info/").Result;
            if (response.IsSuccessStatusCode)
            {
                User output = response.Content.ReadAsAsync<User>().Result;
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
