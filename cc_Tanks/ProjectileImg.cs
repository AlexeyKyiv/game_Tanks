using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class ProjectileImg
    {
        Image up = Properties.Resources.Ile0_1;

        public Image Up
        {
            get { return up; }
        }
        Image down = Properties.Resources.Ile01;

        public Image Down
        {
            get { return down; }
        }
        Image left = Properties.Resources.Ile_10;

        public Image Left
        {
            get { return left; }
        }
        Image right = Properties.Resources.Ile10;

        public Image Right
        {
            get { return right; }
            //set { right = value; }
        }
    }
}
