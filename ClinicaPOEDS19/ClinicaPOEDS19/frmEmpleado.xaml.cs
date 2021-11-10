using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class frmEmpleado : Page
    {
        private DaoEmpleado dao = new DaoEmpleado();
        Empleado empleado = new Empleado();
       // private object rdbSexo;
        //private object rdbSexo2;

        public object FechaNacimiento { get; private set; }

        
        public frmEmpleado()
        {
            InitializeComponent();
            var lstipoempleado = File.ReadAllLines("tipoempleado.txt");
            cbxTipoEmpleado.ItemsSource = lstipoempleado;

            var empleados = dao.GetAll();
            dgEmpleado.ItemsSource = empleados;

        }

        private void dgEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Empleado row = (Empleado)dgEmpleado.SelectedItem;
                txtNombre.Text = row?.Nombre;
                //txtId.Text = row?.Id;
                fechaNacimiento.SelectedDate = row?.fechaNacimiento;
                if (row?.sexo == "Masculino")
                {
                    rbdSexo.IsChecked = true;
                }
                else
                {
                    rbdSexo2.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                empleado.Nombre = txtNombre.Text;
                //paciente.Dui = txtDUI.Text;
                empleado.fechaNacimiento = fechaNacimiento.SelectedDate.Value;

                if (rbdSexo.IsChecked.Value)
                {
                    empleado.sexo = rbdSexo.Content.ToString();
                }
                else
                {
                    empleado.sexo = rbdSexo2.Content.ToString();
                }

                dao.Add(empleado);

                MessageBox.Show("Empleado Agregado");

                var empleados = dao.GetAll();
                dgEmpleado.ItemsSource = empleados;
                //Limpiar();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado row = (Empleado)dgEmpleado.SelectedItem;
                int id = row.Id;
                empleado.Id = id;

                empleado.Nombre = txtNombre.Text;
                //empleado.Dui = txtDUI.Text;
                empleado.fechaNacimiento = fechaNacimiento.SelectedDate.Value;

                if (rbdSexo.IsChecked.Value)
                {
                    empleado.sexo = rbdSexo.Content.ToString();
                }
                else
                {
                    empleado.sexo = rbdSexo2.Content.ToString();
                }

                dao.Update(empleado);
                //Limpiar();
                MessageBox.Show("EMPLEADO MODIFICADO");
                dgEmpleado.ItemsSource = dao.GetAll();
             
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Paciente row = (Paciente)dgEmpleado.SelectedItem;
                int id = row.Id;
                empleado.Id = id;
                dao.Delete(empleado);
                MessageBox.Show("EMPLEADO ELIMINADO", "CONFIRMACION", MessageBoxButton.OK, MessageBoxImage.Information);
                //var pacientes = dao.GetAll();
                //dgPacientes.ItemsSource = pacientes;
                dgEmpleado.ItemsSource = dao.GetAll();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txtNombre.Text = "";
            //this.txtDUI.Text = "";
            this.fechaNacimiento.Text = "";
        }



        private void txtNombre_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
