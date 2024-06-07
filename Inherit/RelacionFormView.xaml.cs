using GTIC.Sincronizador.Helpers;
using Inherit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

            //tbID.Text = Relacion.ID != null && Relacion.ID > 0 ? Relacion.ID.ToString() : ObtenerIdNuevo() ;
            //tbNombre.Text = Relacion.Tipo;
            //tbCantidad.Text = Relacion.Cantidad != null ? Relacion.Cantidad.ToString() : "0";

            foreach (var item in MainWindow.DatosCargaExcelPersonas)            
                item.IsSelected = false;
            
            var lista = MainWindow.DatosCargaExcelPersonas;

            foreach (var item in lista)
            {
                var selectedItem = MainWindow.cbComponente.SelectedItem as ComponenteExcel;

                if (selectedItem != null)
                {
                    var existe = MainWindow.DatosCargaExcelRelacion.FirstOrDefault(s => s.IDCOMPONENTE == selectedItem.ID && s.IDPERSONA == item.ID);
                    item.IsSelected = existe != null;   
                }
            }

            UsuariosListView.ItemsSource = null;
            UsuariosListView.ItemsSource = lista;
        }

        private int ObtenerIdNuevo()
        {
            var ultimoId = MainWindow.DatosCargaExcelRelacion.OrderByDescending(x => x.ID).FirstOrDefault();
            var RelacionId = ultimoId != null ? ultimoId.ID + 1 : 0;

            return RelacionId;
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

        private void GuardarUsuariosRelacionados_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var listaActualizada = UsuariosListView.ItemsSource as List<PersonaExcel>;
                var listaEliminar = listaActualizada.Where(s => s.IsSelected == null || (bool)!s.IsSelected);
                var listaActualizar = listaActualizada.Where(s => s.IsSelected != null && (bool)s.IsSelected);

                foreach (var item in listaActualizada)
                {
                    MainWindow.ActualizarDatosRelacionDelExcel();
                    Thread.Sleep(100);
                    var selectedItem = MainWindow.cbComponente.SelectedItem as ComponenteExcel;

                    if (selectedItem != null)
                    {
                        var existia = MainWindow.DatosCargaExcelRelacion.FirstOrDefault(s => s.IDCOMPONENTE == selectedItem.ID && s.IDPERSONA == item.ID);

                        if (item.IsSelected != null && (bool)item.IsSelected && existia == null)
                        {
                            var rel = new RelacionComponentePersonaExcel();
                            rel.ID = ObtenerIdNuevo();
                            rel.IDCOMPONENTE = selectedItem.ID;
                            rel.IDPERSONA = item.ID;

                            ExcelHelper.ActualizarEntidad<RelacionComponentePersonaExcel>(MainWindow.RutaFicheroRelacion, rel);
                        }
                        else if (item.IsSelected == null || (bool)!item.IsSelected && existia != null)
                        {
                            ExcelHelper.EliminarEntidad<RelacionComponentePersonaExcel>(MainWindow.RutaFicheroRelacion, existia.ID);
                        }
                        
                    }

                   
                }

                //var Relacion = new RelacionComponentePersonaExcel();

                //Relacion.ID = int.Parse(tbID.Text);
                //Relacion.IDCOMPONENTE = tbNombre.Text;
                //Relacion.Tipo = tbNombre.Text;
                //Relacion.Cantidad = double.Parse(tbCantidad.Text);
                //Relacion.Porcentaje = double.Parse(tbCantidad.Text);

                //ExcelHelper.ActualizarEntidad<RelacionComponentePersonaExcel>(MainWindow.RutaFicheroRelacion, Relacion);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
