using System;
using System.IO;
using System.Net;
using System.Text;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public class MTDVATAPIs : IMTDVATAPIs
    {
        private readonly ICSIRequester _csiRequester;
        private readonly IFraudPreventionHeadersGenerator _fraudPreventionHeadersGenerator;
        private readonly IMTDAPIFailedMessage _mtdAPIFailedMessage;

        #region constant for this class

        private readonly string CONTENT_TYPE = @"application/json";
        private readonly string POST = @"POST";
        private readonly string GET = @"GET";
        private readonly string ACCEPT = @"application/vnd.hmrc.1.0+json";

        #endregion

        public MTDVATAPIs(
            ICSIRequester csiRequester,
            IFraudPreventionHeadersGenerator fraudPreventionHeadersGenerator,
            IMTDAPIFailedMessage mtdAPIFailedMessage)
        {
            _csiRequester = csiRequester;
            _fraudPreventionHeadersGenerator = fraudPreventionHeadersGenerator;
            _mtdAPIFailedMessage = mtdAPIFailedMessage;
        }

        public ICSIWebResponse RetrieveLiabilities(
            string apiUrl,
            string accessToken,
            string vrn,
            string startDate,
            string endDate,
            bool isWeb,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses)
        {
            try
            {
                var getLiabilities =
                    $@"{apiUrl}/organisations/vat/{vrn}/liabilities?from={startDate}&to={endDate}";

                // sends the request
                var getLiabilitiesRequest = _csiRequester.Create(getLiabilities, GET, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(getLiabilitiesRequest, isWeb, accessToken, deviceId,
                    localIps, localIpsTimestamp, publicIp,
                    publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(getLiabilitiesRequest, string.Empty);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }

        public ICSIWebResponse RetrieveObligations(
            string apiUrl,
            string accessToken,
            string vrn,
            string startDate,
            string endDate,
            bool isWeb,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses,
            string status)

        {
            try
            {
                var retrieveObligation = status != "O" & status != "F"
                    ? $@"{apiUrl}/organisations/vat/{vrn}/obligations?from={startDate}&to={endDate}"
                    : $@"{apiUrl}/organisations/vat/{vrn}/obligations?status={status}&from={startDate}&to={endDate}";


                // sends the request
                var retrieveObligationRequest = _csiRequester.Create(retrieveObligation, GET, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(retrieveObligationRequest, isWeb, accessToken, deviceId,
                    localIps, localIpsTimestamp,
                    publicIp, publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(retrieveObligationRequest, string.Empty);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }

        public ICSIWebResponse SubmitReturn(
            string apiUrl,
            string accessToken,
            string vrn,
            bool isWeb,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses,
            string requestBody)
        {
            try
            {
                var submitReturn =
                    $@"{apiUrl}/organisations/vat/{vrn}/returns";

                // sends the request
                var submitReturnRequest = _csiRequester.Create(submitReturn, POST, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(submitReturnRequest, isWeb, accessToken, deviceId, localIps,
                    localIpsTimestamp,
                    publicIp, publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(submitReturnRequest, requestBody);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }

        public ICSIWebResponse RetrievePayments(
            string apiUrl,
            string accessToken,
            string vrn,
            string startDate,
            string endDate,
            bool isWeb,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses)

        {
            try
            {
                var getPayments =
                    $@"{apiUrl}/organisations/vat/{vrn}/payments?from={startDate}&to={endDate}";

                // sends the request
                var submitReturnRequest = _csiRequester.Create(getPayments, GET, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(submitReturnRequest, isWeb, accessToken, deviceId, localIps,
                    localIpsTimestamp,
                    publicIp, publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(submitReturnRequest, string.Empty);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }

        public ICSIWebResponse ValidateFraudPreventionHeaders(
            string apiUrl,
            string accessToken,
            string vrn,
            string startDate,
            string endDate,
            bool isWeb,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string userIds,
            string windowSize,
            string licenseIds,
            string productName,
            string vendorVersion,
            string doNotTrack,
            string userAgent,
            string plugins,
            string macAddresses)
        {
            try
            {
                var validationFeedback = $@"{apiUrl}/test/fraud-prevention-headers/validate";

                // sends the request
                var validationFeedbackRequest = _csiRequester.Create(validationFeedback, GET, CONTENT_TYPE, ACCEPT);
                _fraudPreventionHeadersGenerator.GenerateFraudPreventionHeaders(validationFeedbackRequest, isWeb, accessToken, deviceId,
                    localIps, localIpsTimestamp,
                    publicIp, publicIpTimestamp, publicPort, screens, timeZone, userIds, windowSize, licenseIds, productName, vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);
                return _csiRequester.Call(validationFeedbackRequest, string.Empty);
            }
            catch (WebException e)
            {
                var errorMassage = _mtdAPIFailedMessage.GetCallFailedMassage(e);
                throw new Exception($"{errorMassage["code"]}{errorMassage["message"]}", e);
            }
        }
    }
}