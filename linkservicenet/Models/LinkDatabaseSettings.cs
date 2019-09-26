
using Microsoft.Extensions.Configuration;

namespace linkservicenet.Models 
{
    public class LinkDatabaseSettings: ILinkDatabaseSettings {

        public string LinkCollectionName {get; set;}
        public string ConnectionString {get; set; }
        public string DatabaseName {get; set;}
    }

    public interface ILinkDatabaseSettings {
        string LinkCollectionName {get; set;}
        string ConnectionString {get; set;}
        string DatabaseName {get; set;}
    }
}