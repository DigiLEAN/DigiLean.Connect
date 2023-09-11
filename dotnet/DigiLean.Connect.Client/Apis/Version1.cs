using System.Net.Http;
using DigiLean.Connect.Client.Apis.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Connect.Client.Apis
{
    public class DigiLeanApiVersion1
    {
        public DatasourceApiV1 Datasources { get; }
        public DataValuesApiV1 DataValues { get; }

        public DatalistApi Datalists { get; }
        
        public DigiLeanApiVersion1(HttpClient client, ILogger logger)
        {
            Datasources = new DatasourceApiV1(client, logger);
            Datalists= new DatalistApi(client, logger);
            DataValues = new DataValuesApiV1(client, logger);
        }
    }
}
