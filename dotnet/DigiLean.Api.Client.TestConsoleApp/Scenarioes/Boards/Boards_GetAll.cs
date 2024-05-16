namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Boards
{
    public class Boards_GetAll : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var boards = await apiClient.Version1.Boards.GetAll();
            foreach (var board in boards)
            {
                Console.WriteLine($"board: Id: {board.Id}, Name: {board.Name}, BoardType: {board.BoardType}");
            }
        }
    }
}
