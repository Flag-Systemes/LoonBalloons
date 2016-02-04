using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoonBalloons.Utils
{
  public class Informations
  {
    public Informations()
    {
      FileResult = FileUtils.In;
    }

    public int Altitude { get; set; }

    public int Balloons { get; set; }

    public int Column { get; set; }

    public List<string> FileResult = new List<string>();
    
    public List<Tuple<int, int>> ListePositionTarget { get; set; }
    
    public int Radius { get; set; }

    public int Row { get; set; }

    public int TargetCell { get; set; }

    public int TurnNumber { get; set; }

    public int StartC { get; set; }

    public int StartR { get; set; }
  }
}
