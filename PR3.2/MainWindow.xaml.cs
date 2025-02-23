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
            // Сброс предыдущего результата
            resultText.Text = string.Empty;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(num1TextBox.Text) ||
                string.IsNullOrWhiteSpace(num2TextBox.Text) ||
                string.IsNullOrWhiteSpace(num3TextBox.Text))
            {
                resultText.Text = "Ошибка: заполните все поля!";
                return;
            }

            // Проверка выбора операции
            if (maxRadioButton.IsChecked != true && minRadioButton.IsChecked != true)
            {
                resultText.Text = "Ошибка: выберите операцию (максимум/минимум)!";
                return;
            }

            // Проверка корректности ввода чисел
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