using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;
using ClinicaPOEDS19.Reporte;
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
    /// Lógica de interacción para frmDiagnostico.xaml
    /// </summary>
    public partial class frmDiagnostico : Page
    {
        DaoDiagnostico daodiag = new DaoDiagnostico();
        DaoPaciente daopaciente = new DaoPaciente();
        DaoEmpleado daoempleado = new DaoEmpleado();
        Diagnostico diag = new Diagnostico();
        int id = 0;
        public frmDiagnostico()
        {
            InitializeComponent();
            var lsDiagnostico = daodiag.mostrar();
            var lsPaciente = daopaciente.GetAll();
            var lsDoctor = daoempleado.GetAll();
            MostrarDiagnostico();
            lsPaciente.Add(new Paciente { Id = 0, Nombre = "Seleccionar" });
            lsDoctor.Add(new Empleado { Id = 0, Nombre = "Seleccionar" });
            cmbDoctor.ItemsSource = lsDoctor;
            cmbDoctor.DisplayMemberPath = "Nombre";
            cmbDoctor.SelectedValuePath = "Id";
            cmbPaciente.ItemsSource = lsPaciente;
            cmbPaciente.DisplayMemberPath = "Nombre";
            cmbPaciente.SelectedValuePath = "Id";
            txtDecripcion.SelectAll();
            txtDecripcion.Selection.Text = "";
            txtTratamiento.SelectAll();
            txtTratamiento.Selection.Text = "";
            cmbPaciente.SelectedValue = 0;
            cmbDoctor.SelectedValue = 0;
            //FechaCita.Minimum = DateTime.Now;
        }

        bool ValidarForlmulario()
        {
            bool estado = true;//Asumir que todo esta ok
            string mensaje = null;
            //validando objeto
            if (string.IsNullOrEmpty(dpFecha.Text))
            {
                estado = false;
                mensaje += "-Fecha diagnostico\n";
            }
            if ( txtDecripcion.Document.Blocks.Count==0)
            {
                estado = false;
                mensaje += "-Descripcion diagnostico\n";

            }
            if (txtTratamiento.Document.Blocks.Count == 0)
            {
                estado = false;
                mensaje += "-Tratamiento diagnostico\n";

            }
            if (cmbPaciente.SelectedItem==null)
            {
                estado = false;
                mensaje += "-Seleccione un paciente\n";
            }
            if ((int)cmbDoctor.Items.Count==0)
            {
                estado = false;
                mensaje += "-Seleccione un doctor\n";
            }
            if (!estado)
            {
                MessageBox.Show("Favor de completar o corregir los sientes campos:\n\n" + mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            return estado;

        }

        public void MostrarDiagnostico()
        {
            var lsCita = daodiag.mostrar();
            var lsDiagnostico = daopaciente.GetAll();
            var lsDoctor = daoempleado.GetAll();
            var lsCita_Paciente_Doctor = lsCita.Join(lsDiagnostico,//Lista a unir
                            c => c.Paciente,
                            p => p.Id,
                            (c, p) => new
                            {
                                Id = c.Id,
                                FechaDiagnostico = c.fechaDiagnostico,
                                Descripcion=c.Descripcion,
                                Tratamiento=c.Tratamiento,
                                Paciente = p.Nombre,
                                Doctor = c.Doctor                               

                            }).Join(lsDoctor,//Lista a unir
                            c => c.Doctor,
                            d => d.Id,
                            (c, d) => new
                            {
                                Id = c.Id,
                                FechaDiagnostico = c.FechaDiagnostico,
                                Descripcion = c.Descripcion,
                                Tratamiento = c.Tratamiento,
                                Paciente = c.Paciente,
                                Doctor = d.Nombre
                               
                            });

            dgDiagnostico.ItemsSource = lsCita_Paciente_Doctor.OrderByDescending(x => x.FechaDiagnostico);
        }
        private void dgDiagnostico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = null;


            if (ValidarForlmulario())
            { 
                try
                {

                    diag.fechaDiagnostico = dpFecha.SelectedDate.Value;
                    diag.Doctor = (int)cmbDoctor.SelectedValue;
                    diag.Paciente = (int)cmbPaciente.SelectedValue;
                    var descripcion = new TextRange(txtDecripcion.Document.ContentStart, txtDecripcion.Document.ContentEnd);
                    diag.Descripcion = descripcion.Text;
                    var tratamiento = new TextRange(txtTratamiento.Document.ContentStart, txtTratamiento.Document.ContentEnd);
                    diag.Tratamiento = tratamiento.Text;
                    if (diag.Id > 0)
                    {
                        daodiag.Update(diag);
                        MessageBox.Show("Modificación Completada", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        daodiag.Add(diag);
                        MessageBox.Show("Registrado Correctamente", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    MostrarDiagnostico();
                    limpiar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void limpiar()
        {
            diag.Id = 0;
            cmbPaciente.SelectedValue = 0;
            cmbDoctor.SelectedValue = 0;
            txtDecripcion.Document.Blocks.Clear();
            txtTratamiento.Document.Blocks.Clear();
            dpFecha.SelectedDate =null;

        }

        private void dgDiagnostico_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row = (dynamic)dgDiagnostico.SelectedItem;
                dpFecha.SelectedDate = row?.FechaDiagnostico;
                var doctorid = daoempleado.GetAll().Where(x => x.Nombre == row?.Doctor).FirstOrDefault()?.Id;
                var pacienteid = daopaciente.GetAll().Where(x => x.Nombre == row?.Paciente).FirstOrDefault()?.Id;
                cmbDoctor.SelectedValue = doctorid;
                cmbPaciente.SelectedValue = pacienteid;
                if (row?.Descripcion != null)
                {
                    txtDecripcion.SelectAll();
                    txtDecripcion.Selection.Text = row?.Descripcion;

                }
                if (row?.Tratamiento != null)
                {
                    txtTratamiento.SelectAll();
                    txtTratamiento.Selection.Text = row?.Tratamiento;

                }
                if (row?.Id != null)
                    diag.Id = row?.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (dynamic)dgDiagnostico.SelectedItem;
                var id = row.Id;

                if (MessageBox.Show("¿Desea Continuar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    daodiag.Delete(id);
                    MessageBox.Show("Registrado Eliminado", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar();
                    MostrarDiagnostico();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            
           
            
            if (diag.Id <= 0)
            {
                MessageBox.Show("Seleccione un registro", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var row = (dynamic)dgDiagnostico.SelectedItem;
                var id = row.Id;
                rptDiagnostico rpt = new rptDiagnostico();
                frmReportes visor = new frmReportes();
                rpt.Load(@"ID.rep");
                rpt.SetParameterValue("ID", id);
                visor.crvReporte.ViewerCore.ReportSource = rpt;
                visor.Show();
            }
          
        }
    }
}
