using SoaApp.Core.Models;

namespace SoaApp.Core.DiscountCalculation
{
    public interface IDiscount
    {

        public decimal ApplyDiscount(IList<MovieTicket> tickets, decimal totalPrice);
    }
}
