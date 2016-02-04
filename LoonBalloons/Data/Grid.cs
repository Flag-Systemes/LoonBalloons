using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Grid : List<Cell>
  {
    public int Altitude { get; set; }

    public int ColsCount { get; set; }

    public int RowsCount { get; set; }

    public List<Cell> AdjacentsCells(Cell cell)
    {
      if(cell.AdjacentsCells == null)
      {
        cell.AdjacentsCells = this.Where(item => ((item.Y == cell.Y) && (item.X == cell.X - 1 || item.X == cell.X + 1)) || ((item.X == cell.X) && (item.Y == cell.Y - 1 || item.Y == cell.Y + 1))).ToList();
      }
      return cell.AdjacentsCells;
    }
  }
}
