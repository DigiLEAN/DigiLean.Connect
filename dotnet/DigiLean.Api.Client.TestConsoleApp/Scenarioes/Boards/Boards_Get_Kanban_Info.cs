﻿using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Boards
{
    public class Boards_Get_Kanban_Info : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var board = await apiClient.Version1.Boards.GetBoard(McKenzieTaskTestSettings.KanbanBoardId);
            Console.WriteLine(board.AsPrintJson());
        }
    }
}
