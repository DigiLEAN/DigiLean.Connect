using DigiLean.Api.Client.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client
{
    public class PublicApiVersion1
    {
        public BoardsApi Boards { get; }
        public DatasourceApiV1 Datasources { get; }
        public DataValuesApiV1 DataValues { get; }

        public DatalistApi Datalists { get; }
        public ProjectsApi Projects { get; }
        public CustomersApi Customers { get; }
        public UsersApi Users { get; }
        public GroupsApi Groups { get; }
        public IncidentsApi Incidents { get; }
        public ImprovementsApi Improvements { get; }
        public TasksApi Tasks { get; }
        public PublicApiVersion1(HttpClient client, ILogger? logger)
        {
            Boards = new BoardsApi(client, logger);
            Datasources = new DatasourceApiV1(client, logger);
            Datalists= new DatalistApi(client, logger);
            DataValues = new DataValuesApiV1(client, logger);
            Projects = new ProjectsApi(client, logger);
            Customers = new CustomersApi(client, logger);
            Users = new UsersApi(client, logger);
            Groups = new GroupsApi(client, logger);
            Incidents = new IncidentsApi(client, logger);
            Improvements = new ImprovementsApi(client, logger);
            Tasks = new TasksApi(client, logger);
        }
    }
}
