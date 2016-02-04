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
            resultFile = FileUtils.In;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Altitude { get; set; }

        public List<Tuple<int, int>> Winds { get; set; }

        public int NbTour { get; set; }

        public int Ballons { get; set; }

        List<string> resultFile = new List<string>();
    }
}
