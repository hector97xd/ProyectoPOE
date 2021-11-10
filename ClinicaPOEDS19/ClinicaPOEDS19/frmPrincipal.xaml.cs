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
using System.Windows.Shapes;

namespace ClinicaPOEDS19
{
    /// <summary>
    /// Lógica de interacción para frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        frmCita cita = new frmCita();
        frmDiagnostico diag = new frmDiagnostico();
        frmPaciente frmpaciente = new frmPaciente();
        frmEmpleado frmempleado = new frmEmpleado();
        frmUsuario frmusuario = new frmUsuario();
        frmRol frmrol = new frmRol();
        DaoUsuario daoUsuario = new DaoUsuario();
        DaoRol daoRol = new DaoRol();
        DaoUsuarioRol daoUsuarioRol = new DaoUsuarioRol();
        public frmPrincipal(Usuarios us)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowState = WindowState.Maximized;
            lblFecha.Content = DateTime.Now;
            var idus = daoUsuario.GetAll().Where(x => x.Usuario == us.Usuario).FirstOrDefault().Id;
            var idrol = daoUsuarioRol.GetAll().Where(x => x.Usuario == idus).FirstOrDefault().Rol;
            var rol = daoRol.GetRoles().Where(x => x.Id == idrol).FirstOrDefault().Nombre;
            switch (idrol)
            {
                case 1:
                    admin();
                    break;
                case 2:
                    enfermera();
                    break;
                case 3:
                    doctor();
                    break;

            }
            ocultar();
        }

        public void admin()
        {
            mostraropc();
        }
        public void enfermera()
        {
            collapseopc();
            acita.Visibility = Visibility.Visible;
        }
        public void doctor()
        {
            collapseopc();
            diagnostico.Visibility = Visibility.Visible;
        }
        public void mostraropc()
        {
            acita.Visibility = Visibility.Visible;
            diagnostico.Visibility = Visibility.Visible;
            mantenimiento.Visibility = Visibility.Visible;
            reportes.Visibility = Visibility.Visible;
        }
        public void collapseopc()
        {
            acita.Visibility = Visibility.Collapsed;
            diagnostico.Visibility = Visibility.Collapsed;
            mantenimiento.Visibility = Visibility.Collapsed;
            reportes.Visibility = Visibility.Collapsed;
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ocultar();
            frPrincipal.NavigationService.Navigate(cita);
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ocultar();
            frPrincipal.NavigationService.Navigate(diag);
        }

        private void lblCerrarSesion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        public void mostrar()
        {
            paciente.Visibility = Visibility.Visible;
            empleado.Visibility = Visibility.Visible;
            usuario.Visibility = Visibility.Visible;
            rol.Visibility = Visibility.Visible;
        }
        public void ocultar()
        {
            paciente.Visibility = Visibility.Hidden;
            empleado.Visibility = Visibility.Hidden;
            usuario.Visibility = Visibility.Hidden;
            rol.Visibility = Visibility.Hidden;
        }
        private void mantenimiento_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrar();
            frPrincipal.NavigationService.Navigate(frmpaciente);
        }

        private void paciente_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frPrincipal.NavigationService.Navigate(frmpaciente);
        }

        private void empleado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frPrincipal.NavigationService.Navigate(frmempleado);
        }

        private void usuario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frPrincipal.NavigationService.Navigate(frmusuario);
        }

        private void rol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frPrincipal.NavigationService.Navigate(frmrol);
        }
    }
}
