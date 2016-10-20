using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Image
    {
      
        public int  Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string ThumbnailName { get; set; }

    }
}
