using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EJ4_ParcialFinal_WPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DBControler dataControl = new DBControler();

        // Propiedad estatica de solo lectura.
        public static DBControler DataControl
        {
            get { return App.dataControl; }
        }

    }
}
