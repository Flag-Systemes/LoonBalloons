using LoonBalloons.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Utils
{
  public partial class Grid
  {
    private int _line = 0;

    #region Propriétés
    public int Altitude { get; set; }

    public int Balloons { get; set; }

    public int Columns { get; set; }

    public List<Tuple<int, int>> ListePositionTarget { get; set; }

    public int Radius { get; set; }

    public int Rows { get; set; }

    public int TargetNumber { get; set; }

    public int TurnNumber { get; set; }

    public int StartX { get; set; }

    public int StartY { get; set; }

    public Dictionary<int, Wind> Winds { get; set; }

    #endregion
    #region Get
    public void Get()
    {
      GetRowColumnAltitude();
      GetTargetRadiusBalloonTurn();
      GetStartingCells();
      GetTargetPositions();
      GetWinds();
    }

    public void GetRowColumnAltitude()
    {
      var r = FileUtils.In[_line++].Split(' ');
      Rows = int.Parse(r[0]);
      Columns = int.Parse(r[1]);
      Altitude = int.Parse(r[2]);
    }

    public void GetTargetRadiusBalloonTurn()
    {
      var r = FileUtils.In[_line++].Split(' ');
      TargetNumber = int.Parse(r[0]);
      Radius = int.Parse(r[1]);
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
      Winds = new Dictionary<int, Wind>();
      for (int a = 0; a < Altitude; a += 1)
      {
        for (int r = 0; r < Rows; r += 1)
        {
          for (int c = 0; c < Columns; c += 1)
          {
          }
        }
      }
    }
    #endregion

    #region Utils
    public double CalcColumnDist(Cell source, Cell dest)
    {
      return Math.Pow((
        Math.Pow((source.X - dest.X), 2) 
        + Math.Min(Math.Abs(source.Y - dest.Y), Columns - Math.Abs(source.Y - dest.Y))), 2);
    }
    #endregion
  }
}
