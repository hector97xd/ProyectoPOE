using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class frmPaciente : Page
    {
        private DaoPaciente dao = new DaoPaciente();
        Paciente paciente = new Paciente();
        //DaoPaciente daopaciente = new DaoPaciente();
        public frmPaciente()
        {
            InitializeComponent();
            
            var pacientes = dao.GetAll();
            dgPacientes.ItemsSource = pacientes;

        }

        private void dgPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try{
                Paciente row = (Paciente)dgPacientes.SelectedItem;
                txtNombre.Text = row?.Nombre;
                txtDUI.Text = row?.Dui;
                FechaNacimiento.SelectedDate = row?.fechaNacimiento;
                if (row?.sexo == "Masculino")
                {
                    rdbSexo.IsChecked = true;
                }
                else
                {
                    rdbSexo2.IsChecked = true;
                }
            }
            catch (Exception ex){
                ex.Message.ToString();
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                paciente.Nombre = txtNombre.Text;
                paciente.Dui = txtDUI.Text;
                paciente.fechaNacimiento = FechaNacimiento.SelectedDate.Value;

                if (rdbSexo.IsChecked.Value)
                {
                    paciente.sexo = rdbSexo.Content.ToString();
                }
                else
                {
                    paciente.sexo = rdbSexo2.Content.ToString();
                }

                dao.Add(paciente);
                
                MessageBox.Show("Paciente Agregado");

                var pacientes = dao.GetAll();
                dgPacientes.ItemsSource = pacientes;
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
                Paciente row = (Paciente)dgPacientes.SelectedItem;
                int id = row.Id;
                paciente.Id = id;

                paciente.Nombre = txtNombre.Text;
                paciente.Dui = txtDUI.Text;
                paciente.fechaNacimiento = FechaNacimiento.SelectedDate.Value;

                if (rdbSexo.IsChecked.Value)
                {
                    paciente.sexo = rdbSexo.Content.ToString();
                }
                else
                {
                    paciente.sexo = rdbSexo2.Content.ToString();
                }

                dao.Update(paciente);
                //Limpiar();
                MessageBox.Show("Paciente Modificado");
                dgPacientes.ItemsSource= dao.GetAll();
                //var pacientes = dao.GetAll();
                //dgPacientes.ItemsSource = pacientes;
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
                Paciente row = (Paciente)dgPacientes.SelectedItem;
                int id = row.Id;
                paciente.Id = id;
                dao.Delete(paciente);
                MessageBox.Show("PACIENTE ELIMINADO","CONFIRMACION",MessageBoxButton.OK,MessageBoxImage.Information);
                //var pacientes = dao.GetAll();
                //dgPacientes.ItemsSource = pacientes;
                dgPacientes.ItemsSource = dao.GetAll();
            }
            catch (Exception ex){
                ex.Message.ToString();
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtDUI.Text = "";
            this.FechaNacimiento.Text = "";
        }

      
    }
}
