using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheImageGallery.Data.Models;

namespace OnlineImagePlatform.Model
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
