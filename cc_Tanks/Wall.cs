using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class Wall : IPicture
    {
        WallImg wallImg = new WallImg();
        Image img;

        public Image Img
        {
            get { return img; }
            //set { img = value; }
        }

        public Wall()
        {
            img = wallImg.Wall;
        }

        //  Image wallImg = new WallImg().Wall;     // 2 вар
    }
}
