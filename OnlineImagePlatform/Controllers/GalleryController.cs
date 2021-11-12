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
    }
}
