using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Infrastructure;

namespace Portfolio.Domain.Concrete
{
    public class EFProfileInfoRepository : IProfileInfoRepository
    {
        private PortfolioEntities context = new PortfolioEntities();


        public Profile Profile
        {          
            get
            {
                return  context.Profile.FirstOrDefault();                          
            }
        }

        public Profile SaveProfile(Profile profile)
        {
            Profile dbEntry = context.Profile.FirstOrDefault();

            if (dbEntry!=null)
            {
                dbEntry.Description = profile.Description;
                dbEntry.Image = profile.Image;
                dbEntry.Name = profile.Name;
                dbEntry.Surname = profile.Surname;
            }
            else
            {
                context.Profile.Add(profile);
            }
                   
            context.SaveChanges();
            return dbEntry;
        }

    }
}
