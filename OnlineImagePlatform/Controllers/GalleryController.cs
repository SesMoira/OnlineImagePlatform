using Microsoft.AspNetCore.Mvc;
using OnlineImagePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheImageGallery.Data;
using TheImageGallery.Data.Models;
namespace OnlineImagePlatform.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }
        public IActionResult Index()
        { 

            var imageList = _imageService.GetAll();
            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""

            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var image = _imageService.GetbyId(id);

            var model = new GalleryDetailModel()
            {
                Id = image.Id,
                Title = image.Title,
                CreatedOn = image.Created,
                Url = image.Url,
                Geolocation = image.Geolocation,
                CapturedBy = image.CapturedBy,
                Tags = image.Tags.Select(t => t.Description).ToList()
            };
            return View(model);
        }
    }
}
