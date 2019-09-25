using System.Collections.Generic;
using linkservicenet.Models;

namespace linkservicenet.Services
{
    public interface ILinkService {

        List<Link> Get();
        Link Get(string id);

        Link Create(Link link);
        void Update(string id, Link linkIn);
        void Remove(string id);
        void Remove(Link linkIn);

    }
}