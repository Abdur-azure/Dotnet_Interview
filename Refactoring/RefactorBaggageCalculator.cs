using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class RefactorBaggageCalculator
    {
        private const decimal FirstBagFee = 40M;
        private const decimal CarryOnFee = 30M;
        private const decimal ExtraBagFee = 50M;

        public decimal HolidayFeePercent { get; set; } = 0.1m;

        public decimal CalculatePrice(int bags, int carryOn, int passengers, bool isHoliday)
        {
            decimal total = 0;

            if (carryOn > 0)
            {
                decimal v = carryOn * CarryOnFee;
                Console.WriteLine($"Carry-on: {v}");
                total += v;
            }

            if (bags > 0)
            {
                decimal bagFee = ApplyCheckedBagFee(bags, passengers);
                Console.WriteLine($"Checked: {bagFee}");
                total += bagFee;
            }

            if (isHoliday)
            {
                decimal holidayFee = total * HolidayFeePercent;
                Console.WriteLine("Holiday Fee: " + holidayFee);
                total += holidayFee;
            }

            return total;
        }

        private static decimal ApplyCheckedBagFee(int bags, int passengers)
        {
            if (bags <= passengers)
            {
                decimal firstBagFee = bags * FirstBagFee;
                return firstBagFee;
            }

            else
            {
                decimal firstBagFee = passengers * FirstBagFee;
                decimal extraBagFee = (bags - passengers) * ExtraBagFee;
                decimal checkedFee = firstBagFee + extraBagFee;
                return checkedFee;
            }
        }

        private decimal CalculatePriceFlat(int numBags)
        {
            decimal total = 0;

            return 100M;

            return numBags * 50M;
        }

    }
}
