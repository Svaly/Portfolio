using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Abstract
{
    public interface IProjectRepository
    {
        IEnumerable<Projects> Projects { get; }

        void Activate(Projects project);

        void Deactivate(Projects project);

        Projects SaveProject(Projects project);

    }


}
