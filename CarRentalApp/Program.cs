using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //In the C# Program.cs file which contains the Main method
            //of the whole project if we want to choose which form is
            //displayed first, we only have to change the third line in
            //the method.
            // This one (Application.Run(new AddRentalRecord());)
            Application.Run(new Login());
        }
    }
}
