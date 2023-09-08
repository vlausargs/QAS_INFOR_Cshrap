using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreighRateShopProblemDetails
    {
        string type { get; }
        string title { get; }
        int status { get; }
        string detail { get; }
        string instance { get; }
        IDictionary<string, string[]> extensions { get; }
    }
    public class FreighRateShopProblemDetails: IFreighRateShopProblemDetails
    {
        public FreighRateShopProblemDetails(string type, string title, int status, string detail, string instance, IDictionary<string, string[]> extensions)
        {
            this.type = type;
            this.title = title;
            this.status = status;
            this.detail = detail;
            this.instance = instance;
            this.extensions = extensions;
        }

        public string type { get; }
        public string title { get; }
        public int status { get; }
        public string detail { get; }
        public string instance { get; }
        public IDictionary<string, string[]> extensions { get; }
    }
}
