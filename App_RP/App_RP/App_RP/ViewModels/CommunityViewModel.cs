using System.Collections.ObjectModel;
using App_RP.Models;
using App_RP.Services;
using Xamarin.Forms;

namespace App_RP.ViewModels
{
    public class CommunityViewModel : BindableObject
    {
        private ObservableCollection<Post> _posts;
        private Post _currentPost;

        public CommunityViewModel()
        {
            LoadPosts();
        }

        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public Post CurrentPost
        {
            get { return _currentPost; }
            set
            {
                _currentPost = value;
                OnPropertyChanged();
            }
        }

        public void LoadPosts()
        {
            var posts = MockPostService.Instance.GetCommunityPosts();
            Posts = new ObservableCollection<Post>(posts);
            CurrentPost = Posts[0];
        }
    }
}
