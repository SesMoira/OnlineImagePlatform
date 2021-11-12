using Microsoft.EntityFrameworkCore;
using System;
using TheImageGallery.Data.Models;

namespace TheImageGallery.Data
{
    public class TheImageGalleryDbContext : DbContext
    {
        public TheImageGalleryDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }


    }
}
