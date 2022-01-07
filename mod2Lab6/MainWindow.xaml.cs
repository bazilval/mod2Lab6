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
using System.Windows.Navigation;
using System.Windows.Shapes;
/*1. Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку 
 * температуру (целое число в диапазоне от -50 до +50), +
 * направление ветра (строка), 
 * скорость ветра (целое число), 
 * наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег. 
 * Можно использовать целочисленное значение, либо создать перечисление enum). 
 * Свойство «температура» преобразовать в свойство зависимости.*/

namespace mod2Lab6
{
    class WeatherControl: DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int) GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WindDirections WindDirection { get; set; }
        public enum WindDirections
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }
        private int windSpeed;
        public int WindSpeed
        {
            set
            {
                if (value > 0)
                {
                    windSpeed = value;
                }
                else
                    windSpeed = 0;
            }
            get => windSpeed;
        }
        public Precipations Precipation { get; set; }
        public enum Precipations
        {
            Sunny,
            Cloudy,
            Rainy,
            Snowy
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int val = (int)baseValue;
            if (val >= -50 && val <= 50)
                return val;
            else
                return 0;
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
