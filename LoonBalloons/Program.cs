﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoonBalloons.Utils;
using LoonBalloons.Data;

namespace LoonBalloons
{
  class Program
  {
    static void Main(string[] args)
    {
      Grid grid = Grid.NewGrid();

      List<Cell> cells = grid.CoveredCells(grid.Cells[3, 3], 3);
    }
  }
}
