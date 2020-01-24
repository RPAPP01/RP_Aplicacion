using System.Collections.Generic;
using App_RP.Models;

namespace App_RP.Services
{
    public class MockPostService
    {
        private static MockPostService _instance;

        public static MockPostService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MockPostService();
                return _instance;
            }
        }

        public List<Post> GetCommunityPosts()
        {
            return new List<Post>
            {
                new Post { Title = "BAR NEXUXS", SubTitle = "Stories from the Road Pt 2", Date = "JULY 24, 2020", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", Image = "Afiliados.jpg", Video = "https://storage.googleapis.com/coverr-main/mp4/Shore-Aerial-Sequence.mp4" },
               new Post { Title = "Lugar", SubTitle = "Artist Spotlight with Cayucas", Date = "JULY 24, 2020", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", Image = "Lugar.jpg", Video = "https://storage.googleapis.com/coverr-main/mp4%2FStrum-Away.mp4" },
                new Post { Title = "Bebidas", SubTitle = "Best new  experiences", Date = "JULY 23, 2020", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", Image = "Bebidas.jpg", Video = "https://storage.googleapis.com/coverr-main/mp4%2Fcoverr-girl-eats-pizza-1563957998818.mp4" }
            };
        }
    }
}
