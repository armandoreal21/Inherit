using GTIC.Sincronizador.Helpers;
using Inherit.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Inherit
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class UsuarioFormView : Window
    {
        public PersonaExcel Persona { get; set; }
        public MainWindow MainWindow { get; set; }
        public UsuarioFormView()
        {
            InitializeComponent();
        }

        public UsuarioFormView(PersonaExcel persona, MainWindow main)
        {
            InitializeComponent();
            Persona = persona;
            MainWindow = main;

            tbID.Text = persona.ID != null && persona.ID > 0 ? persona.ID.ToString() : ObtenerIdNuevo() ;
            tbNombre.Text = persona.NombreCompleto;

            tbNombre.Focus();
        }

        private string ObtenerIdNuevo()
        {
            var ultimoId = MainWindow.DatosCargaExcelPersonas.OrderByDescending(x => x.ID).FirstOrDefault();
            var personaId = ultimoId != null ? ultimoId.ID + 1 : 1;

            return personaId.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void CrearPersona_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var persona = new PersonaExcel();

                persona.ID = int.Parse(tbID.Text);
                persona.NombreCompleto = tbNombre.Text;
                persona.Fallecido = false;

                ExcelHelper.ActualizarEntidad<PersonaExcel>(MainWindow.RutaFicheroPersonas, persona);

                MainWindow.ActualizarDatosDelExcel();

                MainWindow.UsuariosListView.ItemsSource = null;
                MainWindow.UsuariosListView.ItemsSource = MainWindow.DatosCargaExcelPersonas;

                this.Close();

                //MessageBox.Show("Guardado con éxito");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
