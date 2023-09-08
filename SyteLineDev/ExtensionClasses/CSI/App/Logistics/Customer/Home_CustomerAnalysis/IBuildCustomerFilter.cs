using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IBuildCustomerFilter
    {
        string BuildCustomerFilterString(string originalFilterString, IList<object> parms, string property, string oper, string value);
    }
}
