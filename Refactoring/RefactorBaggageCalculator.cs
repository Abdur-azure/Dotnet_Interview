using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class RefactorBaggageCalculator
    {
        public decimal HolidayFeePercent { get; set; } = 0.1m;

        public decimal CalculatePrice(int bags, int carryOn, int passengers, DateTime travelTime)
        {
            decimal total = 0;

            if (carryOn > 0)
            {
                Console.WriteLine($"Carry-on: {carryOn * 30M}");
                total += carryOn * 30M;
            }

            if (bags > 0)
            {
                if (bags <= passengers)
                {
                    Console.WriteLine($"Carry-on: {bags * 40M}");
                    total += bags * 40M;
                }

                else
                {
                    decimal checkedFee = (passengers * 40M) + ((bags - passengers) * 50M);

                    Console.WriteLine($"Checked: {checkedFee}");
                    total += checkedFee;
                }
            }

            if (travelTime.Month >= 11 || travelTime.Month <= 2)
            {
                Console.WriteLine("Holiday Fee: " + (total * HolidayFeePercent));
                total += total * HolidayFeePercent;
            }

            return total;
        }

        private decimal CalculatePriceFlat(int numBags)
        {
            decimal total = 0;

            return 100M;

            return numBags * 50M;
        }

    }
}
