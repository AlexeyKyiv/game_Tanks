using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CCTanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string [] arg)
        {
            ControllerMainForm cm;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch(arg.Length)
            {   
                case 0: cm = new ControllerMainForm(); break;
                case 1: cm = new ControllerMainForm(Convert.ToInt32(arg[0], new CultureInfo("En", true))); break;
                case 2: cm = new ControllerMainForm(Convert.ToInt32(arg[0], new CultureInfo("En", true)), Convert.ToInt32(arg[1], new CultureInfo("En", true))); break;
                case 3: cm = new ControllerMainForm(Convert.ToInt32(arg[0], new CultureInfo("En", true)), Convert.ToInt32(arg[1], new CultureInfo("En", true)), 
                                                              Convert.ToInt32(arg[2], new CultureInfo("En", true))); break;
                case 4: cm = new ControllerMainForm(Convert.ToInt32(arg[0], new CultureInfo("En", true)), Convert.ToInt32(arg[1], new CultureInfo("En", true)), 
                                                              Convert.ToInt32(arg[2], new CultureInfo("En", true)), Convert.ToInt32(arg[3], new CultureInfo("En", true))); break;
                default: cm = new ControllerMainForm(); break;
            }

            Application.Run(cm);
            // Application.Run(new Controller_MainForm()); // было вначале /
        }
    }
}
