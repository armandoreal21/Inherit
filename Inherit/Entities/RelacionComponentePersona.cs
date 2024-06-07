using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit.Entities
{
    public class RelacionComponentePersonaExcel : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int IDCOMPONENTE { get; set; }
        public int IDPERSONA { get; set; }

        private double? _porcentaje;
        private double? _cantidad;

        public event PropertyChangedEventHandler PropertyChanged;

        public double? Porcentaje
        {
            get => _porcentaje;
            set
            {
                if (_porcentaje != value)
                {
                    _porcentaje = value;
                    OnPropertyChanged(nameof(Porcentaje));
                    UpdateCantidad();
                }
            }
        }

        public double? Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateCantidad()
        {
            if (Porcentaje.HasValue && SelectedComponente?.Cantidad.HasValue == true)
            {
                Cantidad = (Porcentaje.Value / 100) * SelectedComponente.Cantidad.Value;
            }
        }

        public ComponenteExcel SelectedComponente { get; set; } // Puedes enlazar esta propiedad también desde la vista


        public string? NombreComponente { get; set; }
        public string? NombrePersona { get; set; }
    }
}
