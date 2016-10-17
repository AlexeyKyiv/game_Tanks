using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CCTanks
{
    public delegate void ChangeGameStatusDelegate();
    class Model             // класс по выполнению осн фун-ий (действий данного приложения)
    {
        public event ChangeGameStatusDelegate changeStreep;

        int sizeField,  amountTanks,  amountApples, collectedApples;
        public int speedGame;

        public GameStatus gameStatus;   // созд ссылку на перечисление

        Random r;

        Projectile projectIle;

        internal Projectile ProjectIle
        {
            get { return projectIle; }
        }
        Packman packman;

        internal Packman Packman
        {
            get { return packman; }
        }

        List<Tank> tanks;   // -   обопщенный тип List (для видимости из(скорее_в_) View)

        internal List<Tank> Tanks
        {
            get { return tanks; }
        }

        List<Apple> apples;

        List<FireTank> fireTank;
        internal List<FireTank> FireTank
        {
            get { return fireTank; }
        }

        internal List<Apple> Apples
        {
            get { return apples; }
            //set { apples = value; }
        }
            
        public Wall wall; 
        
        public Model(int sizeField, int amountTanks, int amountApples, int speedGame)       // КОНСТРУКТОР с входящ параметрами (атрибутами)
        {
            r = new Random();

            this.sizeField = sizeField;  this.amountTanks = amountTanks;  this.amountApples = amountApples;  this.speedGame = speedGame;
            
            NewGame();     

        }
        private void CreatApples()
        {
            CreatApples(0); 
        }

        private void CreatApples(int newApples)              // "создание" яблок, их random-разброска по полю И присвоению их обопщ-му Массиву List
        {
            int ii = (sizeField + 20) / 40;
            int x, y;
            while (apples.Count < amountApples + newApples)
            {
                x = r.Next(ii) * 40;
                y = r.Next(ii) * 40;
                bool flag = true;

                foreach (Apple a in apples)
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    apples.Add(new Apple(x, y));       //  Вызов КОНСТУКТОРА в классе Tank с 3 параметрами - ДОБАВЛЯЕМ ЕЛЕМЕНТЫ "яблоки" В LIST (обопщенный <> тип)
            }
        }

        private void CreatTanks()
        {
            int ii = (sizeField + 20) / 40;
            int x, y, x1, y1;
            while(tanks.Count < amountTanks + 1)
            {
                loop:                                           // для того, чтобы Охотник не появился рядом с Пакменом
                x1 = r.Next(ii) * 40; y1 = r.Next(ii) * 40;
                if (x1 > 70 && x1 < 170 && y1 > 190)
                    goto loop;

                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, x1, y1));
                x = r.Next(ii) * 40;
                y = r.Next(ii) * 40;
                bool flag = true;

                foreach (Tank t in tanks)
                {
                    if ((t.X == x && t.Y == y) || (x > 70 && x < 170 && y > 190))       // второе условие, чтобы враж танки не появл радом с пакманом
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    tanks.Add(new Tank(sizeField, x, y));       //  Вызов КОНСТУКТОРА в классе Tank с 3 параметрами
            }
        }

        public void Play()      // при запуске самой игры / кнопка Старт        (_ Запускаеться в отдельном ПОТОКЕ "modelPlay" _)
        {
            while(/*true*/gameStatus == GameStatus.playing)         // зацикленный/безконечный Цикл находящийся в управляемом (с возмож останов) потоке
            {
                Thread.Sleep(speedGame);

                RunAllObjectOnField();      // Метод задания Движения всем объектам на поле (в игре)

                TryDestroyTank();       // метод проверяющ Уничтожен танков снарядами
                    
                IfCollisionOfTanks();       // проверка условий на Столкновение танков между собой и их развороты

                IfCollisionOfTankAndPakman();        // проверка условий на Столкновение танков с ПАКМЕНОМ

                IfPickApple();                  // проверка условия на "поедание" (наезд) яблок Пакменом

                if (collectedApples > amountApples - 1)
                {
                    gameStatus = GameStatus.winer;
                    if (changeStreep != null)
                        changeStreep();
                }
            }
        }

        private void RunAllObjectOnField()
        {
            projectIle.Run();
            packman.Run();

            // вызываем еметод Run но для класса-наследника Hunter а ни класса Tank
            ((Hunter)tanks[0]).Run(packman.X, packman.Y);

            //foreach (Tank t in tanks)
            for (int i = 1; i < tanks.Count; i++)
                tanks[i].Run();

            foreach (FireTank ft in fireTank)
                ft.Fire();
        }

        private void IfPickApple()
        {
            for (int i = 0; i < Apples.Count; i++)
                //if (Packman.X == Apples[i].X && Packman.Y == Apples[i].Y)      // ИЛИ //
                if (Math.Abs(Packman.X - Apples[i].X) < 4 && (Math.Abs(Packman.Y - Apples[i].Y) < 4))    // - с учутом разбежности в пару пикселей
                {
                    apples[i] = new Apple(step += 20, 275);        // созд нов (объект) яблоко и присваиваетmcя вместо ябл на котор наехал танк с друг коорд (смещ вниз за поле)
                    collectedApples++;
                    CreatApples(collectedApples);
                }
        }

        private void IfCollisionOfTankAndPakman()
        {
            for (int i = 0; i < tanks.Count; i++)
                if
                    (
                            (Math.Abs(tanks[i].X - packman.X) <= 19) && (tanks[i].Y == packman.Y)
                        ||
                            (Math.Abs(tanks[i].Y - packman.Y) <= 19) && (tanks[i].X == packman.X)
                        ||
                            (Math.Abs(tanks[i].X - packman.X) <= 19) && (Math.Abs(tanks[i].Y - packman.Y) <= 19)
                    )
                {
                    gameStatus = GameStatus.loozer;
                    if (changeStreep != null)
                        changeStreep();
                }
        }

        private void IfCollisionOfTanks()
        {
            for (int i = 0; i < tanks.Count - 1; i++)
                for (int j = i + 1; j < tanks.Count; j++)
                    if (
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (tanks[i].Y == tanks[j].Y)
                        ||
                            (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20) && (tanks[i].X == tanks[j].X)
                        ||
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20)
                        )
                    {
                        if (i == 0)
                            ((Hunter)tanks[i]).TurnAround();
                        else
                            tanks[i].TurnAround();
                        tanks[j].TurnAround();
                    }
        }

        private void TryDestroyTank()
        {
            for (int i = 1; i < tanks.Count; i++)                 // i=1 - для исключения попадания в Охотника (i=0) снарядом
                //if ((Math.Abs(tanks[i].X - projectIle.X) < 11 ) && (Math.Abs(tanks[i].Y - projectIle.Y) < 11 ))                   ////////////////////////////////////////////
                if ((projectIle.X - tanks[i].X) < 17 && (projectIle.Y - tanks[i].Y) < 17 &&
                     (projectIle.X - tanks[i].X) > 3 && (projectIle.Y - tanks[i].Y) > 3)
                {
                    fireTank.Add(new FireTank(tanks[i].X, tanks[i].Y));

                    tanks.RemoveAt(i);
                    projectIle.DefaultSetting();
                }
        }

        int step;

        internal void NewGame()
        {
            collectedApples = 0;        // сброс кол-ва яблок при окончании предыдущ игре
            step = -15;
            projectIle = new Projectile();
            tanks = new List<Tank>();
            fireTank = new List<FireTank>();
            apples = new List<Apple>();
            packman = new Packman(sizeField);

            CreatTanks();
            CreatApples();   //  = 0
            wall = new Wall();
            gameStatus = GameStatus.stoping;
        }
    }
}
