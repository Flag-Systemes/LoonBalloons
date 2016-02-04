using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Balloon
  {
    public Balloon(Cell startCell)
    {
      this.CurrentAltitude = 0;
      this.StartCell = startCell;
      this.CurrentCell = startCell;
    }

    public int CurrentAltitude { get; set; }

    public Cell CurrentCell { get; set; }

    public bool IsLost
    {
      get
      {
        return this.CurrentCell == null;
      }
    }

    public Cell StartCell { get; set; }
  }
}
