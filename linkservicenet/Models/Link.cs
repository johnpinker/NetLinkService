using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace linkservicenet.Models {
    public class Link  {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        public string name { get; set;}
        public string href {get; set;}

        public Link()
        {
            
        }
        public Link(string name, string href)
        {
            this.name=name;
            this.href=href;
        }

        public Link(string id, string name, string href)
        {
            this.Id = id;
            this.name = name;
            this.href = href;
        }
    }
}