using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CCTanks
{
    /*public*/ partial class View : UserControl
    {
        Model model;
        public View(Model model)
        {
            InitializeComponent();

            this.model = model;

        }

        // Вместо Подключения на СОБЫТИЕ в View.Designer.cs (закоментировано там для реализации "здесь") :
        void Draw(PaintEventArgs e)                     // ПЕРЕРИСОКА ИЗОБРАЖЕНИЯ ТАНКА (создавая новые объекты с новыми координатами)
        {
            DrawWall(e);
            DrawFireTank(e);
            DrawApple(e);
            DrawTank(e);
            DrawPackman(e);
            DrawProjectIle(e);

            if (model.gameStatus != GameStatus.playing)
                return;

            Thread.Sleep(model.speedGame);
            Invalidate();       // генерация события Paint (ПЕРЕРИСОВКА, вызываеться сама при "повреждении формы" - напр. выход за предел экрана)
        }

        private void DrawFireTank(PaintEventArgs e)
        {
            foreach (FireTank ft in model.FireTank)
                e.Graphics.DrawImage(ft.CurentImg, new Point(ft.X, ft.Y));
        }

        private void DrawProjectIle(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.ProjectIle.Img, new Point(model.ProjectIle.X, model.ProjectIle.Y));
        }

        private void DrawPackman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Packman.CurentImg, new Point(model.Packman.X, model.Packman.Y));
        }

        private void DrawApple(PaintEventArgs e)
        {
            for(int i=0; i<model.Apples.Count; i++)
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));

            //foreach (Apple a in model.Apples)
            //    e.Graphics.DrawImage(a.Img, new Point(a.X, a.Y));
            
        }

        private void DrawTank(PaintEventArgs e)     // рисует танк
        {
            //foreach(Tank t in model.Tanks)
            for (int i = 0; i < model.Tanks.Count; i++ )
                e.Graphics.DrawImage(model.Tanks[i].CurentImg, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }
        private void DrawWall(PaintEventArgs e)     // рисует стены
        {
            for (int y = 20; y < 260; y += 40)
                for (int x = 20; x < 260; x += 40)
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
        }
        protected override void OnPaint(PaintEventArgs e)       // метод, котор заменяет событие (ниже)
        {
            Draw(e);
        }

        // СОБЫТИЕ для ПЕРЕРИСОВКИ сущности (ТАНКА)     ((__ ВМЕСТО ниже указаного метода (View_Paint) ПЕРЕКИДУЕМ ВСЮ НАЧИНКУ В выше указаный метод "OnPaint" __))
        /*
        private void View_Paint(object sender, PaintEventArgs e)    // Событие для Пользоват.Елем.Управл-я (ПЕРЕРИСОВКА эл-та упр-ия) (данную начинку метода перенесли из ВНЕ во внутрь)
        {
            //Graphics gr = CreateGraphics();
            Thread.Sleep(model.speedGame);
            e.Graphics.DrawImage(model.tank.img, new Point(model.tank.x, model.tank.y));         // объект класса Graphics и ВЫВОД его на Экран
            Invalidate();       // перерисовка (частичная, контрола)
        }
        */
    }
}
