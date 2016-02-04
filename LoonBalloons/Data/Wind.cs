using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Wind
  {
    public Wind(int forceX, int forceY)
    {
      this.ForceX = forceX;
      this.ForceY = forceY;
    }

    public int ForceX { get; private set; }

    public int ForceY { get; private set; }
  }
}
