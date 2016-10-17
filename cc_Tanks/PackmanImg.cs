using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class PackmanImg
    {
        Image[] up = new Image[] { Properties.Resources.P_Tank0_1, Properties.Resources.P_Tank0_1i, Properties.Resources.P_Tank0_1ii };

        public Image[] Up
        {
            get { return up; }
        }
        Image[] down = new Image[] { Properties.Resources.P_Tank01, Properties.Resources.P_Tank01i, Properties.Resources.P_Tank01ii };

        public Image[] Down
        {
            get { return down; }
        }
        Image[] left = new Image[] { Properties.Resources.P_Tank_10, Properties.Resources.P_Tank_10i, Properties.Resources.P_Tank_10ii };

        public Image[] Left
        {
            get { return left; }
        }
        Image[] right = new Image[] { Properties.Resources.P_Tank10, Properties.Resources.P_Tank10i, Properties.Resources.P_Tank10ii };

        public Image[] Right
        {
            get { return right; }
        }
    }
}