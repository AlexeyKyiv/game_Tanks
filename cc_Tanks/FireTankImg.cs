using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class FireTankImg
    {
        Image[] img = new Image[] { Properties.Resources.Crash_Tank__1, Properties.Resources.Crash_Tank__2, Properties.Resources.Crash_Tank__3 };

        public Image[] Img
        {
            get { return img; }
        }
    }
}
