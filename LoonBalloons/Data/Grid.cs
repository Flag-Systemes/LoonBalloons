using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public partial class Grid
  {
    public Grid(int columnsCount, int rowsCount)
    {
      this.ColumnsCount = columnsCount;
      this.RowsCount = rowsCount;
      this.Cells = new Cell[this.ColumnsCount, this.RowsCount];
    }

    public int Altitude { get; set; }

    public int BalloonRadius { get; set; }

    public Cell[,] Cells { get; private set; }

    public int ColumnsCount { get; set; }

    public int RowsCount { get; set; }

    public List<Cell> AdjacentsCells(Cell cell)
    {
      if (cell.AdjacentsCells == null)
      {
        // West
        cell.AdjacentsCells.Add(this.TranslatedCell(cell, -1, 0));

        // East
        cell.AdjacentsCells.Add(this.TranslatedCell(cell, +1, 0));

        // North
        cell.AdjacentsCells.Add(this.TranslatedCell(cell, 0, -1));

        // South
        cell.AdjacentsCells.Add(this.TranslatedCell(cell, 0, +1));

        cell.AdjacentsCells.RemoveAll(item => item == null);
      }
      
      return cell.AdjacentsCells;
    }

    public void MoveBalloon(Balloon balloon)
    {
      Wind wind = balloon.CurrentCell.Winds.First(item => item.Key == balloon.CurrentAltitude).Value;

      balloon.CurrentCell = this.TranslatedCell(balloon.CurrentCell, wind.ForceColumn, wind.ForceRow);
    }

    public Cell TranslatedCell(Cell startingCell, int tC, int tR)
    {
      int c = (startingCell.Column + tC) % this.ColumnsCount;
      int r = startingCell.Row + tR;
      return (r < 0 || r >= this.RowsCount) ? this.Cells[c, r] : null;
    }
  }
}
