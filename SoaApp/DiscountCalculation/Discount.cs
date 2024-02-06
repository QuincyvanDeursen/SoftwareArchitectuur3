using SoaApp.Core.Models;
using System.Collections.Generic;

namespace SoaApp.Core.DiscountCalculation
{
    public class Discount
    {
        private IDiscount _discount;

        public decimal GetNewTotalPrice(IList<MovieTicket> tickets, decimal totalPrice)
        {
            return _discount.ApplyDiscount(tickets, totalPrice);
        }

        public void SetDiscount(IDiscount discount)
        {
             _discount = discount;
        }
    }
}
