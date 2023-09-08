using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class BuildCustomerFilter : IBuildCustomerFilter
    {
        public string BuildCustomerFilterString(string originalFilterString, IList<object> parms, string property, string oper, string value)
        {
            string filterStringForWhereStatement = originalFilterString.Trim() == string.Empty ? " 1 = 1 " : originalFilterString;
            int index = parms.Count;
            filterStringForWhereStatement += $" AND {property} {oper} {{{index}}} ";
            parms.Add(value);
            return filterStringForWhereStatement;
        }
    }
}
