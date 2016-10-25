using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Infrastructure;
using System.Data.Entity;

namespace Portfolio.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository
    {
        private PortfolioEntities context = new PortfolioEntities();

        public IEnumerable<Projects> Projects
        {
            get { return context.Projects.Include(p => p.Images); }
        }

        public void Activate(Projects project)
        {
            Projects dbEntry = context.Projects.Find(project.Id);
            if (dbEntry != null)
            {
                dbEntry.Active = "Aktywny";
            }
            context.SaveChanges();          
        }

        public void Deactivate(Projects project)
        {
            Projects dbEntry = context.Projects.Find(project.Id);
            if (dbEntry != null)
            {
                dbEntry.Active = "Nie aktywny";
            }
            context.SaveChanges();
        }

        public Projects SaveProject(Projects project)
        {
            if (project.Id == 0)
            {
                project.LastEditDate = DateTime.Now;
                project.AddedDate = DateTime.Now;
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
            }
            else
            {
                Projects dbEntry = context.Projects.Find(project.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = project.Title;
                    dbEntry.Category = project.Category;
                    dbEntry.Description = project.Description;
                    dbEntry.RealizationDate = project.RealizationDate;
                    dbEntry.LastEditDate = DateTime.Now;
                    dbEntry.Active = project.Active;
                    context.SaveChanges();
                    return dbEntry;
                }
                else
                {
                    throw new FailedInsertException("Błąd dodawania projektu");
                }
            }
        }
    }
}
