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
    public partial class frmCita : Window
    {
        DaoCita daocita = new DaoCita();
        DaoPaciente daopaciente = new DaoPaciente();
        DaoEmpleado daoempleado = new DaoEmpleado();
        Cita cita = new Cita();
        public frmCita()
        {
            InitializeComponent();
            var lsCita = daocita.GetAll();
            var lsPaciente = daopaciente.GetAll();
            var lsDoctor = daoempleado.GetAll();
            MostrarCitas();
            lsPaciente.Add(new Paciente { Id = 0, Nombre = "SELECCIONAR" });
            lsDoctor.Add(new Empleado { Id = 0, Nombre = "SELECCIONAR" });
            cbxDoctor.ItemsSource = lsDoctor;
            cbxDoctor.DisplayMemberPath = "Nombre";
            cbxDoctor.SelectedValuePath = "Id";
            cbxPaciente.ItemsSource = lsPaciente;
            cbxPaciente.DisplayMemberPath = "Nombre";
            cbxPaciente.SelectedValuePath = "Id";
            txtDecripcion.SelectAll();
            txtDecripcion.Selection.Text="";
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
                                FechaIngreso = c.FechaIngreso,
                                FechaCita = c.FechaCita,
                                Paciente = c.Paciente,
                                Doctor = d.Nombre,
                                Descripcion = c.Descripcion
                            });

            dgcita.ItemsSource = lsCita_Paciente_Doctor.OrderByDescending(x=>x.FechaIngreso);
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cita.FechaCita = FechaCita.SelectedDate.Value;
                cita.Doctor = (int)cbxDoctor.SelectedValue;
                cita.Paciente = (int)cbxPaciente.SelectedValue;
                var descripcion = new TextRange(txtDecripcion.Document.ContentStart, txtDecripcion.Document.ContentEnd);
                cita.Descripcion = descripcion.Text;
                daocita.Add(cita);
                MessageBox.Show("Registrado Correctamente");
                MostrarCitas();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
