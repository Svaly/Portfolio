using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Abstract
{
    public interface IImageRepository
    {
        IEnumerable<Images> Images { get; }

        void Add(Images image);

        Images Delete(int imageId);
    }
}
