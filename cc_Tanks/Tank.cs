using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class Tank : IRan, ITurn, ITurnAround, ITransparent, ICurentPicture
    {
        TankImg tankImg = new TankImg();        // созд ссылку/объект класса TankImg
        void PutImg()       // установка картинки (танка) (НУЖНОГО МАССИВА КАРТИНОК) - выполнение имитации ПОВОРОТА
        {
            if (direct_x == 1) img = tankImg.Right;
            if (direct_x == -1) img = tankImg.Left;
            if (direct_y == 1) img = tankImg.Down;
            if (direct_y == -1) img = tankImg.Up;
        }

        protected Image[] img;                              // созд ссылку класса Image (изображения!)
        protected Image curentImg;        // переменная типа Image (картинка, изобр) для отображаемой в данный момент картинки из массива
        protected int sizeField;
                
        protected int x, y, direct_x, direct_y;

        protected static Random r;

        protected int k;
        protected void PutCurentImage()
        {
            curentImg = img[k];
            k++;
            if (k == 3) k = 0;
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
        public Tank(int sizeField, int x, int y)                       // ПЕРЕОПРЕДЕЛЕННЫЙ КОНСТРУКТОР для первых двух строк
        {
            this.sizeField = sizeField;     // присвоение размеров игрового поля

            r = new Random();

            if (r.Next(5000) < 2500)
            {
                Direct_y = 0;
            loop:
                Direct_x = r.Next(-1, 2);
                if (Direct_x == 0)
                    goto loop;
            }
            else
            {
                Direct_x = 0;
            loop1:
                Direct_y = r.Next(-1, 2);
                if (Direct_y == 0)
                    goto loop1;
            }

            PutImg();

            PutCurentImage();        // curentImg = tankImg.Down[0] эта строка или метод       - для стартовой картинки танка в игре

            this.x = x; this.y = y;
        }

        public int Y
        {
            get { return y; }
            //set { y = value; }
        }
        public int X
        {
            get { return x; }
            //set { x = value; }
        }
        public Image CurentImg
        {
            get { return curentImg; }
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
        public void Turn()
        {
                if (r.Next(5000) < 2500) //  двигаемся далее по вертикали (ПРИНИМАЕМ РЕШЕНИЕ Random-ом ЧТО БУДЕМ ДВИГАТЬСЯ  ПО ВЕРТИКАЛИ)
                {
                    if (Direct_y == 0)
                    {
                        direct_x = 0;
                        while (Direct_y == 0)           // крутим цикл до момента пока Direct_y станет равным 0
                            Direct_y = r.Next(-1, 2);       // цыкл для того, что нас не устраивает 0 и мы ждем 1 или -1 (то есть ВПЕРЕД ИЛИ НАЗАД) 
                    }
                }
                else // двигаемся далее по горизонтали
                {
                    if (Direct_x == 0)
                    {
                        direct_y = 0;
                        while (Direct_x == 0)           // крутим цикл до момента пока Direct_x станет равным 0
                            Direct_x = r.Next(-1, 2);
                    }
                }

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

        // метод для разворота танка с View
        public void TurnAround()
        {
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }
    }
}
