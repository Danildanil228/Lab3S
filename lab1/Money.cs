using System;
using System.Collections.Generic;

namespace MoneyApp
{
    public class Money
    {
        private Dictionary<decimal, int> _denominations;

        public Money()
        {
            _denominations = new Dictionary<decimal, int>
            {
                {0.01m, 0}, {0.05m, 0}, {0.1m, 0}, {0.5m, 0},
                {1m, 0}, {2m, 0}, {5m, 0}, {10m, 0}, {50m, 0},
                {100m, 0}, {500m, 0}, {1000m, 0}, {5000m, 0}
            };
        }

        public Money(Dictionary<decimal, int> denominations)
        {
            _denominations = denominations;
        }

        public void AddMoney(Money money)
        {
            foreach (var kvp in money._denominations)
            {
                _denominations[kvp.Key] += kvp.Value;
            }
        }

        public void SubtractMoney(Money money)
        {
            foreach (var kvp in money._denominations)
            {
                _denominations[kvp.Key] -= kvp.Value;
                if (_denominations[kvp.Key] < 0)
                {
                    throw new InvalidOperationException("Недостаточно средств для вычета.");
                }
            }
        }

        public void DivideBy(decimal divisor)
        {
            foreach (var kvp in _denominations)
            {
                _denominations[kvp.Key] = (int)Math.Round(kvp.Value / divisor);
            }
        }

        public void MultiplyBy(decimal multiplier)
        {
            foreach (var kvp in _denominations)
            {
                _denominations[kvp.Key] = (int)Math.Round(kvp.Value * multiplier);
            }
        }

        public decimal TotalAmount()
        {
            decimal total = 0;
            foreach (var kvp in _denominations)
            {
                total += kvp.Key * kvp.Value;
            }
            return total;
        }

        public int CompareTo(Money other)
        {
            return TotalAmount().CompareTo(other.TotalAmount());
        }

        public override string ToString()
        {
            string result = "";
            foreach (var kvp in _denominations)
            {
                if (kvp.Value > 0)
                {
                    result += $"{kvp.Value}x{kvp.Key} ";
                }
            }
            return result.Trim();
        }
    }
}
