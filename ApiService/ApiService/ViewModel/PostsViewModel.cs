using ApiService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.ViewModel
{
    public class PostsViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private List<PostModel> _posts;
        public List<PostModel> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged("Posts");
            }
        }


        public PostsViewModel()
        {
            loadPosts();
        }
        async void loadPosts()
        {
            Posts = await GetPostsAsync();
        }

        static string BaseUrl = "https://jsonplaceholder.typicode.com/posts";
        public async Task<List<PostModel>> GetPostsAsync()
        {
            List<PostModel> posts = new List<PostModel>();
            var  Client=new HttpClient();
            Client = new HttpClient
                {
                    BaseAddress = new Uri(BaseUrl)
                };
            using (var response = await Client.GetAsync(BaseUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(result))
                    {
                        posts = await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<PostModel>>(result));
                    }
                }
            }  
            
            return posts;
        }


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
