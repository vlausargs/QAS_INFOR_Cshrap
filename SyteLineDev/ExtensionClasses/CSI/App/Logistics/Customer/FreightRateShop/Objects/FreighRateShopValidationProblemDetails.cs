using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IFreighRateShopValidationProblemDetails
    {
        string type { get; }
        string title { get; }
        int status { get; }
        string detail { get; }
        string instance { get; }
        IDictionary<string, string[]> extensions { get; }
        IDictionary<string, string[]> errors { get; }

    }

    public class FreighRateShopValidationProblemDetails : IFreighRateShopValidationProblemDetails {
        public FreighRateShopValidationProblemDetails(
            string type,
            string title,
            int status,
            string detail,
            string instance,
            IDictionary<string, string[]> errors,
            IDictionary<string, string[]> extensions)
        {
            this.detail = detail;
            this.type = type;
            this.title = title;
            this.status = status;
            this.instance = instance;
            this.extensions = extensions;
            this.errors = errors;
        }
        public string type { get; }
        public string title { get; }
        public int status { get; }
        public string detail { get; }
        public string instance { get; }
        public IDictionary<string, string[]> errors { get; }
        public IDictionary<string, string[]> extensions { get; }


    }
}
