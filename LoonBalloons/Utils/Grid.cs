﻿using LoonBalloons.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

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
        var rav = FileUtils.In[_line++].Split(' ');
        for (int r = 0; r < RowsCount; r += 1)
        {
          int caseV = 0;
          for (int c = 0; c < ColumnsCount; c += 1)
          {
            if (Cells[c, r] == null)
            {
              Cells[c, r] = new Cell { Column = c, Row = r };
            }
            if (Cells[c, r].Winds == null)
            {
              Cells[c, r].Winds = new Dictionary<int, Wind>();
            }

            Cells[c, r].Winds.Add(a, new Wind(int.Parse(rav[caseV++]), int.Parse(rav[caseV++])));
          }
        }
      }
    }
    #endregion

    #region Utils
    public int CalcColumnDist(Cell source, Cell dest)
    {
      return Convert.ToInt32((Math.Pow((
        Math.Pow((source.Row - dest.Row), 2)
        + Math.Min(Math.Abs(source.Column - dest.Column), ColumnsCount - Math.Abs(source.Column - dest.Column))), 2)));
    }

    public void ToDebug()
    {
      int i = 0;
      int j = 0;
      Console.WriteLine("Rows: {0} - Columns: {1} - Altitude: {2}", RowsCount, ColumnsCount, Altitude);
      Console.WriteLine("Radius: {0} - Number of turns: {1}", BalloonRadius, TurnNumber);
      Console.WriteLine("Start X: {0} - Start Y: {1}", StartX, StartY);
      Console.WriteLine("Targets:");
      foreach (Tuple<int, int> t in ListePositionTarget)
      {
        Console.WriteLine("\t[{0}]: X = {1} - Y = {2}", i++, t.Item1, t.Item2);
      }
    }
    #endregion
  }
}
