using System;

namespace CSI.Logistics.Customer
{
    public class ShipmentOrderIdGenerator : IShipmentOrderIdGenerator
    {
        public T GenerateShipmentID<T>(string input, string delimiter)
        {
            string retString = string.Empty;
            delimiter = (string.IsNullOrEmpty(delimiter) == true) ? "" : delimiter;

            if (string.IsNullOrEmpty(input) == false)
            {
                int startIndex = input.IndexOf(delimiter) + delimiter.Length;
                int endLength = 0;

                string subInput = input.Substring(startIndex);
                int subIndex = subInput.IndexOf(delimiter);
                endLength = (subIndex <= 0) ? (input.Length - startIndex) : subIndex;

                retString = input.Substring(startIndex, endLength);
            }

            return (T)Convert.ChangeType(retString, typeof(T));
        }
    }
}
