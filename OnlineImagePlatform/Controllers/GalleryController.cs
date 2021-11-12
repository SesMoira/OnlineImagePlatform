using Microsoft.AspNetCore.Mvc;
using OnlineImagePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheImageGallery.Data.Models;
namespace OnlineImagePlatform.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var NatureTag = new List<ImageTag>();
            var CarsTag = new List<ImageTag>();

            var tag1 = new ImageTag()
            {
                Description = "Adveture",
                Id = 0
            };

            NatureTag.Add(tag1);

            var imageList = new List<GalleryImage>()
            {
                GalleryImage() 
                {
                    Title = "Nature",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = NatureTag,
                    CapturesBy = "Sesi",
                    Geolocation = "Johannesburg"
                };

            };

            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""

            };
            return View(model);
        }
    }
}
