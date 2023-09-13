using System.Net.Http;
using DigiLean.Connect.Client.Apis.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Connect.Client.Apis
{
    public class DigiLeanApiVersion1
    {
        public DatasourceApi Datasources { get; }
        public DataValuesApi DataValues { get; }
        public DatalistApi Datalists { get; }
        
        public DigiLeanApiVersion1(HttpClient client, ILogger logger)
        {
            Datasources = new DatasourceApi(client, logger);
            Datalists= new DatalistApi(client, logger);
            DataValues = new DataValuesApi(client, logger);
        }
    }
}
