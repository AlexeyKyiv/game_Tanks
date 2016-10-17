using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTanks
{
    class Hunter : Tank
    {
        // int target_x, target_y;  // не нужны, они и так там объявляються

        HunterImg hunterImg = new HunterImg();
        public Hunter(int sizeField, int x, int y) : base(sizeField, x, y)
        {
            Direct_y = -1;
            Direct_x = 0;
            PutImg();
            PutCurentImage();
        }
        private void PutImg()       // установка картинки (танка) (НУЖНОГО МАССИВА КАРТИНОК) - выполнение имитации ПОВОРОТА
        {
            if (direct_x == 1) img = hunterImg.Right;
            if (direct_x == -1) img = hunterImg.Left;
            if (direct_y == 1) img = hunterImg.Down;
            if (direct_y == -1) img = hunterImg.Up;        
        }
        /*new*/ public void Turn(int target_x, int target_y)      // new - перекрывает (делает главным данный метод) метод котор находится в родит классе с таким же названием
            {
                Direct_x = Direct_y = 0;

                if (X > target_x)
                    Direct_x = -1;
                if (X < target_x)
                    Direct_x = 1;
                if (Y > target_y)
                    Direct_y = -1;
                if (Y < target_y)
                    Direct_y = 1;

                if (Direct_x == 0 || Direct_y == 0)
                { }
                else
                    if (r.Next(5000) < 2500)
                        Direct_x = 0;
                    else
                        Direct_y = 0;
            
                PutImg();
            }
        public void Run(int target_x, int target_y)       // new (ПЕРЕОПРЕДЕЛЕНИЕ метода от родит) - УБРАИЛИ NEW так как он и так перегруженый
        {
            //this.target_x = target_x;
            //this.target_y = target_y;

            x += direct_x;
            y += direct_y;

            // если следующ услов выполн то выполн метод Turn()
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)         // IEEERemainder - метод вычисляющий Остаток от деления первого числа на второе

                Turn(target_x, target_y);             // можно и здесь расположить вместо расположения в классе Model;

            PutCurentImage();      // метод подставл картинки (имитац движения - анимация)      

            Transparent();      // метод для "прозрачных стен"
            //  x = ++y;        // движение по диагонали
        }
        new public void TurnAround()
        {
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }
    }
}
