using System;
using System.Collections.Generic;
using System.Text;
using App_RP.Models;

namespace App_RP.ViewModels
{
    public class MainPageViewModel
    {
        public List<CarouselItem> Items { get; set; } = new List<CarouselItem>();
    }
}
