using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using CSI.Data;
using CSI.Serializer;

namespace CSI.Finance.MTD
{
    public class MTDBusinessHandler : IMTDBusinessHandler
    {
        private readonly ISerializer _serializer;
        private readonly IMTDVATAPIs _mtdVatApis;
        private readonly IMTDOAuth _mtdOAuth;
        private readonly IMTDBusinessHandlerCRUD _mtdBusinessHandlerCRUD;
        private readonly IMTDAPIResponseDataProcessor _mtdAPIResponseDataProcessor;
        private readonly IMsgApp _iMsgApp;

        public MTDBusinessHandler(
            ISerializer serializer,
            IMTDVATAPIs mtdVatApis,
            IMTDOAuth mtdOAuth,
            IMTDBusinessHandlerCRUD mtdBusinessHandlerCRUD,
            IMTDAPIResponseDataProcessor mtdAPIResponseDataProcessor,
            IMsgApp iMsgApp)
        {
            _serializer = serializer;
            _mtdBusinessHandlerCRUD = mtdBusinessHandlerCRUD;
            _mtdAPIResponseDataProcessor = mtdAPIResponseDataProcessor;
            _iMsgApp = iMsgApp;
            _mtdOAuth = mtdOAuth;
            _mtdVatApis = mtdVatApis;
        }

        public (int returnCode, string message) PerformCodeExchange(
            string doNotTrack,
            string clientConnectMethod,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string code,
            string scope,
            string formName,
            string license,
            string userId,
            string clientVersion)
        {
            try
            {
                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    string.Empty,
                    string.Empty,
                    userId,
                    true,
                    true,
                    clientVersion);

                var codeExchangeResponse = _mtdOAuth.ExchangeAuthorizationCodeForAccessToken(backendParams.apiUrl, backendParams.isWeb,
                    deviceId, backendParams.localIps, localIpsTimestamp, publicIp, publicIpTimestamp, publicPort, screens, timeZone,
                    backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName, backendParams.vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses, code, backendParams.clientId, backendParams.secretKey, scope,
                    backendParams.redirectUri);


                using (var codeExchangeResponseReader = new StreamReader(
                    codeExchangeResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                        "access_token": "a9e9798547e275f04a7382e43a227304",
                        "refresh_token": "c180f3005893b7ed17d276135c4a10fe",
                        "expires_in": 14400,
                        "scope": "read:vat",
                        "token_type": "bearer"
                    }*/

                    #endregion

                    // Read response body
                    var codeExchangeResponseResponseText = codeExchangeResponseReader.ReadToEnd();
                    var tokenEndpointDecoded = _serializer.Deserialize<Dictionary<string, string>>(codeExchangeResponseResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessTokenResponseData(tokenEndpointDecoded, DateTime.Now);

                    // Return Msg
                    return (0, "");
                }
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) RefreshToken(
            string refreshToken,
            string doNotTrack,
            string clientConnectMethod,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string formName,
            string license,
            string userId,
            string clientVersion)
        {
            try
            {
                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    string.Empty,
                    string.Empty,
                    userId,
                    true,
                    true,
                    clientVersion);

                var refreshTokenResponse = _mtdOAuth.RefreshToken(backendParams.apiUrl, backendParams.isWeb, deviceId, localIps,
                    localIpsTimestamp, publicIp, publicIpTimestamp, publicPort, screens, timeZone, backendParams.userIds, windowSize,
                    backendParams.licenseIds, backendParams.productName, backendParams.vendorVersion, doNotTrack, userAgent, plugins,
                    macAddresses, backendParams.clientId, backendParams.secretKey, refreshToken);

                using (var refreshTokenResponseReader = new StreamReader(
                    refreshTokenResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                        "access_token": "a9e9798547e275f04a7382e43a227304",
                        "refresh_token": "c180f3005893b7ed17d276135c4a10fe",
                        "expires_in": 14400,
                        "scope": "read:vat",
                        "token_type": "bearer"
                    }*/

                    #endregion:

                    // Read response body
                    var refreshTokenResponseText = refreshTokenResponseReader.ReadToEnd();
                    var tokenEndpointDecoded = _serializer.Deserialize<Dictionary<string, string>>(refreshTokenResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessTokenResponseData(tokenEndpointDecoded, DateTime.Now);

                    // Return Msg
                    return (0, "");
                }
            }
            catch (Exception e)
            {
                // Clear refresh expired datetime if it has refresh token invalid error
                if (e.Message.Contains("refresh_token is invalid"))
                    _mtdBusinessHandlerCRUD.UpdateTaxparmsRefreshTokenExpirationDate(null, null);
                throw;
            }
        }

        public (int returnCode, string message) SubmitVat(
            string doNotTrack,
            string clientConnectMethod,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string periodKey,
            string formName,
            string license,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get VATReturn by periodKey

                var (vatDueSales, vatDueAcquisitions, totalVatDue, vatReclaimedCurrPeriod, netVatDue, totalValueSalesExVat,
                        totalValuePurchasesExVat, totalValueGoodsSuppliedExVat, totalAcquisitionsExVat, final) =
                    _mtdBusinessHandlerCRUD.SelectVTAReturn(periodKey);

                var vatReturn = new Dictionary<string, object>
                {
                    {"periodKey", periodKey},
                    {"vatDueSales", vatDueSales},
                    {"vatDueAcquisitions", vatDueAcquisitions},
                    {"totalVatDue", totalVatDue},
                    {"vatReclaimedCurrPeriod", vatReclaimedCurrPeriod},
                    {"netVatDue", netVatDue},
                    {"totalValueSalesExVAT", totalValueSalesExVat},
                    {"totalValuePurchasesExVAT", totalValueGoodsSuppliedExVat},
                    {"totalValueGoodsSuppliedExVAT", totalValuePurchasesExVat},
                    {"totalAcquisitionsExVAT", totalAcquisitionsExVat},
                    {"finalised", final}
                };

                var requestBody = _serializer.Serialize(vatReturn);

                #endregion

                #region Get Backend Params and use them with Front-end Params to Call API Post VATReturn

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    string.Empty,
                    string.Empty,
                    userId,
                    false,
                    false,
                    clientVersion);


                // Call API
                var submitVatResponse = _mtdVatApis.SubmitReturn(backendParams.apiUrl, backendParams.accessToken, backendParams.vrn,
                    backendParams.isWeb, deviceId, backendParams.localIps, localIpsTimestamp, publicIp, publicIpTimestamp, publicPort,
                    screens, timeZone, backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName,
                    backendParams.vendorVersion, doNotTrack, userAgent, plugins, macAddresses, requestBody);

                #endregion

                #region Handle API response

                using (var submitVatResponseReader =
                    new StreamReader(submitVatResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                          "processingDate": "2018-01-16T08:20:27.895+0000",
                          "paymentIndicator": "BANK",
                          "formBundleNumber": "256660290587",
                          "chargeRefNumber": "aCxFaNx0FZsCvyWF"
                        }*/

                    #endregion

                    // reads response body
                    var submitVatRetResponseText = submitVatResponseReader.ReadToEnd();
                    var submitVatRetResponseDecoded =
                        _serializer.Deserialize<Dictionary<string, string>>(submitVatRetResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessSubmitReturnResponseData(periodKey, submitVatRetResponseDecoded);

                    // Return Msg
                    var (returnCode, infobar) = _iMsgApp.MsgAppSp(string.Empty, "I=CmdSucceeded", "@!VATReturnsSubmission");
                    return (returnCode, infobar);
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) RetrieveObligation(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string status,
            string formName,
            string license,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get Backend Params and use them with Front-end Params to Call API and Get Response

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    startDate,
                    endDate,
                    userId,
                    false,
                    true,
                    clientVersion);

                // Call API
                var retrieveObligationResponse = _mtdVatApis.RetrieveObligations(backendParams.apiUrl, backendParams.accessToken,
                    backendParams.vrn, backendParams.startDate, backendParams.endDate, backendParams.isWeb, deviceId,
                    backendParams.localIps,
                    localIpsTimestamp, publicIp, publicIpTimestamp, publicPort, screens, timeZone, backendParams.userIds, windowSize,
                    backendParams.licenseIds, backendParams.productName, backendParams.vendorVersion, doNotTrack, userAgent, plugins,
                    macAddresses, status);

                #endregion

                #region Handle response data and Update database

                using (var retrieveObligationResponseReader = new StreamReader(
                    retrieveObligationResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                            "obligations": [
                            {
                                "periodKey": "18A1",
                                "start": "2017-01-01",
                                "end": "2017-03-31",
                                "due": "2017-05-07",
                                "status": "F",
                                "received": "2017-05-06"
                            },
                            {
                                "periodKey": "18A2",
                                "start": "2017-04-01",
                                "end": "2017-06-30",
                                "due": "2017-08-07",
                                "status": "O"
                            }
                            ]
                        }*/

                    #endregion

                    // reads response body
                    var submitVatRetResponseText = retrieveObligationResponseReader.ReadToEnd();
                    var retrieveObligationResponseDecoded =
                        _serializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(submitVatRetResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessRetrieveObligationsResponseData(retrieveObligationResponseDecoded);

                    // Return Msg
                    var (returnCode, infobar) = _iMsgApp.MsgAppSp(string.Empty, "I=CmdSucceeded", "@!ObligationsRetrieval");
                    return (returnCode, infobar);
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) GetLiabilities(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string formName,
            string license,
            string periodKey,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get Backend Params and use them with Front-end Params to Call API and Get Response

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    startDate,
                    endDate,
                    userId,
                    false,
                    true,
                    clientVersion);

                // Call API
                var retrieveLiabilitiesResponse = _mtdVatApis.RetrieveLiabilities(backendParams.apiUrl, backendParams.accessToken,
                    backendParams.vrn, backendParams.startDate, backendParams.endDate,
                    backendParams.isWeb, deviceId, backendParams.localIps, localIpsTimestamp, publicIp, publicIpTimestamp, publicPort,
                    screens,
                    timeZone,
                    backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName,
                    backendParams.vendorVersion, doNotTrack, userAgent, plugins, macAddresses);

                #endregion

                #region Handle response data and Update database

                using (var retrieveLiabilitiesResponseReader = new StreamReader(
                    retrieveLiabilitiesResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    // reads response body
                    var retrieveLiabilitiesResponseText = retrieveLiabilitiesResponseReader.ReadToEnd();
                    var retrieveLiabilitiesResponseDecoded =
                        _serializer.Deserialize<Dictionary<string, List<Dictionary<string, object>>>>(retrieveLiabilitiesResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessRetrieveLiabilitiesResponseData(periodKey, retrieveLiabilitiesResponseDecoded);

                    // Return Msg
                    return (0, "");
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) GetPayments(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string formName,
            string license,
            string periodKey,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get Backend Params and use them with Front-end Params to Call API and Get Response

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    startDate,
                    endDate,
                    userId,
                    false,
                    true,
                    clientVersion);

                // Call API
                var retrievePaymentsResponse = _mtdVatApis.RetrievePayments(backendParams.apiUrl, backendParams.accessToken,
                    backendParams.vrn,
                    backendParams.startDate, backendParams.endDate, backendParams.isWeb, deviceId, backendParams.localIps,
                    localIpsTimestamp,
                    publicIp, publicIpTimestamp,
                    publicPort, screens, timeZone, backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName,
                    backendParams.vendorVersion, doNotTrack, userAgent, plugins, macAddresses);

                #endregion

                #region Handle response data and Update database

                using (var retrieveLiabilitiesResponseReader = new StreamReader(
                    retrievePaymentsResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    #region Data Demo

                    /*{
                            "payments": 
                            [
                                {
                                    "amount": 5,
                                    "received": "2017-02-11"
                                },
                                {
                                    "amount": 5,
                                    "received": "2017-09-12"
                                }
                            ]
                        }*/

                    #endregion

                    // Read response body
                    var retrieveLiabilitiesResponseText = retrieveLiabilitiesResponseReader.ReadToEnd();
                    var retrieveLiabilitiesResponseDecoded =
                        _serializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(retrieveLiabilitiesResponseText);

                    // Process Response Data
                    _mtdAPIResponseDataProcessor.ProcessRetrievePaymentsResponseData(periodKey, retrieveLiabilitiesResponseDecoded);

                    // Return Msg
                    return (0, "");
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) ValidateFraudPreventionHeadersForRetrieveObligation(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string status,
            string formName,
            string license,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get Backend Params and use them with Front-end Params to Call API and Get Response

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    startDate,
                    endDate,
                    userId,
                    false,
                    true,
                    clientVersion);

                // Call API
                var validateFraudPreventionHeadersResponse = _mtdVatApis.ValidateFraudPreventionHeaders(backendParams.apiUrl,
                    backendParams.accessToken, backendParams.vrn, backendParams.startDate, backendParams.endDate, backendParams.isWeb,
                    deviceId, backendParams.localIps, localIpsTimestamp, publicIp, publicIpTimestamp, publicPort, screens, timeZone,
                    backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName, backendParams.vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);

                #endregion

                #region Handle response data and Update database

                using (var validateFraudPreventionHeadersReader = new StreamReader(
                    validateFraudPreventionHeadersResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                            "specVersion": "3.0",
                            "code": "POTENTIALLY_INVALID_HEADERS",
                            "message": "At least 1 header is potentially invalid",
                            "warnings": [
                                {
                                    "code": "EMPTY_HEADER",
                                    "message": "Value is empty. This may be correct for single factor authentication, for example username and password. If this is the case, you must contact us explaining why you cannot submit this header.",
                                    "headers": ["gov-client-multi-factor"]
                                }
                            ]
                        }
                     */

                    #endregion

                    return (16, validateFraudPreventionHeadersReader.ReadToEnd());
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (int returnCode, string message) ValidateFraudPreventionHeadersForGetLiabilities(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string formName,
            string license,
            string periodKey,
            string userId,
            string clientVersion)
        {
            try
            {
                #region Get Backend Params and use them with Front-end Params to Call API and Get Response

                var backendParams = GetBackendParams(doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    startDate,
                    endDate,
                    userId,
                    false,
                    true,
                    clientVersion);

                // Call API
                var validateFraudPreventionHeadersResponse = _mtdVatApis.ValidateFraudPreventionHeaders(backendParams.apiUrl,
                    backendParams.accessToken, backendParams.vrn, backendParams.startDate, backendParams.endDate, backendParams.isWeb,
                    deviceId, backendParams.localIps, localIpsTimestamp, publicIp, publicIpTimestamp, publicPort, screens, timeZone,
                    backendParams.userIds, windowSize, backendParams.licenseIds, backendParams.productName, backendParams.vendorVersion,
                    doNotTrack, userAgent, plugins, macAddresses);

                #endregion

                #region Handle response data and Update database

                using (var validateFraudPreventionHeadersReader = new StreamReader(
                    validateFraudPreventionHeadersResponse.GetResponseStream() ??
                    throw new InvalidOperationException()))
                {
                    #region Response Demo

                    /*{
                            "specVersion": "3.0",
                            "code": "POTENTIALLY_INVALID_HEADERS",
                            "message": "At least 1 header is potentially invalid",
                            "warnings": [
                                {
                                    "code": "EMPTY_HEADER",
                                    "message": "Value is empty. This may be correct for single factor authentication, for example username and password. If this is the case, you must contact us explaining why you cannot submit this header.",
                                    "headers": ["gov-client-multi-factor"]
                                }
                            ]
                        }
                     */

                    #endregion

                    return (16, validateFraudPreventionHeadersReader.ReadToEnd());
                }

                #endregion
            }
            catch (Exception e)
            {
                return (16, e.Message);
            }
        }

        public (string localIps, string vrn, string apiUrl, string accessToken, string productName, string vendorVersion, string licenseIds
            , string userIds, bool isWeb, string clientId, string secretKey, string redirectUri, string startDate, string endDate)
            GetBackendParams(
                string doNotTrack,
                string clientConnectMethod,
                string deviceId,
                string localIps,
                string localIpsTimestamp,
                string publicIp,
                string publicIpTimestamp,
                string publicPort,
                string screens,
                string timeZone,
                string windowSize,
                string userAgent,
                string plugins,
                string macAddresses,
                string envOs,
                string formName,
                string license,
                string startDate,
                string endDate,
                string userId,
                bool auth,
                bool isReadAccess,
                string clientVersion)
        {
            var (vrn, id, key, readAccessExpirationDate, writeAccessExpirationDate, _, _, apiUrl, webRedirectUri, winRedirectUri, readAccessToken, writeAccessToken, readRefreshToken, writeRefreshToken) = _mtdBusinessHandlerCRUD.SelectTaxparms();
            var accessToken = isReadAccess
                ? readAccessToken
                : writeAccessToken;
            if (!auth && ((isReadAccess && readAccessExpirationDate < DateTime.Now) ||
                          (!isReadAccess && writeAccessExpirationDate < DateTime.Now)))
            {
                var (returnCode, _) = RefreshToken(
                    isReadAccess ? readRefreshToken : writeRefreshToken,
                    doNotTrack,
                    clientConnectMethod,
                    deviceId,
                    localIps,
                    localIpsTimestamp,
                    publicIp,
                    publicIpTimestamp,
                    publicPort,
                    screens,
                    timeZone,
                    windowSize,
                    userAgent,
                    plugins,
                    macAddresses,
                    envOs,
                    formName,
                    license,
                    userId,
                    clientVersion);
                if (returnCode == 0)
                {
                    accessToken = isReadAccess
                        ? _mtdBusinessHandlerCRUD.SelectTaxparms().ReadAccessToken
                        : _mtdBusinessHandlerCRUD.SelectTaxparms().WriteAccessToken;
                }
            }

            var isWeb = clientConnectMethod == "web";
            var (productName, vendorVersion) = _mtdBusinessHandlerCRUD.SelectProductInfo();

            clientVersion = string.IsNullOrWhiteSpace(clientVersion) ? "1.0" : clientVersion;

            vendorVersion = isWeb
                ? $"MongooseWebClient={Uri.EscapeDataString(clientVersion)}&{Uri.EscapeDataString(productName)}={Uri.EscapeDataString(vendorVersion)}"
                : $"WinStudio={Uri.EscapeDataString(clientVersion)}&{Uri.EscapeDataString(productName)}={Uri.EscapeDataString(vendorVersion)}";

            productName = Uri.EscapeDataString(productName);
            envOs = envOs ?? string.Empty;
            license = license ?? string.Empty;
            var licenseIds = productName + "=" + Uri.EscapeDataString(license);
            var userIds = isWeb
                ? $"my-application={userId}"
                : $"os={Uri.EscapeDataString(envOs)}&my-application={userId}";
            var clientId = Decrypt(id);
            var secretKey = Decrypt(key);
            var redirectUri = isWeb
                ? Uri.EscapeDataString(webRedirectUri + formName)
                : Uri.EscapeDataString(winRedirectUri);

            startDate = DateTimeStringFormat(startDate); // yyyy-MM-dd
            endDate = DateTimeStringFormat(endDate);     // yyyy-MM-dd

            localIps = Uri.EscapeDataString(localIps);

            return (localIps, vrn, apiUrl, accessToken, productName, vendorVersion, licenseIds, userIds, isWeb, clientId, secretKey,
                redirectUri, startDate, endDate);
        }

        private string Decrypt(string encryptedString)
        {
            try
            {
                // Get the bytes of the string
                var bytesToBeDecrypted = Convert.FromBase64String(encryptedString);
                var passwordBytes = Encoding.UTF8.GetBytes("SaltBytes");
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                var bytesDecrypted = AESDecrypt(bytesToBeDecrypted, passwordBytes);

                return Encoding.UTF8.GetString(bytesDecrypted);
            }
            catch (Exception e)
            {
                throw new Exception("Decrypt Encrypted Characters Failed!", e);
            }
        }

        private byte[] AESDecrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};

            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private string DateTimeStringFormat(string datetimeString)
        {
            if (datetimeString.Contains("/") || datetimeString.Contains("-"))
            {
                datetimeString = DateTime.Parse(datetimeString).ToString("yyyy-MM-dd");
            }
            else
            {
                datetimeString = !string.IsNullOrWhiteSpace(datetimeString)
                    ? DateTime.ParseExact(datetimeString, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                    : datetimeString;
            }

            return datetimeString;
        }
    }
}