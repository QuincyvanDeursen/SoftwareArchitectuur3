
using Newtonsoft.Json;
using SoaApp.Core.DiscountCalculation;
using SoaApp.Core.ExportHandler;

namespace SoaApp.Core.Models
{
    public class Order
    {
        [JsonProperty]
        private int _orderNr;
        [JsonProperty]
        private bool _isStudentOrder;

        [JsonProperty]
        private IList<MovieTicket> _movieTickets = new List<MovieTicket>();

        private GroupDiscount _groupDiscount;
        private PremiumDiscount _premiumDiscount;
        private SecondTicketFreeDiscount _secondTicketFreeDiscount;

        private JSONExport _jsonExport;
        private PlainTextExport _plainTextExport;

        private Discount _discount;
        private Export _export;

        public Order(int orderNr, bool isStudentOrder)
        {

            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _discount = new Discount();
            _export = new Export();

            _groupDiscount = new GroupDiscount(10);
            _premiumDiscount = new PremiumDiscount(1);
            _secondTicketFreeDiscount = new SecondTicketFreeDiscount();

            _jsonExport = new JSONExport();
            _plainTextExport = new PlainTextExport();
        }

        public int GetOrder()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _movieTickets.Add(ticket);
        }


        public decimal CalculatePrice()
        {
            var total = 0M;
            DateTime screeningDate = _movieTickets[0].GetMovieScreeningDate();

            //calculating total price before discounts
            for (int i = 0; i < _movieTickets.Count; i++)
            {
                MovieTicket ticket = _movieTickets[i];
                total += ticket.GetPrice();
                total += ticket.IsPremiumTicket() ? 3 : 0;
            }

            // Premium discount if studentOrder.
            if (_isStudentOrder)
            {
                _discount.SetDiscount(_premiumDiscount);
                total = _discount.GetNewTotalPrice(_movieTickets, total);
            }

            // free tickets for students or weekday (monday to thusrsday)
            var isWeekend = screeningDate.DayOfWeek == DayOfWeek.Friday || screeningDate.DayOfWeek == DayOfWeek.Saturday || screeningDate.DayOfWeek == DayOfWeek.Sunday;
            if (_isStudentOrder || !isWeekend)
            {
                _discount.SetDiscount(_secondTicketFreeDiscount);
                total = _discount.GetNewTotalPrice(_movieTickets, total);
            }

            // Full price for non-students or 10%  discount when with 6 or more people.
            if (isWeekend && !_isStudentOrder)
            {
                _discount.SetDiscount(_groupDiscount);
                total = _discount.GetNewTotalPrice(_movieTickets, total);
            }

            return total;
        }

        public IList<MovieTicket> GetMovieTickets()
        {
            return _movieTickets;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            //Choose export format
            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    _export.SetExport(_jsonExport);
                    _export.ExportToFile(this); // fill with order class
                    break;
                case TicketExportFormat.PLAINTEXT:
                    _export.SetExport(_plainTextExport);
                    _export.ExportToFile(this); // fill with order class
                    break;
                default:
                    throw new ArgumentException("No valid format");
            }
        }
    }
}
