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
    /// Lógica de interacción para frmRol.xaml
    /// </summary>
    public partial class frmRol : Page
    {
        private DaoRol dao = new DaoRol();
        Rol rol = new Rol(); 
        public frmRol()
        {
            InitializeComponent();
            var roles = dao.GetAll();
            dgrol.ItemsSource = roles; 

            ComboboxItem item = new ComboboxItem();
            item.Text = "Inactivo";
            
            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "Activo";        

            cmbEstado.Items.Add(item);
            cmbEstado.Items.Add(item2);

            cmbEstado.Text = "Activo";

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nombre = txtNombre.Text;
                if (!nombre.Equals(""))
                {
                    rol.Nombre = txtNombre.Text;

                    var valor = cmbEstado.SelectedValue.ToString();
                    if (valor.Equals("Activo"))
                    {
                        rol.Estado = 1.ToString();
                    }
                    else
                    {
                        rol.Estado = 0.ToString();
                    }

                    dao.Add(rol);
                    MessageBox.Show("Rol Agregado");

                    this.txtNombre.Text = "";
                    cmbEstado.Text = "Activo";
                    var roles = dao.GetAll();
                    dgrol.ItemsSource = roles;
                }
                else
                {
                    MessageBox.Show("Ingrese nombre rol","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
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
                Rol row = (Rol)dgrol.SelectedItem;
                int id = row.Id;
                rol.Id = id;

                var nombre = txtNombre.Text;
                if (!nombre.Equals(""))
                {

                    rol.Nombre = txtNombre.Text;
                    var valor = cmbEstado.SelectedValue.ToString();
                    if (valor.Equals("Activo"))
                    {
                        rol.Estado = 1.ToString();
                    }
                    else
                    {
                        rol.Estado = 0.ToString();
                    }
                    dao.Update(rol);

                    MessageBox.Show("Rol Modificado");

                    this.txtNombre.Text = "";
                    cmbEstado.Text = "Activo";
                    dgrol.ItemsSource = dao.GetAll();
                }
                else
                {
                    MessageBox.Show("Ingrese nombre rol", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
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
                Rol row = (Rol)dgrol.SelectedItem;
                int id = row.Id;
                rol.Id = id;
                if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dao.Delete(rol);
                    MessageBox.Show("Rol eliminado");

                    this.txtNombre.Text = "";
                    cmbEstado.Text = "Activo";
                    dgrol.ItemsSource = dao.GetAll();
                }
                
              
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

 

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtNombre.Text = "";
            cmbEstado.Text = "Activo";

        }

        private void dgrol_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Rol row = (Rol)dgrol.SelectedItem;
                txtNombre.Text = row?.Nombre;
               cmbEstado.Text = row?.Estado;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}