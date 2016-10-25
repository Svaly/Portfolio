using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Abstract;

namespace Portfolio.Domain.Concrete
{
    public class EFImageRepository : IImageRepository
    {
        private PortfolioEntities context = new PortfolioEntities();

        public IEnumerable<Images> Images
        {
            get { return context.Images; }
        }

        public void Add(Images image)
        {
            context.Images.Add(image);
            context.SaveChanges();
        }

        public Images Delete(int imageId)
        {
            Images dbEntry = context.Images.Find(imageId);
            if (dbEntry != null)
            {
                context.Images.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
