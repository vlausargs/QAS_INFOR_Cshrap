using System;
using System.Collections.Generic;

namespace CSI.Finance.MTD
{
    public interface IMTDAPIResponseDataProcessor
    {
        void ProcessTokenResponseData(Dictionary<string, string> tokenEndpointDecoded, DateTime currentTime);

        void ProcessRetrieveObligationsResponseData(
            Dictionary<string, List<Dictionary<string, string>>> retrieveObligationResponseDecoded);

        void ProcessSubmitReturnResponseData(string periodKey, Dictionary<string, string> submitVatRetResponseDecoded);

        void ProcessRetrieveLiabilitiesResponseData(string periodKey, Dictionary<string, List<Dictionary<string, object>>> retrieveLiabilitiesResponseDecoded);

        void ProcessRetrievePaymentsResponseData(string periodKey, Dictionary<string, List<Dictionary<string, string>>> retrieveLiabilitiesResponseDecoded);
    }
}