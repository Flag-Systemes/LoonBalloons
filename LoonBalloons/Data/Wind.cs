using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Data
{
  public class Wind
  {
    public Wind(int forceColumn, int forceRow)
    {
      this.ForceColumn = forceColumn;
      this.ForceRow = forceRow;
    }

    public int ForceColumn { get; private set; }

    public int ForceRow { get; private set; }
  }
}
