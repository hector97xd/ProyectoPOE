using ClinicaPOEDS19.DbContext;
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
using System.Windows.Shapes;

namespace ClinicaPOEDS19
{
    /// <summary>
    /// Lógica de interacción para frmPaciente.xaml
    /// </summary>
    public partial class frmPaciente : Window
    {
        private DaoPaciente dao = new DaoPaciente();
        public frmPaciente()
        {
            InitializeComponent();
            var pacientes = dao.GetAll();
            dgPacientes.ItemsSource = pacientes;

        }

        private void dgPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
