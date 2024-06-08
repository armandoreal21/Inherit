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
    public partial class ComponenteFormView : Window
    {
        public ComponenteExcel Componente { get; set; }
        public MainWindow MainWindow { get; set; }
        public ComponenteFormView()
        {
            InitializeComponent();
        }

        public ComponenteFormView(ComponenteExcel componente, MainWindow main)
        {
            InitializeComponent();
            Componente = componente;
            MainWindow = main;

            tbID.Text = Componente.ID != null && Componente.ID > 0 ? Componente.ID.ToString() : ObtenerIdNuevo() ;
            tbNombre.Text = Componente.Tipo;
            tbCantidad.Text = Componente.Cantidad != null ? Componente.Cantidad.ToString() : "0";

            tbNombre.Focus();

        }

        private string ObtenerIdNuevo()
        {
            var ultimoId = MainWindow.DatosCargaExcelComponente.OrderByDescending(x => x.ID).FirstOrDefault();
            var ComponenteId = ultimoId != null ? ultimoId.ID + 1 : 1;

            return ComponenteId.ToString();
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

        private void CrearComponente_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var Componente = new ComponenteExcel();

                Componente.ID = int.Parse(tbID.Text);
                Componente.Tipo = tbNombre.Text;
                Componente.Cantidad = double.Parse(tbCantidad.Text);

                ExcelHelper.ActualizarEntidad<ComponenteExcel>(MainWindow.RutaFicheroComponentes, Componente);

                MainWindow.ActualizarDatosDelExcel();

                MainWindow.ComponentesListView.ItemsSource = null;
                MainWindow.ComponentesListView.ItemsSource = MainWindow.DatosCargaExcelComponente;

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
