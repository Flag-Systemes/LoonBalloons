using LoonBalloons.Utils;
using System;
using System.Collections.Generic;

namespace LoonBalloons.Data
{
  public partial class Grid
  {
    private int _line = 1;

    #region Propriétés
    public int Balloons { get; set; }
    
    public List<Tuple<int, int>> ListePositionTarget { get; set; }

    public int TargetNumber { get; set; }

    public int TurnNumber { get; set; }

    public int StartX { get; set; }

    public int StartY { get; set; }

    #endregion

    #region Get
    public static Grid NewGrid()
    {
      Grid newG = Grid.GetRowColumnAltitude();
      newG.GetTargetRadiusBalloonTurn();
      newG.GetStartingCells();
      newG.GetTargetPositions();
      newG.GetWinds();
      return newG;
    }

    public static Grid GetRowColumnAltitude()
    {
      var r = FileUtils.In[0].Split(' ');
      int rowsCount = int.Parse(r[0]);
      int columnsCount = int.Parse(r[1]);
      int altitude = int.Parse(r[2]);
      return new Grid(rowsCount, columnsCount, altitude);
    }

    public void GetTargetRadiusBalloonTurn()
    {
      var r = FileUtils.In[_line++].Split(' ');
      TargetNumber = int.Parse(r[0]);
      BalloonRadius = int.Parse(r[1]);
      Balloons = int.Parse(r[2]);
      TurnNumber = int.Parse(r[3]);
    }

    public void GetStartingCells()
    {
      var r = FileUtils.In[_line++].Split(' ');
      StartX = int.Parse(r[0]);
      StartY = int.Parse(r[1]);
    }

    public void GetTargetPositions()
    {
      ListePositionTarget = new List<Tuple<int, int>>();
      for (int i = 0; i < TargetNumber; i += 1)
      {
        var r = FileUtils.In[_line++].Split(' ');
        ListePositionTarget.Add(Tuple.Create<int, int>(int.Parse(r[0]), int.Parse(r[1])));
      }
    }

    public void GetWinds()
    {
      for (int a = 0; a < Altitude; a += 1)
      {
        for (int r = 0; r < RowsCount; r += 1)
        {
          var rav = FileUtils.In[_line++].Split(' ');
          int caseV = 0;
          for (int c = 0; c < ColumnsCount; c += 1)
          {
            Cells[r, c] = new Cell { Column = c, Row = r };
            Cells[r, c].Winds = new Dictionary<int, Wind>();
            Cells[r, c].Winds.Add(a, new Wind(int.Parse(rav[caseV++]), int.Parse(rav[caseV++])));
          }
        }
      }
    }
    #endregion

    #region Utils
    public double CalcColumnDist(Cell source, Cell dest)
    {
      return Math.Pow((
        Math.Pow((source.Row - dest.Row), 2) 
        + Math.Min(Math.Abs(source.Column - dest.Column), ColumnsCount - Math.Abs(source.Column - dest.Column))), 2);
    }
    #endregion
  }
}
