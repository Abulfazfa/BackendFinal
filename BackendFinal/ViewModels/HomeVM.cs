﻿using BackendFinal.Models;

namespace BackendFinal.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Banner> Banners { get; set; }
        public Bio Bios { get; set; }
    }
}
