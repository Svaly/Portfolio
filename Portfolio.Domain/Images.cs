namespace Portfolio.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Images
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ThumbnailName { get; set; }
    
        public virtual Projects Projects { get; set; }
    }
}
