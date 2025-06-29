using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Subway.Models;
using Subway.Models.Decorator;
using Subway.Models.Sandwiches;

namespace Subway.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Evento para notificar cambios en propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Propiedades observables
        private ISandwich _sandwichActual;
        public ISandwich SandwichActual
        {
            get => _sandwichActual;
            set
            {
                _sandwichActual = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DescripcionActual));
                OnPropertyChanged(nameof(PrecioActual));
            }
        }

        private string tamanioSeleccionado = "15";
        public string TamanioSeleccionado
        {
            get => tamanioSeleccionado;
            set { tamanioSeleccionado = value; OnPropertyChanged(); }
        }

        // NUEVO: Propiedad para el tipo de sandwich seleccionado
        private TipoSandwich _selectedTipoSandwich;
        public TipoSandwich SelectedTipoSandwich
        {
            get => _selectedTipoSandwich;
            set
            {
                _selectedTipoSandwich = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISandwich> OrdenActual { get; } = new ObservableCollection<ISandwich>();
        public ObservableCollection<TipoSandwich> TiposSandwich { get; } = new ObservableCollection<TipoSandwich>();
        public ObservableCollection<IngredienteDecorador> IngredientesDisponibles { get; } = new ObservableCollection<IngredienteDecorador>();
        public ObservableCollection<string> TamaniosDisponibles { get; } = new ObservableCollection<string> { "15", "30" };


        public string DescripcionActual => SandwichActual?.Descripcion ?? "Seleccione un sándwich";
        public string PrecioActual => SandwichActual != null ? $"${SandwichActual.Precio:N2}" : "$0.00";
        public string TotalOrden => $"Total: ${OrdenActual.Sum(s => s.Precio):N2}";

        // Comandos
        public ICommand CrearSandwichCommand { get; }
        public ICommand AgregarIngredienteCommand { get; }
        public ICommand AgregarALaOrdenCommand { get; }
        public ICommand LimpiarOrdenCommand { get; }

        public MainViewModel()
        {
            InicializarDatos();

            // Configurar comandos
            CrearSandwichCommand = new RelayCommand(CrearSandwich);
            AgregarIngredienteCommand = new RelayCommand(AgregarIngrediente);
            AgregarALaOrdenCommand = new RelayCommand(AgregarALaOrden, PuedeAgregarALaOrden);
            LimpiarOrdenCommand = new RelayCommand(LimpiarOrden);
        }

        private void InicializarDatos()
        {
            // Tipos de sándwich base
            TiposSandwich.Add(new TipoSandwich { Nombre = "Pavo", Tipo = "Pavo" });
            TiposSandwich.Add(new TipoSandwich { Nombre = "Italiano", Tipo = "Italiano" });
            TiposSandwich.Add(new TipoSandwich { Nombre = "Beef", Tipo = "Beef" });
            TiposSandwich.Add(new TipoSandwich { Nombre = "Veggie", Tipo = "Veggie" });
            TiposSandwich.Add(new TipoSandwich { Nombre = "Atún", Tipo = "Atún" });
            TiposSandwich.Add(new TipoSandwich { Nombre = "Pollo", Tipo = "Pollo" });

            // Ingredientes adicionales
            IngredientesDisponibles.Add(new IngredienteDecorador { Nombre = "Aguacate" });
            IngredientesDisponibles.Add(new IngredienteDecorador { Nombre = "Doble Proteína" });
            IngredientesDisponibles.Add(new IngredienteDecorador { Nombre = "Hongos" });
            IngredientesDisponibles.Add(new IngredienteDecorador { Nombre = "Refresco" });
            IngredientesDisponibles.Add(new IngredienteDecorador { Nombre = "Sopa" });
        }

        private void CrearSandwich(object parametro)
        {
            // Usar el tipo seleccionado si no se pasa parámetro
            string tipoSandwich = parametro as string ?? SelectedTipoSandwich?.Tipo;
            if (!string.IsNullOrEmpty(tipoSandwich) &&
                !string.IsNullOrEmpty(TamanioSeleccionado))
            {
                SandwichActual = tipoSandwich switch
                {
                    "Pavo" => new SandwichPavo(TamanioSeleccionado),
                    "Italiano" => new SandwichItaliano(TamanioSeleccionado),
                    "Beef" => new SandwichBeef(TamanioSeleccionado),
                    "Veggie" => new SandwichVeggie(TamanioSeleccionado),
                    "Atún" => new SandwichAtún(TamanioSeleccionado),
                    "Pollo" => new SandwichPollo(TamanioSeleccionado),

                };

                // Aplicar ingredientes seleccionados
                foreach (var ingrediente in IngredientesDisponibles.Where(i => i.EstaSeleccionado))
                {
                    AgregarIngrediente(ingrediente.Nombre);
                }
            }
            else
            {
               MessageBox.Show("Seleccione un tamaño válido.");
            }
        }


        private void AgregarIngrediente(object parametro)
        {
            if (SandwichActual == null) return;

            if (parametro is IngredienteDecorador ingrediente && ingrediente.EstaSeleccionado)
            {
                SandwichActual = ingrediente.Nombre switch
                {
                    "Aguacate" => new AguacateDecorator(SandwichActual),
                    "Doble Proteína" => new DobleProteinaDecorator(SandwichActual),
                    "Hongos" => new HongosDecorator(SandwichActual),
                    "Refresco" => new RefrescoDecorator(SandwichActual),
                    "Sopa" => new SopaDecorator(SandwichActual),
                    _ => SandwichActual
                };
            }
            else if (parametro is string nombreIngrediente)
            {
                SandwichActual = nombreIngrediente switch
                {
                    "Aguacate" => new AguacateDecorator(SandwichActual),
                    "Doble Proteína" => new DobleProteinaDecorator(SandwichActual),
                    "Hongos" => new HongosDecorator(SandwichActual),
                    "Refresco" => new RefrescoDecorator(SandwichActual),
                    "Sopa" => new SopaDecorator(SandwichActual),
                    _ => SandwichActual
                };
            }
        }

        private void AgregarALaOrden(object parametro)
        {
            if (SandwichActual != null)
            {
                OrdenActual.Add(SandwichActual);
                SandwichActual = null;

                // Resetear selecciones
                foreach (var ingrediente in IngredientesDisponibles)
                {
                    ingrediente.EstaSeleccionado = false;
                }

                OnPropertyChanged(nameof(TotalOrden));
            }
        }

        private bool PuedeAgregarALaOrden(object parametro)
        {
            return SandwichActual != null;
        }

        private void LimpiarOrden(object parametro)
        {
            OrdenActual.Clear();
            OnPropertyChanged(nameof(TotalOrden));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TipoSandwich : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        private string _tipo;
        public string Tipo
        {
            get => _tipo;
            set
            {
                _tipo = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class IngredienteDecorador : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        private bool _estaSeleccionado;
        public bool EstaSeleccionado
        {
            get => _estaSeleccionado;
            set
            {
                _estaSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
