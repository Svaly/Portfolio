using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Concrete
{
    public class EFImageRepository : IImageRepository
    {      
            private EfDbContext context = new EfDbContext();

            public IEnumerable<Image> Images
            {
                get { return context.Images; }
            }

        public void Add(Image image)
        {
        
            context.Images.Add(image);
            context.SaveChanges();
        }

        public Image Delete(int imageId)
        {
            Image dbEntry = context.Images.Find(imageId);
            if (dbEntry != null)
            {
                context.Images.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
    
}
