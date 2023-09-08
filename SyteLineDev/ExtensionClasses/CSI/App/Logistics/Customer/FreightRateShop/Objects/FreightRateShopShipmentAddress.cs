
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentAddress
    {
        string AddressLine1 { get; }
        string AddressLine2 { get; }
        string AddressLine3 { get; }
        string City { get; }
        string CountryCode { get; }
        string POBox { get; }
        string PostalCode { get; }
        string StateProvinceCode { get; }
        string StreetNumber { get; }
    }
    public class FreightRateShopShipmentAddress : IFreightRateShopShipmentAddress
    {
        public string POBox { get; }
        public string StreetNumber { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string AddressLine3 { get; }
        public string City { get; }
        public string StateProvinceCode { get; }
        public string PostalCode { get; }
        public string CountryCode { get; }

        public FreightRateShopShipmentAddress
        (
            string pobox,
            string streetnumber,
            string addressline1,
            string addressline2,
            string addressline3,
            string city,
            string stateprovincecode,
            string postalcode,
            string countrycode
        )
        {
            POBox = pobox;
            StreetNumber = streetnumber;
            AddressLine1 = addressline1;
            AddressLine2 = addressline2;
            AddressLine3 = addressline3;
            City = city;
            StateProvinceCode = stateprovincecode;
            PostalCode = postalcode;
            CountryCode = countrycode;
        }
    }
}
