using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Balloon
  {
    public int CurrentAltitude { get; set; }

    public Cell CurrentCell { get; set; }

    public bool IsLost { get; set; }

    public Cell StartCell { get; set; }
  }
}
