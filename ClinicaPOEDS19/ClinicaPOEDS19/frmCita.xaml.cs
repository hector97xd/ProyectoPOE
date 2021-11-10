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
using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;

namespace ClinicaPOEDS19
{
    /// <summary>
    /// Lógica de interacción para frmCita.xaml
    /// </summary>
    public partial class frmCita : Page
    {
        DaoCita daocita = new DaoCita();
        DaoPaciente daopaciente = new DaoPaciente();
        DaoEmpleado daoempleado = new DaoEmpleado();
        Cita cita = new Cita();
        int id = 0;
        public frmCita()
        {
            InitializeComponent();
            var lsCita = daocita.GetAll();
            var lsPaciente = daopaciente.GetAll();
            var lsDoctor = daoempleado.GetAll();
            MostrarCitas();
            lsPaciente.Add(new Paciente { Id = 0, Nombre = "Seleccionar" });
            lsDoctor.Add(new Empleado { Id = 0, Nombre = "Seleccionar" });
            cbxDoctor.ItemsSource = lsDoctor;
            cbxDoctor.DisplayMemberPath = "Nombre";
            cbxDoctor.SelectedValuePath = "Id";
            cbxPaciente.ItemsSource = lsPaciente;
            cbxPaciente.DisplayMemberPath = "Nombre";
            cbxPaciente.SelectedValuePath = "Id";
            txtDecripcion.SelectAll();
            txtDecripcion.Selection.Text = "";
            cbxPaciente.SelectedValue = 0;
            cbxDoctor.SelectedValue = 0;

        }

        public void MostrarCitas()
        {
            var lsCita = daocita.GetAll();
            var lsPaciente = daopaciente.GetAll();
            var lsDoctor = daoempleado.GetAll();
            var lsCita_Paciente_Doctor = lsCita.Join(lsPaciente,//Lista a unir
                            c => c.Paciente,
                            p => p.Id,
                            (c, p) => new
                            {
                                Id = c.Id,
                                FechaIngreso = c.FechaIngreso,
                                FechaCita = c.FechaCita,
                                Paciente = p.Nombre,
                                Doctor = c.Doctor,
                                Descripcion = c.Descripcion

                            }).Join(lsDoctor,//Lista a unir
                            c => c.Doctor,
                            d => d.Id,
                            (c, d) => new
                            {
                                Id = c.Id,
                                FechaIngreso = c.FechaIngreso,
                                FechaCita = c.FechaCita,
                                Paciente = c.Paciente,
                                Doctor = d.Nombre,
                                Descripcion = c.Descripcion
                            });

            dgcita.ItemsSource = lsCita_Paciente_Doctor.OrderByDescending(x => x.FechaIngreso);
        }
        public void limpiar()
        {
            cita.Id = 0;
            cbxPaciente.SelectedValue = 0;
            cbxDoctor.SelectedValue = 0;

        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                cita.FechaCita = FechaCita.Value.Value;
                cita.Doctor = (int)cbxDoctor.SelectedValue;
                cita.Paciente = (int)cbxPaciente.SelectedValue;
                var descripcion = new TextRange(txtDecripcion.Document.ContentStart, txtDecripcion.Document.ContentEnd);
                cita.Descripcion = descripcion.Text;
                if (cita.Id > 0)
                {
                    daocita.Update(cita);
                    MessageBox.Show("Modificación Completada", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    daocita.Add(cita);
                    MessageBox.Show("Registrado Correctamente", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                MostrarCitas();
                limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (dynamic)dgcita.SelectedItem;
                var id = row.Id;

                if (MessageBox.Show("¿Desea Continuar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    daocita.Delete(id);
                    MessageBox.Show("Registrado Eliminado", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar();
                    MostrarCitas();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgcita_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row = (dynamic)dgcita.SelectedItem;
                FechaCita.Value = row?.FechaCita;
                var doctorid = daoempleado.GetAll().Where(x => x.Nombre == row?.Doctor).FirstOrDefault()?.Id;
                var pacienteid = daopaciente.GetAll().Where(x => x.Nombre == row?.Paciente).FirstOrDefault()?.Id;
                cbxDoctor.SelectedValue = doctorid;
                cbxPaciente.SelectedValue = pacienteid;
                if (row?.Descripcion !=null)
                {
                    txtDecripcion.SelectAll();
                    txtDecripcion.Selection.Text = row?.Descripcion;
                   
                }
                if(row?.Id !=null)
                    cita.Id = row?.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
