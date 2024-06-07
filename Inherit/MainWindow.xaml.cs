using GTIC.Sincronizador.Helpers;
using Inherit.Entities;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inherit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string RutaFicheroComponentes { get; set; } = "Assets\\Componentes.xlsx";
        public string RutaFicheroPersonas { get; set; } = "Assets\\Personas.xlsx";
        public string RutaFicheroRelacion { get; set; } = "Assets\\RelacionComponentePersona.xlsx";

        public List<PersonaExcel> DatosCargaExcelPersonas { get; set; } = new List<PersonaExcel>();
        public List<ComponenteExcel> DatosCargaExcelComponente { get; set; } = new List<ComponenteExcel>();
        public List<RelacionComponentePersonaExcel> DatosCargaExcelRelacion { get; set; } = new List<RelacionComponentePersonaExcel>();

        public int MaximoPalabrasRevisadas { get; set; } = 2;
        public List<int> PalabrasYaRevisadas { get; set; } = new List<int>();

        public string SeccionActual = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            ActualizarDatosDelExcel();
        }
        public void ActualizarDatosDelExcel()
        {
            try
            {
                DatosCargaExcelPersonas = ExcelHelper.GetListFromExcel<PersonaExcel>(RutaFicheroPersonas, true);
                DatosCargaExcelComponente = ExcelHelper.GetListFromExcel<ComponenteExcel>(RutaFicheroComponentes, true);
                DatosCargaExcelRelacion = ExcelHelper.GetListFromExcel<RelacionComponentePersonaExcel>(RutaFicheroRelacion, true);

                foreach (var item in DatosCargaExcelRelacion)
                {
                    var nombreComponente = DatosCargaExcelComponente.FirstOrDefault(s => s.ID == item.IDCOMPONENTE);
                    item.NombreComponente = nombreComponente != null ? nombreComponente.Tipo : string.Empty;

                    var nombrePersona = DatosCargaExcelPersonas.FirstOrDefault(s => s.ID == item.IDPERSONA);
                    item.NombrePersona = nombrePersona != null ? nombrePersona.NombreCompleto : string.Empty;
                }

                txtCountTotal.Text = DatosCargaExcelComponente.Where(a=> a.Cantidad != null).Sum(s => s.Cantidad)?.ToString() + " €";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        TextBlock selectedTabPersonas = new TextBlock();
        private void rbPersonas_Checked(object sender, RoutedEventArgs e)
        {
            var seccion = "Personas";
            if (SeccionActual == seccion) return;

            SeccionActual = seccion;

            //rbPersonas.Checked = true;
            grdPersonas.Visibility = Visibility.Visible;
            grdComponentes.Visibility = Visibility.Collapsed;
            grdRelacionComponentePersona.Visibility = Visibility.Collapsed;

            //btnSiguientePersonas.Click += btnSiguiente_Click;
            //btnSiguienteAprendidos_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelAprendidos != null ? DatosCargaExcelAprendidos.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabPersonas = (TextBlock)sender;
            selectedTabPersonas.Background = Brushes.LightGray;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            UsuariosListView.ItemsSource = null;
            UsuariosListView.ItemsSource = DatosCargaExcelPersonas;

        }

        TextBlock selectedTabComponentes = new TextBlock();
        private void rbComponentes_Checked(object sender, RoutedEventArgs e)
        {
            var seccion = "Componentes";
            if (SeccionActual == seccion) return;

            SeccionActual = seccion;

            grdComponentes.Visibility = Visibility.Visible;
            grdPersonas.Visibility = Visibility.Collapsed;
            grdRelacionComponentePersona.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabComponentes = (TextBlock)sender;
            selectedTabComponentes.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            ComponentesListView.ItemsSource = null;
            ComponentesListView.ItemsSource = DatosCargaExcelComponente;
        }

        TextBlock selectedTabRelacion = new TextBlock();
        private void rbRelacionComponentePersona_Checked(object sender, RoutedEventArgs e)
        {
            var seccion = "Relación";
            if (SeccionActual == seccion) return;

            SeccionActual = seccion;

            grdRelacionComponentePersona.Visibility = Visibility.Visible;
            grdComponentes.Visibility = Visibility.Collapsed;
            grdPersonas.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabRelacion = (TextBlock)sender;
            selectedTabRelacion.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            if (DatosCargaExcelComponente != null && DatosCargaExcelComponente.Count > 0)
            {
                cbComponente.ItemsSource = DatosCargaExcelComponente;
                cbComponente.DisplayMemberPath = "Tipo";

                if (cbComponente.SelectedItem == null )
                    cbComponente.SelectedIndex = 0;
            }

            cbComponente_SelectionChanged(null, null);
            //Seleccion
        }

        #region Personas
        private void CrearPersona_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioFormView usuarioFormView = new UsuarioFormView(new PersonaExcel(), this);
                usuarioFormView.Show();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        private void EditIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var image = sender as Image;
                if (image != null)
                {
                    var dataContext = image.DataContext as PersonaExcel;
                    if (dataContext != null)
                    {
                        UsuarioFormView usuarioFormView = new UsuarioFormView(dataContext, this);
                        usuarioFormView.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        private void DeleteIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                var image = sender as Image;
                if (image != null)
                {
                    var dataContext = image.DataContext as PersonaExcel;
                    if (dataContext != null)
                    {
                        var id = dataContext.ID;
                        ExcelHelper.EliminarEntidad<PersonaExcel>(RutaFicheroPersonas, id);

                        ActualizarDatosDelExcel();

                        UsuariosListView.ItemsSource = null;
                        UsuariosListView.ItemsSource = DatosCargaExcelPersonas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Componentes

        private void CrearComponente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComponenteFormView usuarioFormView = new ComponenteFormView(new ComponenteExcel(), this);
                usuarioFormView.Show();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void EditComponente_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var image = sender as Image;
                if (image != null)
                {
                    var dataContext = image.DataContext as ComponenteExcel;
                    if (dataContext != null)
                    {
                        ComponenteFormView usuarioFormView = new ComponenteFormView(dataContext, this);
                        usuarioFormView.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void DeleteComponente_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar este componente?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                var image = sender as Image;
                if (image != null)
                {
                    var dataContext = image.DataContext as ComponenteExcel;
                    if (dataContext != null)
                    {
                        var id = dataContext.ID;
                        ExcelHelper.EliminarEntidad<ComponenteExcel>(RutaFicheroComponentes, id);

                        ActualizarDatosDelExcel();

                        ComponentesListView.ItemsSource = null;
                        ComponentesListView.ItemsSource = DatosCargaExcelComponente;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        #region Relación

        private void CantidadTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Obtener el objeto completo al que pertenece el TextBox
            var textBox = sender as TextBox;
            var item = textBox?.DataContext; // El objeto completo asociado al elemento de ListView

            // Aquí puedes hacer lo que necesites con el objeto completo, por ejemplo, guardar los cambios.
            // item representa el objeto completo asociado al elemento de ListView que se está editando.
        }

        private void PorcentajeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Obtener el objeto completo al que pertenece el TextBox
            var textBox = sender as TextBox;
            var item = textBox?.DataContext; // El objeto completo asociado al elemento de ListView

            // Aquí puedes hacer lo que necesites con el objeto completo, por ejemplo, guardar los cambios.
            // item representa el objeto completo asociado al elemento de ListView que se está editando.
        }

        //private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (textBox != null)
        //    {
        //        // Si el texto contiene una ",", la reemplaza con un "."
        //        if (e.Text == ",")
        //        {
        //            e.Handled = true; // Marca el evento como manejado para evitar que se ingrese la ","
        //            textBox.SelectedText = "."; // Reemplaza la "," con un "."
        //        }
        //    }
        //}

        public void cbComponente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbComponente.SelectedItem as ComponenteExcel;

            if (selectedItem != null) 
            {
                RelacionListView.ItemsSource = null;
                RelacionListView.ItemsSource = DatosCargaExcelRelacion.Where(s=>s.IDCOMPONENTE == selectedItem.ID);
            }
        }

        #endregion
    }
}
