using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class TankImg
    {
        Image[] up = new Image[] { Properties.Resources.Tank0_1, Properties.Resources.Tank0_1i, Properties.Resources.Tank0_1ii };

        public Image[] Up
        {
            get { return up; }
            //set { up = value; }
        }
        Image[] down = new Image[] { Properties.Resources.Tank01, Properties.Resources.Tank01i, Properties.Resources.Tank01ii };

        public Image[] Down
        {
            get { return down; }
            //set { down = value; }
        }
        Image[] left = new Image[] { Properties.Resources.Tank_10, Properties.Resources.Tank_10i, Properties.Resources.Tank_10ii };

        public Image[] Left
        {
            get { return left; }
            //set { left = value; }
        }
        Image[] right = new Image[] { Properties.Resources.Tank10, Properties.Resources.Tank10i, Properties.Resources.Tank10ii };

        public Image[] Right
        {
            get { return right; }
            //set { right = value; }
        }



        // стар вар - без Анимации (гусениц танка)
        /*
        private Image img0_1 = Properties.Resources.Tank0_1;
        private Image img01 = Properties.Resources.Tank01;
        private Image img10 = Properties.Resources.Tank10;   
        private Image img_10 = Properties.Resources.Tank_10; 
        public Image Img0_1
        {
            get { return img0_1; }
            set { img0_1 = value; }
        }
        public Image Img01
        {
            get { return img01; }
            set { img01 = value; }
        }
        public Image Img10
        {
            get { return img10; }
            set { img10 = value; }
        }
        public Image Img_10
        {
            get { return img_10; }
            set { img_10 = value; }
        }
         * */
    }
}
