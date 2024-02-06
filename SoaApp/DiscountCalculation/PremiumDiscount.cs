using SoaApp.Core.Models;

namespace SoaApp.Core.DiscountCalculation
{
    public class PremiumDiscount : IDiscount
    {
        private decimal _premiumDiscountValue;
        public PremiumDiscount( decimal premiumDiscountValue)
        {
           SetPremiumDiscount(premiumDiscountValue);
        }
        public decimal ApplyDiscount(IList<MovieTicket> tickets, decimal totalPrice)
        {
            foreach (var ticket in tickets)
            {
                if (ticket.IsPremiumTicket())
                {
                    // Korting voor premium tickets (bijvoorbeeld 1 euro korting per premium ticket)
                    totalPrice -= _premiumDiscountValue;
                }
            }
            return totalPrice;
        }


        public void SetPremiumDiscount(decimal premiumDiscount)
        {
            _premiumDiscountValue = premiumDiscount;
        }

    }
}
