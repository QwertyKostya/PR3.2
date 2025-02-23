using System;
using System.Globalization;
using System.Windows;

namespace MinMaxCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка корректности ввода
            if (!TryParseNumber(num1TextBox.Text, out double num1) ||
                !TryParseNumber(num2TextBox.Text, out double num2) ||
                !TryParseNumber(num3TextBox.Text, out double num3))
            {
                resultText.Text = "Ошибка: введите корректные числа!";
                return;
            }

            // Вычисление результата
            if (maxRadioButton.IsChecked == true)
            {
                double max = Math.Max(Math.Max(num1, num2), num3);
                resultText.Text = $"Максимум: {max}";
            }
            else
            {
                double min = Math.Min(Math.Min(num1, num2), num3);
                resultText.Text = $"Минимум: {min}";
            }
        }

        // Метод для конвертации строки в число с учётом разных форматов
        private bool TryParseNumber(string input, out double result)
        {
            return double.TryParse(
                input,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result
            );
        }
    }
}