using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

[assembly: CLSCompliant(true)]      // совместимость с другими языками

namespace CCTanks
{
    delegate void Invoker();
    public partial class ControllerMainForm : Form     // класс исполн фун-ию КОНТР!ОЛЛЕРА
    {
        View view;
        Model model;

        SoundPlayer sp;
        bool isSound;
        Thread modelPlay;       // создание потока для метода Run (при старте игры)
                                // КонстРукторЫ с разн кол-ом входящ парам / с возмож вызова констр с люб кол-ом парам (начин с любого - доходит до последн с мах кол-ом парам-ов)
        public ControllerMainForm() : this(260) { }
        public ControllerMainForm(int sizeField) : this(sizeField, 5) { }
        public ControllerMainForm(int sizeField, int amountTanks) : this(sizeField, amountTanks, 5) { }
        public ControllerMainForm(int sizeField, int amountTanks, int amountApples) : this(sizeField, amountTanks, amountApples, 40) { }
        public ControllerMainForm(int sizeField, int amountTanks, int amountApples, int speedGame)         // конструктор / добав вход-е атрибуты
        {
            InitializeComponent();
            model = new Model(sizeField, amountTanks, amountApples, speedGame);
            // подпись на событие
            model.changeStreep += new ChangeGameStatusDelegate(ChangerStatusStripLbl);

            view = new View(model);
            this.Controls.Add(view);        // добав доп форму (окно) на глав форму ДЛЯ ДАННОГО ЭКЗЕМПЛЯПРА КЛАССА Controller_MainForm
            isSound = false;
            sp = new SoundPlayer(Properties.Resources.soundTanks);
        }

        void ChangerStatusStripLbl()
        {
            Invoke(new Invoker(SetValueToStrLbl));
        }

        void SetValueToStrLbl()
        {
            GameStatus_lbl_ststrp.Text = model.gameStatus.ToString();

            if (isSound)
            {
                if (model.gameStatus == GameStatus.playing)
                    sp.PlayLooping();       //   воспроизводить мелодию по кругу
                else
                    sp.Stop();
            }

            /*if (model.gameStatus == GameStatus.playing)
                if (soundToolStripMenuItem1.Image == global::cc_Tanks.Properties.Resources.SOUND)
                    sp.Play();
            else sp.Stop();*/
        }

        void StartPause_btn_Click(object sender, EventArgs e)    // обработка события при нажатии СтартСтоп
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoping;

                StartStop_pcbx.Image = Properties.Resources.ppp1play1;         // смена картинки-кнопки с паузы на Старт
                //StartPause_btn.Image = Properties.Resources.ppp1play1;
                ChangerStatusStripLbl();
            }
            else
            {
                StartStop_pcbx.Focus();                     // делает кнопку (PictureBox) в Фокусе (видимой)
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();

                StartStop_pcbx.Image = Properties.Resources.ppp2pause1;         // смена картинки-кнопки со старта на Пауза
                //StartPause_btn.Image = Properties.Resources.ppp2pause1;
                ChangerStatusStripLbl();
                view.Invalidate();
            }
        }

        void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                model.gameStatus = GameStatus.stoping;
                modelPlay.Abort();      // дублируеться в методе Play (в условии цикла while)
            }

            sp.Stop();      // останов звук

            DialogResult dr = MessageBox.Show("Вы хотите закончить игру?", "Танки", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;            
        }

        // старый вариант с Button...
        /*
        private void ManipulatePackman(object sender, KeyPressEventArgs e)             // события от нажатия кнопки на Клаве или Мыши (прикрепл к контролу (кнопке Старт/Стоп) )
        {
            KeyPressForGame(e);

            // this.Text = e.KeyChar.ToString();       // (для проверки) Выводит в заголовке нажатый на клаве СИМВОЛ
        }

        
        public void KeyPressForGame(KeyPressEventArgs e)                // Событие от кнопки ( button ) СтартПауза (ОБРАБОТКА события)
        {
            switch (e.KeyChar)
            {
                case 'a':
                case 'ф':
                case 'A':
                case 'Ф':
                    {
                        model.Packman.NextDirect_x = -1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;
                case 'd':
                case 'в':
                case 'D':
                case 'В':
                    {
                        model.Packman.NextDirect_x = 1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;
                case 'w':
                case 'ц':
                case 'W':
                case 'Ц':
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = -1;
                    }
                    break;
                case 's':
                case 'і':
                case 'ы':
                case 'S':
                case 'І':
                case 'Ы':
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = 1;
                    }
                    break;

                default:
                    {
                        // стартовые Расположение и Направление для СНАРЯДА

                        //model.ProjectIle.X = model.Packman.X + 7;
                        //model.ProjectIle.Y = model.Packman.Y + 7;     //  вместо 2 строк (Снаряд вылетает из центра) допишем код снизу
                        model.ProjectIle.Direct_x = model.Packman.Direct_x;
                        model.ProjectIle.Direct_y = model.Packman.Direct_y;

                        if (model.Packman.Direct_y == -1)
                            {
                            model.ProjectIle.X = model.Packman.X + 7;
                            model.ProjectIle.Y = model.Packman.Y;
                            }
                        if (model.Packman.Direct_y == 1)
                            {
                            model.ProjectIle.X = model.Packman.X + 7;
                            model.ProjectIle.Y = model.Packman.Y + 17;
                            }
                        if (model.Packman.Direct_x == -1)
                            {
                            model.ProjectIle.Y = model.Packman.Y + 7;
                            model.ProjectIle.X = model.Packman.X;
                            }
                        if (model.Packman.Direct_x == 1)
                            {
                            model.ProjectIle.Y = model.Packman.Y + 7;
                            model.ProjectIle.X = model.Packman.X + 17;
                            }
                    }
                    break;
            }

        }
        */
        
        void Manipulation_pcbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)            // Событие от  PictureBox --- СтартПауза (ОБРАБОТКА события)
        {
            switch (e.KeyData.ToString())
            {
                //case 'a':
                //case 'ф':
                case "A":
                //case 'Ф':
                    {
                        model.Packman.NextDirect_x = -1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;
                //case 'd':
                //case 'в':
                case "D":
                //case 'В':
                    {
                        model.Packman.NextDirect_x = 1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;
                //case 'w':
                //case 'ц':
                case "W":
                //case 'Ц':
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = -1;
                    }
                    break;
                //case 's':
                //case 'і':
                //case 'ы':
                case "S":
                //case 'І':
                //case 'Ы':
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = 1;
                    }
                    break;

                //default:
                case "F": Fire(); break;
                case "L": Fire(); break;
            }
        }

        void Fire()
        {
            model.ProjectIle.Direct_x = model.Packman.Direct_x;
            model.ProjectIle.Direct_y = model.Packman.Direct_y;

            if (model.Packman.Direct_y == -1)
            {
                model.ProjectIle.X = model.Packman.X + 7;
                model.ProjectIle.Y = model.Packman.Y;
            }
            if (model.Packman.Direct_y == 1)
            {
                model.ProjectIle.X = model.Packman.X + 7;
                model.ProjectIle.Y = model.Packman.Y + 17;
            }
            if (model.Packman.Direct_x == -1)
            {
                model.ProjectIle.Y = model.Packman.Y + 7;
                model.ProjectIle.X = model.Packman.X;
            }
            if (model.Packman.Direct_x == 1)
            {
                model.ProjectIle.Y = model.Packman.Y + 7;
                model.ProjectIle.X = model.Packman.X + 17;
            }
        }

        void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void NewGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            model.NewGame();

            StartStop_pcbx.Image = Properties.Resources.ppp1play1;

            view.Refresh();     // ПЕРЕРИСОВКА сущностей
        }

        void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(/*@*/"Игра \"Танки\" 1.0\nРазработчик Гудок Александр и Alexey\n\nКнопки для управления: W, S, A, D\nКнопка для выстрала: L", "Танки",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        void soundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
            if (isSound)            
                soundToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.SOUND;
     
            else            
                soundToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.NOsound;
            
        }
    }
}
