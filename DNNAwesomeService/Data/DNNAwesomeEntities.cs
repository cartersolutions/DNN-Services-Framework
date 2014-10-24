using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNNAwesomeService.Data
{
    public partial class DNNAwesomeEntities: DbContext
    {
        public DNNAwesomeEntities(string connectionString)
            : base(connectionString)
        { }

        public static DNNAwesomeEntities Instance()
        {
            var entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder();
            entityBuilder.ProviderConnectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();
            entityBuilder.Metadata = "res://*/";
            entityBuilder.Provider = "System.Data.SqlClient";

            return new DNNAwesomeEntities(entityBuilder.ToString());
        }
    }
}
