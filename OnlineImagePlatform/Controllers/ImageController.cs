using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineImagePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TheImageGallery.Data;


namespace OnlineImagePlatform.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _config;
        private IImage _imageService;
        private string AzureConnectionString { get; }

        public ImageController(IConfiguration config, IImage imageService)
        {
            _config = config;
            _imageService = imageService;
            AzureConnectionString = _config["AzureStorageConnectionString"];
        }
        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile file, string title, string tags)
        {
            var container = _imageService.GetBlobContainer(AzureConnectionString, "images");
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            
            await _imageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }
    }
}
