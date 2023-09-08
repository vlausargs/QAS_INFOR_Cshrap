using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Finance.MTD
{
    public class MTDAPIResponseDataProcessor : IMTDAPIResponseDataProcessor
    {
        private readonly IMTDBusinessHandlerCRUD _mtdBusinessHandlerCRUD;

        #region constant for this class

        private const string READ_SCOPE = @"read:vat";

        #endregion

        public MTDAPIResponseDataProcessor(IMTDBusinessHandlerCRUD mtdBusinessHandlerCRUD)
        {
            _mtdBusinessHandlerCRUD = mtdBusinessHandlerCRUD;
        }

        public void ProcessTokenResponseData(
            Dictionary<string, string> tokenEndpointDecoded,
            DateTime currentTime)
        {
            var accessToken = tokenEndpointDecoded["access_token"];
            var newRefreshToken = tokenEndpointDecoded["refresh_token"];
            var expiresIn = tokenEndpointDecoded["expires_in"];
            var tokenScope = tokenEndpointDecoded["scope"];
            var newExpiresIn = currentTime.AddSeconds(Convert.ToDouble(expiresIn));
            var refreshExpires = currentTime.AddMonths(18);

            if (tokenScope == READ_SCOPE)
            {
                _mtdBusinessHandlerCRUD.UpdateTaxparmsReadtoken(accessToken, newRefreshToken, newExpiresIn, refreshExpires);
            }
            else
            {
                _mtdBusinessHandlerCRUD.UpdateTaxparmsWritetoken(accessToken, newRefreshToken, newExpiresIn, refreshExpires);
            }
        }

        public void ProcessRetrieveObligationsResponseData(
            Dictionary<string, List<Dictionary<string, string>>> retrieveObligationResponseDecoded)
        {
            foreach (var obligation in retrieveObligationResponseDecoded["obligations"])
            {
                var start = DateTime.Parse(obligation["start"]);
                var end = DateTime.Parse(obligation["end"]);
                var due = DateTime.Parse(obligation["due"]);
                var periodKey = obligation["periodKey"];
                var status = obligation["status"];
                var received = !obligation.ContainsKey("received")
                    ? (DateTime?) null
                    : DateTime.Parse(obligation["received"]); // Optional

                // check if periodKey existed in table
                if (!_mtdBusinessHandlerCRUD.SelectObligationExist(periodKey))
                {
                    // Insert
                    _mtdBusinessHandlerCRUD.InsertVatObligation(start, end, due, status, periodKey, received);
                }
                else
                {
                    // Update
                    _mtdBusinessHandlerCRUD.UpdateVatObligation(periodKey, start, end, due, status, received);
                }
            }
        }

        public void ProcessSubmitReturnResponseData(string periodKey, Dictionary<string, string> submitVatRetResponseDecoded)
        {
            var processingDate = DateTime.Parse(submitVatRetResponseDecoded["processingDate"]);
            var formBundleNumber = submitVatRetResponseDecoded["formBundleNumber"];
            var paymentIndicator = submitVatRetResponseDecoded.ContainsKey("paymentIndicator")
                ? submitVatRetResponseDecoded["paymentIndicator"]
                : string.Empty; // Optional
            var chargeRefNumber = submitVatRetResponseDecoded.ContainsKey("chargeRefNumber")
                ? submitVatRetResponseDecoded["chargeRefNumber"]
                : string.Empty; // Optional

            _mtdBusinessHandlerCRUD.UpdateVatObligationSubmitReturn(periodKey, processingDate, formBundleNumber, paymentIndicator,
                chargeRefNumber);
        }

        public void ProcessRetrieveLiabilitiesResponseData(
            string periodKey,
            Dictionary<string, List<Dictionary<string, object>>> retrieveLiabilitiesResponseDecoded)
        {
            var vatType = retrieveLiabilitiesResponseDecoded["liabilities"][0]["type"].ToString();
            var originalAmount = retrieveLiabilitiesResponseDecoded["liabilities"][0]["originalAmount"].ToString();
            var outstandingAmount = retrieveLiabilitiesResponseDecoded["liabilities"][0].ContainsKey("outstandingAmount")
                ? retrieveLiabilitiesResponseDecoded["liabilities"][0]["outstandingAmount"].ToString()
                : "0"; // Optional
            var dueDate = retrieveLiabilitiesResponseDecoded["liabilities"][0].ContainsKey("due")
                ? retrieveLiabilitiesResponseDecoded["liabilities"][0]["due"].ToString()
                : null; // Optional

            _mtdBusinessHandlerCRUD.UpdateVatObligationLiabilities(periodKey, vatType, originalAmount, outstandingAmount,
                string.IsNullOrWhiteSpace(dueDate) ? (DateTime?) null : DateTime.Parse(dueDate));
        }

        public void ProcessRetrievePaymentsResponseData(
            string periodKey,
            Dictionary<string, List<Dictionary<string, string>>> retrieveLiabilitiesResponseDecoded)
        {
            // received is Optional
            foreach (var payment in retrieveLiabilitiesResponseDecoded["payments"].Where(payment =>
                !_mtdBusinessHandlerCRUD.SelectObligationExistPayment(periodKey, payment["amount"],
                    payment.ContainsKey("received") ? DateTime.Parse(payment["received"]) : (DateTime?) null)))
            {
                var seq = _mtdBusinessHandlerCRUD.SelectObligationPaymentCount(periodKey);
                _mtdBusinessHandlerCRUD.InsertVatObligationPayment(periodKey, payment["amount"],
                    payment.ContainsKey("received") ? payment["received"] : string.Empty, seq);
            }
        }
    }
}