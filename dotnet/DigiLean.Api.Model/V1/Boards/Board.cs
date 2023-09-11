using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Boards
{
    public class Board: BoardInfo
    {
        public List<BoardCategory> Rows { get; set; } = new List<BoardCategory>();
        public List<BoardCategory> Columns { get; set; } = new List<BoardCategory>();
    }
}
