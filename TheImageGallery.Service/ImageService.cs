using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheImageGallery.Data;
using TheImageGallery.Data.Models;

namespace TheImageGallery.Service
{
    public class ImageService : IImage
    {
        private readonly TheImageGalleryDbContext _ctx;
        public ImageService(TheImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages
                .Include(img => img.Tags);
        }

        public GalleryImage GetbyId(int Id)
        {
            return _ctx.GalleryImages.Find(Id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img
                => img.Tags
                .Any(t => t.Description == tag));
        }
    }
}
