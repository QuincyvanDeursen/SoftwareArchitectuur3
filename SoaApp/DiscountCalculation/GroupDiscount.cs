using SoaApp.Core.Models;

namespace SoaApp.Core.DiscountCalculation
{
    public class GroupDiscount : IDiscount
    {

        private int _discountPercentage;

        public GroupDiscount(int discountPercentage)
        {
            SetDiscountPercentage(discountPercentage);
        }

        public decimal ApplyDiscount(IList<MovieTicket> tickets, decimal totalPrice)
        {
            // Groepskorting (bijvoorbeeld 10% korting bij 6 of meer tickets)
            if (tickets.Count >= 6)
            {
                var discountPercentage = _discountPercentage / 100m;
                totalPrice *= 1-discountPercentage;
            }
            return totalPrice;
        }

        public void SetDiscountPercentage(int discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }
    }
}
