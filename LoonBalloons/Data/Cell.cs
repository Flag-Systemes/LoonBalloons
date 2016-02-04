﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Cell
  {
    public List<Cell> AdjacentsCells { get; set; }

    public int Column { get; set; }

    public int Row { get; set; }
    
    public Dictionary<int, Wind> Winds { get; set; }
  }
}
