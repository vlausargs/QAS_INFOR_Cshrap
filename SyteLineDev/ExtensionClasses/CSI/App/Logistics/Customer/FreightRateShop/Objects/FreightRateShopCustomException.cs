
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopCustomException
    {
        string Code { get; }
        string Message { get; }
        string Source { get; }
    }
    public class FreightRateShopCustomException : IFreightRateShopCustomException
    {
        public FreightRateShopCustomException(string code, string message, string source)
        {
            Code = code;
            Message = message;
            Source = source;
        }

        public string Code { get; }
        public string Message { get; }
        public string Source { get; }
    }
}
