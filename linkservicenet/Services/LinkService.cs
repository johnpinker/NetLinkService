using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using linkservicenet.Models;

namespace linkservicenet.Services
{
    public class LinkService : ILinkService {

        private readonly IMongoCollection<Link> _links;

        public LinkService(ILinkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _links = database.GetCollection<Link>(settings.LinkCollectionName);
        }

        public List<Link> Get() => _links.Find(link => true).ToList();

        public Link Get(string id) => _links.Find<Link>(link => link.Id == id).FirstOrDefault();

        public Link Create(Link link) 
        {
            _links.InsertOne(link);
            return link;
        }

        public void Update(string id, Link linkIn) => _links.ReplaceOne(link => link.Id == id, linkIn);

        public void Remove(string id) => _links.DeleteOne(link => link.Id == id);

        public void Remove(Link linkIn) => _links.DeleteOne(link => link.Id == linkIn.Id);
    }
}