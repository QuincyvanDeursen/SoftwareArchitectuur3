using SoaApp.Core.Models;

namespace SoaApp.Core.DiscountCalculation
{
    public class SecondTicketFreeDiscount : IDiscount
    {
        public decimal ApplyDiscount(IList<MovieTicket> tickets, decimal totalPrice)
        {
            for (int i = 1; i < tickets.Count; i += 2)
            {
                totalPrice -= tickets[i].GetPrice();
            }
            return totalPrice;
        }
    }
}
