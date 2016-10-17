using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class HunterImg
    {
        Image[] up = new Image[] { Properties.Resources.H_Tank0_1, Properties.Resources.H_Tank0_1i, Properties.Resources.H_Tank0_1ii };

        public Image[] Up
        {
            get { return up; }
            //set { up = value; }
        }
        Image[] down = new Image[] { Properties.Resources.H_Tank01, Properties.Resources.H_Tank01i, Properties.Resources.H_Tank01ii };

        public Image[] Down
        {
            get { return down; }
            //set { down = value; }
        }
        Image[] left = new Image[] { Properties.Resources.H_Tank_10, Properties.Resources.H_Tank_10i, Properties.Resources.H_Tank_10ii };

        public Image[] Left
        {
            get { return left; }
            //set { left = value; }
        }
        Image[] right = new Image[] { Properties.Resources.H_Tank10, Properties.Resources.H_Tank10i, Properties.Resources.H_Tank10ii };

        public Image[] Right
        {
            get { return right; }
            //set { right = value; }
        }

    }
}
