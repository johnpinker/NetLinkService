using linkservicenet.Services;
using linkservicenet.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests 
{
    public class TestLinkService : ILinkService
    {
        public List<Link> _links;

        public TestLinkService()
        {
            _links = new List<Link>();
            _links.Add(new Link() {Id = "1234", name="testname", href="testhref"});
        }
        public List<Link> Get() => _links;
        public Link Get(string id) => _links.Where(s => s.Id == id).FirstOrDefault();

        public Link Create(Link link) 
        { 
            Link tmpLink = new Link() {Id=link.Id, name=link.name, href=link.href};
            _links.Add(tmpLink);
            return tmpLink;
        }
        public void Update(string id, Link linkIn)
        {
            Link tmpLink = _links.Where(s => s.Id == id).FirstOrDefault();
            tmpLink.name = linkIn.name;
            tmpLink.href = linkIn.href;
        }
        public void Remove(string id)
        {
            _links = _links.Where(s => s.Id != id).ToList();
        }
        public void Remove(Link linkIn)
        {
            _links = _links.Where(s => s.Id != linkIn.Id).ToList();
        }
    }
}