 
namespace MabnaDBTest.Domain.DTOs.Instrument
{
    public class GetAllTradeResponse
    { 
        public string Name { get; set; }
        public DateTime DateEn { get; set; }
        public Decimal Open { get; set; }
        public Decimal High { get; set; }
        public Decimal Low { get; set; }
        public Decimal Close { get; set; }
    }
}
