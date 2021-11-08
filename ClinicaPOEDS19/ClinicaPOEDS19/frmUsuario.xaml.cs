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
//Incluir librerias SQL
using System.Data;
using System.Data.SqlClient;
using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;

namespace ClinicaPOEDS19
{
    /// <summary>
    /// Lógica de interacción para frmUsuarios.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        private DaoUsuario dao = new DaoUsuario();
        Usuarios usu = new Usuarios();
        public frmUsuario()
        {
            InitializeComponent();
            var usuarios = dao.GetAll();
            dgusuarios.ItemsSource = usuarios;

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
                if(!txtUsuario.Text.Equals("") && !txtClave.Password.Equals(""))
                { 
                usu.Usuario = txtUsuario.Text;
                usu.Clave = txtClave.Password;

                var valor = cmbEstado.SelectedValue.ToString();
                if (valor.Equals("Activo"))
                {
                    usu.Estado = 1.ToString();
                }
                else
                {
                    usu.Estado = 0.ToString();
                }

                dao.Add(usu);
                MessageBox.Show("Usuario Agregado");

                var usuarios = dao.GetAll();
                dgusuarios.ItemsSource = usuarios;
                }
                else
                {
                    MessageBox.Show("Ingrese usuario y contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (!txtUsuario.Text.Equals("") && !txtClave.Password.Equals(""))
                {
                    Usuarios row = (Usuarios)dgusuarios.SelectedItem;
                    int id = row.Id;
                    usu.Id = id;

                    usu.Usuario = txtUsuario.Text;
                    usu.Clave = txtClave.Password;
                    var valor = cmbEstado.SelectedValue.ToString();
                    if (valor.Equals("Activo"))
                    {
                        usu.Estado = 1.ToString();
                    }
                    else
                    {
                        usu.Estado = 0.ToString();
                    }

                    dao.Update(usu);

                    MessageBox.Show("Usuario Modificado");
                    dgusuarios.ItemsSource = dao.GetAll();
                }
                else
                {
                    MessageBox.Show("Ingrese usuario y contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                Usuarios row = (Usuarios)dgusuarios.SelectedItem;
                int id = row.Id;
                usu.Id = id;
                if(MessageBox.Show("¿Esta seguro que desea eliminar?", "Confirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dao.Delete(usu);
                    MessageBox.Show("Usuario Eliminado");
                    dgusuarios.ItemsSource = dao.GetAll();
                }
             
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }



        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtUsuario.Text = "";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            this.txtClave.Password = "";
        }

        private void dgusuarios_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Usuarios row = (Usuarios)dgusuarios.SelectedItem;
                txtUsuario.Text = row?.Usuario;
                txtClave.Password = row?.Clave;
                cmbEstado.Text = row?.Estado;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}