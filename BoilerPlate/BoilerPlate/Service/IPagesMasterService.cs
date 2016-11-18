using System.Collections.Generic;
using BoilerPlate.Model;

namespace BoilerPlate.Service
{
    public interface IPagesMasterService
    {
        IList<PageLink> GetRegistetedLinks();
    }
}