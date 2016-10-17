using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class FireTank
    {
        private FireTankImg fireTankImg = new FireTankImg();
        Image curentImg;
        Image[] img;

        public Image CurentImg
        {
            get { return curentImg; }
        }

        int x, y;

        public int Y
        {
            get { return y; }
        }
        public int X
        {
            get { return x; }
        }

        public FireTank(int x, int y)
        {
            this.x = x; this.y = y;

            img = fireTankImg.Img;      // присваивается массив картинок

            PutCurentImage();           // присваивается конкретная картинка
        }

        public void Fire()
        {
            PutCurentImage();
        }

        int k;
        protected void PutCurentImage()
        {
            curentImg = img[k];
            k++;
            if (k == 3) k = 0;
        }


    }
}
