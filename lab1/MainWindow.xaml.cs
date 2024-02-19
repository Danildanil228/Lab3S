using System;
using System.Windows;

namespace MoneyApp
{
    public partial class MainWindow : Window
    {
        private Money currentMoney;

        public MainWindow()
        {
            InitializeComponent();
            currentMoney = new Money();
            UpdateMoneyDisplay();
        }

        private void UpdateMoneyDisplay()
        {
            txtMoney.Text = currentMoney.ToString();
        }

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtAddAmount.Text, out decimal amount))
            {
                currentMoney.AddMoney(new Money(new Dictionary<decimal, int> { { amount, 1 } }));
                UpdateMoneyDisplay();
            }
            else
            {
                MessageBox.Show("Неверный ввод для добавления денег.");
            }
        }

        private void SubtractMoney_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtSubtractAmount.Text, out decimal amount))
            {
                var toSubtract = new Money(new Dictionary<decimal, int> { { amount, 1 } });
                try
                {
                    currentMoney.SubtractMoney(toSubtract);
                    UpdateMoneyDisplay();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный ввод для вычитания суммы.");
            }
        }

        private void DivideMoney_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtDivideBy.Text, out decimal divisor) && divisor != 0)
            {
                currentMoney.DivideBy(divisor);
                UpdateMoneyDisplay();
            }
            else
            {
                MessageBox.Show("Неверный ввод для деления суммы.");
            }
        }

        private void MultiplyMoney_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtMultiplyBy.Text, out decimal multiplier))
            {
                currentMoney.MultiplyBy(multiplier);
                UpdateMoneyDisplay();
            }
            else
            {
                MessageBox.Show("Неверный ввод для умножения суммы.");
            }
        }

        private void CompareMoney_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtCompareAmount.Text, out decimal compareAmount))
            {
                var compareMoney = new Money(new Dictionary<decimal, int> { { compareAmount, 1 } });
                int comparisonResult = currentMoney.CompareTo(compareMoney);
                if (comparisonResult > 0)
                {
                    txtComparisonResult.Text = "Текущая сумма больше.";
                }
                else if (comparisonResult < 0)
                {
                    txtComparisonResult.Text = "Текущая сумма меньше.";
                }
                else
                {
                    txtComparisonResult.Text = "Текущая сумма равны.";
                }
            }
            else
            {
                MessageBox.Show("Неверный ввод для сравнения сумм.");
            }
        }
    }
}
