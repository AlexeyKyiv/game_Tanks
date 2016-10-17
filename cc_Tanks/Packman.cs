using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class Packman : IRan, ITurn, ITransparent, ICurentPicture
    {
        PackmanImg packmanImg = new PackmanImg();
        Image[] img;
        Image curentImg;
        public Image CurentImg
        {
            get { return curentImg; }
        }

        int sizeField;

        private int x, y, direct_x, direct_y, nextDirect_x, nextDirect_y;

        public int NextDirect_y                     // свойство (и поле) для задачи направления с клавиатуры (с Controller_MainForm)
        {
            get { return nextDirect_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_y = value;
                else nextDirect_y = 0;
            }
        }
        public int NextDirect_x
        {
            get { return nextDirect_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_x = value;
                else nextDirect_x = 0;
            }
        }
        public int Direct_y
        {
            get { return direct_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else direct_y = 0;
            }
        }
        public int Direct_x
        {
            get { return direct_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else direct_x = 0;
            }
        }
        public Packman(int sizeField)                       // ПЕРЕОПРЕДЕЛЕННЫЙ КОНСТРУКТОР для первых двух строк
        {
            this.sizeField = sizeField;     // присвоение размеров игрового поля

            this.x = 120;
            this.y = 240;
            this.NextDirect_x = 0;
            this.NextDirect_y = -1;
            this.Direct_x = 0;
            this.Direct_y = -1;

            PutImg();               // выполнение поворота танка (ПОВОРОТ КАРТИНКИ)

            PutCurentImage();        // curentImg = tankImg.Down[0] эта строка или метод       - для стартовой картинки танка в игре
        }

        public int Y
        {
            get { return y; }
        }
        public int X
        {
            get { return x; }
        }
        public void Run()
        {
            x += direct_x;
            y += direct_y;
            // если следующ услов выполн то выполн метод Turn()
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)         // IEEERemainder - метод вычисляющий Остаток от деления первого числа на второе
                Turn();             // можно и здесь расположить вместо расположения в классе Model;

            PutCurentImage();      // метод подставл картинки (имитац движения - анимация)      

            Transparent();      // метод для "прозрачных стен"
        }

        int k;
        private void PutCurentImage()       // перелистует картинки (анимация движения танка)
        {
            curentImg = img[k];
            k++;
            if (k == 3) k = 0;
        }

        public void Turn()
        {
            Direct_x = NextDirect_x;
            Direct_y = NextDirect_y;

            PutImg();
        }
        public void Transparent()           // метод для "прозрачных стен"
        {
            if (x == -1)
                x = sizeField - 21;
            if (x == sizeField - 19)
                x = 1;
            if (y == -1)
                y = sizeField - 21;
            if (y == sizeField - 19)
                y = 1;

        }
        void PutImg()       // установка картинки (танка) (НУЖНОГО МАССИВА КАРТИНОК) - выполнение имитации ПОВОРОТА
        {
            if (direct_x == 1) img = packmanImg.Right;
            if (direct_x == -1) img = packmanImg.Left;
            if (direct_y == 1) img = packmanImg.Down;
            if (direct_y == -1) img = packmanImg.Up;
        } 
    }
}
