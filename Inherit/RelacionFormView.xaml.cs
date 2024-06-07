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
    public partial class RelacionFormView : Window
    {
        public RelacionComponentePersonaExcel Relacion { get; set; }
        public MainWindow MainWindow { get; set; }
        public RelacionFormView()
        {
            InitializeComponent();
        }

        public RelacionFormView(RelacionComponentePersonaExcel Relacion, MainWindow main)
        {
            InitializeComponent();
            Relacion = Relacion;
            MainWindow = main;

            tbID.Text = Relacion.ID != null && Relacion.ID > 0 ? Relacion.ID.ToString() : ObtenerIdNuevo() ;
            //tbNombre.Text = Relacion.Tipo;
            tbCantidad.Text = Relacion.Cantidad != null ? Relacion.Cantidad.ToString() : "0";

           
        }

        private string ObtenerIdNuevo()
        {
            var ultimoId = MainWindow.DatosCargaExcelRelacion.OrderByDescending(x => x.ID).FirstOrDefault();
            var RelacionId = ultimoId != null ? ultimoId.ID + 1 : 0;

            return RelacionId.ToString();
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

        private void CrearRelacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var Relacion = new RelacionComponentePersonaExcel();

                Relacion.ID = int.Parse(tbID.Text);
                //Relacion.IDCOMPONENTE = tbNombre.Text;
                //Relacion.Tipo = tbNombre.Text;
                Relacion.Cantidad = double.Parse(tbCantidad.Text);
                //Relacion.Porcentaje = double.Parse(tbCantidad.Text);

                ExcelHelper.ActualizarEntidad<RelacionComponentePersonaExcel>(MainWindow.RutaFicheroRelacion, Relacion);

                MainWindow.ActualizarDatosDelExcel();

                MainWindow.cbComponente_SelectionChanged(null, null);

                this.Close();

                MessageBox.Show("Guardado con éxito");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
