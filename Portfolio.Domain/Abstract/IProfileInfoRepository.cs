using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Abstract
{
    public interface IProfileInfoRepository
    {

        Profile GetProfile { get; }

        Profile SaveProfile(Profile profile);
    }
}
