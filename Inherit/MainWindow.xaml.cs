using GTIC.Sincronizador.Helpers;
using Inherit.Entities;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public int SelectIndexComponenteCB { get; set; } = 0;

        private ComponenteExcel _selectedComponente;

        public ObservableCollection<RelacionComponentePersonaExcel> RelacionList { get; set; }

        public List<ComponenteExcel> Componentes { get; set; }

        public ComponenteExcel SelectedComponente
        {
            get => _selectedComponente;
            set
            {
                if (_selectedComponente != value)
                {
                    _selectedComponente = value;
                    OnPropertyChanged(nameof(SelectedComponente));
                    UpdateRelacionList();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateRelacionList()
        {
            foreach (var item in RelacionList)
            {
                item.SelectedComponente = SelectedComponente;
            }
        }


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

                var totalAsignado = DatosCargaExcelRelacion.Where(a => a.Cantidad != null).Sum(s => s.Cantidad);
                txtCountTotalAsignado.Text = (totalAsignado != null ? ((double)totalAsignado).ToString("0.##") : "0") + " €";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarDatosRelacionDelExcel()
        {
            try
            {
                DatosCargaExcelRelacion = ExcelHelper.GetListFromExcel<RelacionComponentePersonaExcel>(RutaFicheroRelacion, true);

                foreach (var item in DatosCargaExcelRelacion)
                {
                    var nombreComponente = DatosCargaExcelComponente.FirstOrDefault(s => s.ID == item.IDCOMPONENTE);
                    item.NombreComponente = nombreComponente != null ? nombreComponente.Tipo : string.Empty;

                    var nombrePersona = DatosCargaExcelPersonas.FirstOrDefault(s => s.ID == item.IDPERSONA);
                    item.NombrePersona = nombrePersona != null ? nombrePersona.NombreCompleto : string.Empty;
                }
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
            grdResumen.Visibility = Visibility.Collapsed;
            grdConfiguracion.Visibility = Visibility.Collapsed;

            //btnSiguientePersonas.Click += btnSiguiente_Click;
            //btnSiguienteAprendidos_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelAprendidos != null ? DatosCargaExcelAprendidos.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabPersonas = (TextBlock)sender;
            selectedTabPersonas.Background = Brushes.LightGray;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            if (selectedTabResumen != null)
                selectedTabResumen.Background = Brushes.Transparent;

            if (selectedTabConfiguracion != null)
                selectedTabConfiguracion.Background = Brushes.Transparent;

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
            grdResumen.Visibility = Visibility.Collapsed;
            grdConfiguracion.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabComponentes = (TextBlock)sender;
            selectedTabComponentes.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            if (selectedTabResumen != null)
                selectedTabResumen.Background = Brushes.Transparent;

            if (selectedTabConfiguracion != null)
                selectedTabConfiguracion.Background = Brushes.Transparent;

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
            grdResumen.Visibility = Visibility.Collapsed;
            grdConfiguracion.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabRelacion = (TextBlock)sender;
            selectedTabRelacion.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            if (selectedTabResumen != null)
                selectedTabResumen.Background = Brushes.Transparent;

            if (selectedTabConfiguracion != null)
                selectedTabConfiguracion.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            if (DatosCargaExcelComponente != null && DatosCargaExcelComponente.Count > 0)
            {
                cbComponente.ItemsSource = DatosCargaExcelComponente;
                cbComponente.DisplayMemberPath = "Tipo";

                if (cbComponente.SelectedItem == null )
                    cbComponente.SelectedIndex = SelectIndexComponenteCB;
            }

            cbComponente_SelectionChanged(null, null);
            //Seleccion
        }

        TextBlock selectedTabResumen = new TextBlock();
        private void rbResumen_Checked(object sender, RoutedEventArgs e)
        {
            var seccion = "Resumen";
            if (SeccionActual == seccion) return;

            SeccionActual = seccion;

            grdResumen.Visibility = Visibility.Visible;
            grdComponentes.Visibility = Visibility.Collapsed;
            grdPersonas.Visibility = Visibility.Collapsed;
            grdRelacionComponentePersona.Visibility = Visibility.Collapsed;
            grdConfiguracion.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabResumen = (TextBlock)sender;
            selectedTabResumen.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            if (selectedTabConfiguracion != null)
                selectedTabConfiguracion.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            //ResumenListView.ItemsSource = null;
            //ResumenListView.ItemsSource = DatosCargaExcelRelacion;

            if (DatosCargaExcelRelacion == null) return;

            var items = new List<Item>();
            var entidad1 = new Entidad { Nombre = "Componente" };
            var entidad2 = new Entidad { Nombre = "Persona" };

            foreach (var itemComponente in DatosCargaExcelComponente.OrderBy(s=>s.Tipo))
            {
                var sumaPorcentaje = DatosCargaExcelRelacion.Where(a=>a.IDCOMPONENTE == itemComponente.ID && a.Porcentaje != null).Sum(s => s.Porcentaje);
                var sumaCantidad = DatosCargaExcelRelacion.Where(a=>a.IDCOMPONENTE == itemComponente.ID && a.Cantidad != null).Sum(s => s.Cantidad);
                items.Add(new Item { 
                    Nombre = itemComponente.Tipo, 
                    Cantidad = (sumaCantidad != null ? ((double)sumaCantidad).ToString("0.##") + "/" : "0/") + (itemComponente.Cantidad != null ? ((double)itemComponente.Cantidad).ToString("0.##") + "€" : "0 €"),
                    //Total = sumaCantidad != null ? ((double)sumaCantidad).ToString("0.##") + "/" : "0/" + itemComponente.Cantidad != null ? ((double)itemComponente.Cantidad).ToString("0.##") + "€" : "0 €",
                    Porcentaje = sumaPorcentaje!= null? ((double)sumaPorcentaje).ToString("0.##") + "%" : "0 %", 
                    Entidad = entidad1 });

                foreach (var itemPersona in DatosCargaExcelRelacion.Where(a => a.IDCOMPONENTE == itemComponente.ID).OrderBy(s=>s.NombrePersona))
                {
                    items.Add(new Item
                    {
                        Nombre = itemPersona.NombrePersona,
                        Cantidad = itemPersona.Cantidad != null ? ((double)itemPersona.Cantidad).ToString("0.##") + "€" : "0 €",
                        Total = "",
                        Porcentaje = itemPersona.Porcentaje != null ? ((double)itemPersona.Porcentaje).ToString("0.##") + "%" : "0 %",
                        Entidad = entidad2
                    });
                }
            }

            ListBoxItems.ItemsSource = items;

        }

        TextBlock selectedTabConfiguracion = new TextBlock();
        private void rbConfiguracion_Checked(object sender, RoutedEventArgs e)
        {
            var seccion = "Configuracion";
            if (SeccionActual == seccion) return;

            SeccionActual = seccion;

            grdConfiguracion.Visibility = Visibility.Visible;
            grdComponentes.Visibility = Visibility.Collapsed;
            grdPersonas.Visibility = Visibility.Collapsed;
            grdRelacionComponentePersona.Visibility = Visibility.Collapsed;
            grdResumen.Visibility = Visibility.Collapsed;

            //btnSiguienteComponentes_Click(null, null);

            //txtCountTotal.Text = (DatosCargaExcelComponentes != null ? DatosCargaExcelComponentes.Count : 0) + " de " + (DatosCargaExcel != null ? DatosCargaExcel.Count : 0);

            selectedTabConfiguracion = (TextBlock)sender;
            selectedTabConfiguracion.Background = Brushes.LightGray;

            if (selectedTabPersonas != null)
                selectedTabPersonas.Background = Brushes.Transparent;

            if (selectedTabComponentes != null)
                selectedTabComponentes.Background = Brushes.Transparent;

            if (selectedTabRelacion != null)
                selectedTabRelacion.Background = Brushes.Transparent;

            if (selectedTabResumen != null)
                selectedTabResumen.Background = Brushes.Transparent;

            ActualizarDatosDelExcel();

            //ResumenListView.ItemsSource = null;
            //ResumenListView.ItemsSource = DatosCargaExcelRelacion;

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
                MessageBox.Show(ex.Message);
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

                        //Eliminar la relacion con RelacionComponentePersona
                        var listaRelacionEliminar = DatosCargaExcelRelacion.Where(s => s.IDPERSONA == id);
                        foreach (var item in listaRelacionEliminar)
                            ExcelHelper.EliminarEntidad<RelacionComponentePersonaExcel>(RutaFicheroRelacion, item.ID);

                        ExcelHelper.EliminarEntidad<PersonaExcel>(RutaFicheroPersonas, id);

                        ActualizarDatosDelExcel();

                        UsuariosListView.ItemsSource = null;
                        UsuariosListView.ItemsSource = DatosCargaExcelPersonas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                        //Eliminar la relacion con RelacionComponentePersona
                        var listaRelacionEliminar = DatosCargaExcelRelacion.Where(s => s.IDCOMPONENTE == id);
                        foreach (var item in listaRelacionEliminar)                        
                            ExcelHelper.EliminarEntidad<RelacionComponentePersonaExcel>(RutaFicheroRelacion, item.ID);                        

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
            try
            {
                var textBox = sender as TextBox;
                var item = textBox?.DataContext as RelacionComponentePersonaExcel;

                if (item != null && item.Cantidad != null)
                {
                    var selectedItem = cbComponente.SelectedItem as ComponenteExcel;

                    if (selectedItem != null)
                    {
                        item.Porcentaje = item.Cantidad * 100 / selectedItem.Cantidad;
                        ActualizarDatosComponenteEnRelacionComponentePersona();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PorcentajeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                var item = textBox?.DataContext as RelacionComponentePersonaExcel;

                if (item != null && item.Porcentaje != null)
                {
                    var selectedItem = cbComponente.SelectedItem as ComponenteExcel;

                    if (selectedItem != null)
                    {
                        item.Cantidad = (item.Porcentaje / 100) * selectedItem.Cantidad;
                        ActualizarDatosComponenteEnRelacionComponentePersona();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }


        public void cbComponente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = cbComponente.SelectedItem as ComponenteExcel;

                if (selectedItem != null)
                {
                    SelectIndexComponenteCB = cbComponente.SelectedIndex;
                    ActualizarDatosRelacionDelExcel(); //TODO: Se podría mantener los datos que vas modificando (en el listado de Relación) eliminando esta linea.
                                                       //lbCantidadComponente.Content = selectedItem.Cantidad + " €";
                   
                    RelacionListView.ItemsSource = null;
                    RelacionListView.ItemsSource = DatosCargaExcelRelacion.Where(s => s.IDCOMPONENTE == selectedItem.ID);

                    ActualizarDatosComponenteEnRelacionComponentePersona();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void ActualizarDatosComponenteEnRelacionComponentePersona()
        {         
            var selectedItem = cbComponente.SelectedItem as ComponenteExcel;
            if (selectedItem == null) return; 

            double cantidadActual = 0;
            double porcentajeActual = 0;

            var itemsSource = RelacionListView.ItemsSource;
            if (itemsSource is IEnumerable<RelacionComponentePersonaExcel> enumerable)
            {
                var personas = enumerable.Where(s => s.IDCOMPONENTE == selectedItem.ID);

                cantidadActual = personas.Where(d=>d.Cantidad != null).Sum(s => (double)s.Cantidad);
                porcentajeActual = personas.Where(d => d.Porcentaje != null).Sum(s => (double)s.Porcentaje);
            }

            lbCantidadComponente.Content = cantidadActual.ToString("0.##") + "/" +selectedItem.Cantidad + " €";
            lbPorcentajeComponente.Content = porcentajeActual.ToString("0.##") + "/100 %";
        }

        private void CrearRelacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RelacionFormView usuarioFormView = new RelacionFormView(new RelacionComponentePersonaExcel(), this);
                usuarioFormView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }
        }

        private void RepartirFormaEquitativa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RelacionListView.ItemsSource == null)
                    return;
                               
                var selectedItem = cbComponente.SelectedItem as ComponenteExcel;
                if (selectedItem == null) return;

                var itemsSource = RelacionListView.ItemsSource;
                if (itemsSource is IEnumerable<RelacionComponentePersonaExcel> enumerable)
                {
                    //var personas = enumerable.Where(s => s.IDCOMPONENTE == selectedItem.ID);

                    var porcentajeRepartir = 100 / enumerable.Count();

                    if (porcentajeRepartir <= 0) return;

                    foreach ( var item in enumerable)
                    {
                        item.Porcentaje = porcentajeRepartir;
                        item.Cantidad = (item.Porcentaje / 100) * selectedItem.Cantidad;
                        ActualizarDatosComponenteEnRelacionComponentePersona();
                    }
                                           
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;

            }
        }

        private void GuardarDatosModificados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RelacionListView.ItemsSource == null)
                    return;

                var itemsSource = RelacionListView.ItemsSource;
                if (itemsSource is IEnumerable<RelacionComponentePersonaExcel> enumerable)
                {
                    foreach (var item in enumerable)
                        ExcelHelper.ActualizarEntidad<RelacionComponentePersonaExcel>(RutaFicheroRelacion, item);

                    MessageBox.Show("Guardado con éxito");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }           
        }


        #endregion


        #region Configuracion
        private void EliminarTodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar todos los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                foreach (var item in DatosCargaExcelRelacion)
                    ExcelHelper.EliminarEntidad<RelacionComponentePersonaExcel>(RutaFicheroRelacion, item.ID);

                foreach (var item in DatosCargaExcelComponente)
                    ExcelHelper.EliminarEntidad<ComponenteExcel>(RutaFicheroComponentes, item.ID);

                foreach (var item in DatosCargaExcelPersonas)
                    ExcelHelper.EliminarEntidad<PersonaExcel>(RutaFicheroPersonas, item.ID);

                ActualizarDatosDelExcel();

                if (DatosCargaExcelComponente != null && DatosCargaExcelComponente.Count > 0)
                {
                    cbComponente.ItemsSource = DatosCargaExcelComponente;
                    cbComponente.DisplayMemberPath = "Tipo";

                    if (cbComponente.SelectedItem == null)
                        cbComponente.SelectedIndex = SelectIndexComponenteCB;
                }
                else
                {
                    cbComponente.ItemsSource = DatosCargaExcelComponente;
                    cbComponente.DisplayMemberPath = "Tipo";

                    if (cbComponente.SelectedItem == null)
                        cbComponente.SelectedIndex = SelectIndexComponenteCB;
                }

                ListBoxItems.ItemsSource = null;
                RelacionListView.ItemsSource = null;
                lbCantidadComponente.Content = "";
                lbPorcentajeComponente.Content = "";

                UsuariosListView.ItemsSource = null;
                UsuariosListView.ItemsSource = DatosCargaExcelPersonas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
        private void EliminarTodasLasPersonas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar todas las personas?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                foreach (var item in DatosCargaExcelPersonas)
                    ExcelHelper.EliminarEntidad<PersonaExcel>(RutaFicheroPersonas, item.ID);

                ActualizarDatosDelExcel();

                UsuariosListView.ItemsSource = null;
                UsuariosListView.ItemsSource = DatosCargaExcelPersonas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void EliminarTodosLosComponentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar todos los componentes?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                foreach (var item in DatosCargaExcelComponente)
                    ExcelHelper.EliminarEntidad<ComponenteExcel>(RutaFicheroComponentes, item.ID);

                ActualizarDatosDelExcel();

                if (DatosCargaExcelComponente != null && DatosCargaExcelComponente.Count > 0)
                {
                    cbComponente.ItemsSource = DatosCargaExcelComponente;
                    cbComponente.DisplayMemberPath = "Tipo";

                    if (cbComponente.SelectedItem == null)
                        cbComponente.SelectedIndex = SelectIndexComponenteCB;
                }
                else
                {
                    cbComponente.ItemsSource = DatosCargaExcelComponente;
                    cbComponente.DisplayMemberPath = "Tipo";

                    if (cbComponente.SelectedItem == null)
                        cbComponente.SelectedIndex = SelectIndexComponenteCB;
                }

                UsuariosListView.ItemsSource = null;
                UsuariosListView.ItemsSource = DatosCargaExcelPersonas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void EliminarTodosLasRelaciones_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar todas las relaciones?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;

                foreach (var item in DatosCargaExcelRelacion)
                    ExcelHelper.EliminarEntidad<RelacionComponentePersonaExcel>(RutaFicheroRelacion, item.ID);

                ActualizarDatosDelExcel();

                ListBoxItems.ItemsSource = null;
                RelacionListView.ItemsSource = null;
                lbCantidadComponente.Content = "";
                lbPorcentajeComponente.Content = "";

                UsuariosListView.ItemsSource = null;
                UsuariosListView.ItemsSource = DatosCargaExcelPersonas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        #endregion

        //private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    HiddenButton.Focus();
        //}
    }
}
