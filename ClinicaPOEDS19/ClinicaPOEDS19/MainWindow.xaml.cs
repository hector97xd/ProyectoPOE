using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClinicaPOEDS19
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DaoUsuario dao = new DaoUsuario();
        Usuarios usu = new Usuarios();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            usu.Usuario = txtUsuario.Text;
            usu.Clave = txtClave.Password;         

            int resul = dao.FindUsuario(usu);

            if (resul > 0)
            {
                  frmUsuario frm = new frmUsuario();
                 frm.Show();
               // this.close();
            }
            else
            {
                MessageBox.Show("no existe");
            }
        }
    }
}
