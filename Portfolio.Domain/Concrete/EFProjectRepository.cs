using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Infrastructure;

namespace Portfolio.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Project> Projects
        {
            get { return context.Projects; }
        }

        public void Activate(Project project)
        {
            Project dbEntry = context.Projects.Find(project.Id);
            if (dbEntry != null)
            {
                dbEntry.Active = "Aktywny";
            }
            context.SaveChanges();
        }

        public void Deactivate(Project project)
        {
            Project dbEntry = context.Projects.Find(project.Id);
            if (dbEntry != null)
            {
                dbEntry.Active = "Nie aktywny";
            }
            context.SaveChanges();
        }


        public Project SaveProject(Project project)
        {
       
            if (project.Id == 0)
            {
                project.LastEditDate= DateTime.Now;
                project.AddedDate= DateTime.Now;
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
            }
            else
            {
                Project dbEntry = context.Projects.Find(project.Id);
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
