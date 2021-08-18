using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace TickClock.Areas.Identity.Mongo
{
    public class MongoIdentityOptions
    {
        public string ConnectionString { get; set; } = "mongodb://localhost/default";

        public string UsersCollection { get; set; } = "Users";

        public string RolesCollection { get; set; } = "Roles";

        public string MigrationCollection { get; set; } = "_Migrations";

        public SslSettings SslSettings { get; set; }

        public Action<ClusterBuilder> ClusterConfigurator { get; set; }
    }
}
